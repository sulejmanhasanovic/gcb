// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Observers.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Observers.Services;
using Microsoft.Extensions.Localization;

namespace Observers.Areas.Identity.Pages.Account
{

    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private IdentityManagerContext _db;
        private ObserversContext _dbobservers;
        private readonly IApiClientService _apiClientService;
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly IConfiguration _config;
        private readonly IStringLocalizer<RegisterModel> _stringLocalizer;
        private readonly IEmailService _mailer;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailService mailer,
            IdentityManagerContext db,
            ObserversContext dbobserver,
             IApiClientService apiClientService,
             IEmailConfiguration emailConfiguration,
             IConfiguration config,
             IStringLocalizer<RegisterModel> stringLocalizer)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
            _dbobservers = dbobserver;
            _emailConfiguration = emailConfiguration;
            _config = config;
            _stringLocalizer = stringLocalizer;
            _mailer = mailer;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "*")]
            [Display(Name = "Naziv")]
            public string Name { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Adresa")]
            public string Address { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Broj telefona")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "*")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Jezik")]
            public string Language { get; set; }


            [Required(ErrorMessage = "*")]
            [Display(Name = "Slažem se")]
            public bool Agree { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Vrsta organizacije")]
            public int IdType { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            Input.Password = Observers.Helpers.GeneratePass.GenerateRandomPassword();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "OBS_KORISNIK");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                                  "/Account/ConfirmEmail",
                                  pageHandler: null,
                                  values: new { area = "Identity", userId = userId, code = code },
                                  protocol: Request.Scheme);

                    //Insert data to Observer database
                    var obs = new Data_AO();
                    obs.Name = Input.Name;
                    obs.Address = Input.Address;
                    obs.AccreditationTypeId = Input.IdType;
                    if(Input.IdType==2 || Input.IdType == 3)
                    {
                        obs.CIK = true;
                        obs.BM = true;
                        obs.DKP = true;
                    }
                    obs.Telephone = Input.Phone;
                    obs.Email = Input.Email;
                    obs.Language = Input.Language;
                    obs.IdStatus = 1;
                    _dbobservers.Data_AOs.Add(obs);
                    _dbobservers.SaveChanges();

                    var userDb = _db.AspNetUsers.Where(a => a.UserName == Input.Email).FirstOrDefault();
                    userDb.PhoneNumber = Input.Phone;
                    userDb.IdObs = obs.Id;
                    userDb.Language = Input.Language;
                    //Computer name
                    //string ComputerName=Dns.GetHostEntry(HttpContext.Connection.RemoteIpAddress).HostName;
                    //IP adress
                    IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
                    //Location
                    //UserGeoLocation location = new UserGeoLocation();
                   // location = await _apiClientService.GetLocationAsync(remoteIpAddress.ToString());

                    //userDb.ComputerName= ComputerName;
                    userDb.IpAddress = remoteIpAddress.ToString();
                   // userDb.Location = string.Format("{0}, {1}, {2}", location.country_name, location.zip, location.city);
                    //userDb.GeoData = Newtonsoft.Json.JsonConvert.SerializeObject(location);
                    _db.SaveChanges();

                    try
                    {
                        EmailMessage em = new EmailMessage();
                        em.Subject = _stringLocalizer["Potvrda prijave i pristupni podaci"];
                        em.Content = String.Format(
                            @_stringLocalizer["Potvrda prijave i pristupni podaci mail"],
                            Input.Email, Input.Password, callbackUrl);
                        em.FromAddresses = new List<EmailAddress>
                                    {
                                        new EmailAddress{ Name=_stringLocalizer["Centralna izborna komisija Bosne i Hercegovine"], Address=_emailConfiguration.EmailFrom}
                                    };
                        em.ToAddresses = new List<EmailAddress>
                                    {
                                        new EmailAddress{ Name=string.Format("{0}", Input.Name), Address=Input.Email}
                                    };

                        _mailer.Send(em);

                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, "Korisnik je uspješno kreiran, ali email korisniku nije poslan!");
                        _logger.LogError("Email nije poslan prilikom kreiranja korisnika: {0} | {1}.", Input.Email, ex.ToString());
                    }

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}
