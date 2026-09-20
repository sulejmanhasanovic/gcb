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
using IdentityManager.Models;
using IdentityManager.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Microsoft.Extensions.Localization;
using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityManager.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailService _mailer;
        private IdentityManagerContext _db;
        private readonly IApiClientService _apiClientService;
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly IConfiguration _config;
        IDataProtector dataProtector;
        private readonly IStringLocalizer<RegisterModel> _stringLocalizer;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IdentityManagerContext db,
             IEmailService mailer,
             IApiClientService apiClientService,
             IEmailConfiguration emailConfiguration,
             IDataProtectionProvider provider,
             IConfiguration config,
             IStringLocalizer<RegisterModel> stringLocalizer)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _logger = logger;
            _mailer = mailer;
            _db= db;
            _apiClientService = apiClientService;
            _emailConfiguration= emailConfiguration;
            _config= config;
            dataProtector = provider.CreateProtector("#Cik123678IdentityManagerc!$");
            _stringLocalizer = stringLocalizer;

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
            [Display(Name = "Ime")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Prezime")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "*")]
            [StringLength(13, MinimumLength = 13, ErrorMessage = "JMB mora biti 13 karaktera/ЈМБ мора бити 13 карактера")]

            [Display(Name = "JMBG")]
            public string JMBG { get; set; }

            [Required(ErrorMessage = "*")]
            [EmailAddress(ErrorMessage = "Pogrešan format / Погрешан формат")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Telefon")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Aplikacija")]
            public int Application { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Jezik")]
            public string Language { get; set; }

            [Required( ErrorMessage = "*")]
            [Display(Name = "Slažem se")]
            public bool Agree { get; set; }

            [Display(Name = "Šifra")]
            public string Password { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            var locked = _db.Applications.Where(a => a.Id == 1).FirstOrDefault();
            ViewData["Closed"] = false;
            if (DateTime.Now > locked.CloseDate)
            {
                ViewData["Closed"] = true;
            }

            var x = _db.Applications.Where(a => a.Active == true)
                .Select(a => new SelectListItem
                {
                    Text = (culture.Name == "bs-Cyrl-BA") ? a.NameSr : (culture.Name == "hr-BA") ? a.NameHr : a.NameBs,
                    Value = a.Id.ToString()
                })
                 .OrderBy(a => a.Value)
                .ToList();
            ViewData["Applications"] = x;
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        [ValidateReCaptcha]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            Input.Password = IdentityManager.Helpers.GeneratePass.GenerateRandomPassword();
            //var app = _db.Applications.Where(a => a.Id == 1).FirstOrDefault();
            if (ModelState.IsValid)
            {
                //Chech if user exist in Voter
                //var userExistInCbs = _db.Voters.Where(a => a.FirstName.ToLower() == Input.FirstName.Trim().ToLower() && a.LastName.ToLower() == Input.LastName.Trim().ToLower() && a.RegId == Input.JMBG.Trim()).FirstOrDefault();
                var userExistInCbs = _db.Voters.Where(a => a.RegId == Input.JMBG.Trim() && a.Eligible == "1").FirstOrDefault();
                var emailExist = _db.AspNetUsers.Any(x => x.Email == Input.Email);

                //Registracija za glasanje van BiH
                //if (Input.Application == 1)
                //{
                    //1. Prva provjera da li ima prp obrazac (ime, prezime, jmbg podaci isti u prp-u) u zavisnosti od toga ima dvije mogucnosti prijava i podnesi zahtjev broj 3 mail
                    var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@FirstName",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Input.FirstName
                        },
                        new SqlParameter() {
                            ParameterName = "@LastName",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Input.LastName
                        },
                        new SqlParameter() {
                            ParameterName = "@RegId",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Direction = System.Data.ParameterDirection.Input,
                            Value=Input.JMBG
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@PrpExist",
                            SqlDbType = System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Output
                        }};
                    int affectedRows = await _db.Database.ExecuteSqlRawAsync("CheckPrpData @FirstName, @LastName, @RegId, @PrpExist out", param);
                    int prpExist = Convert.ToInt32(param[3].Value);

                    //1. Ako postoji prp ide stranica za izbor
                    if (prpExist == 1)
                    {
                        TempData["CheckType"] = "Registration";
                        TempData["Input"] = JsonConvert.SerializeObject(Input);
                        return RedirectToAction("LoginCheck", "Home");
                    }

                    //2.Druga provjera, da li postoji samo mail, ako postoji mail izmjena email
                    if (emailExist)
                    {
                        ModelState.AddModelError(string.Empty, _stringLocalizer["Email je već iskorišten za registraciju naloga, promijenite email"]);

                    }
                    else
                    {
                        //3. Da li je upisan u CBS ide obrazac dva ako nije, a registruje se ako jeste ide registracija i sledeca prijava na obrazac 1
                        if (userExistInCbs != null)
                        {
                            var user = CreateUser();
                            user.UserName = Input.Email;
                            user.Email = Input.Email;
                            var result = await _userManager.CreateAsync(user, Input.Password);

                            if (result.Succeeded)
                            {
                                _logger.LogInformation("User created a new account with password: {0}", Input.Email);
                                await _userManager.AddToRoleAsync(user, "PRP_KORISNIK");
                                var userId = await _userManager.GetUserIdAsync(user);
                                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                                var callbackUrl = Url.Page(
                                    "/Account/ConfirmEmail",
                                    pageHandler: null,
                                    values: new { area = "Identity", userId = userId, code = code },
                                    protocol: Request.Scheme);

                                var userDb = _db.AspNetUsers.Where(a => a.UserName == Input.Email).FirstOrDefault();
                                userDb.PhoneNumber = Input.PhoneNumber;
                                userDb.IdCbs = userExistInCbs.RegId;
                                userDb.Language = Input.Language;
                                //Computer name
                                //string ComputerName=Dns.GetHostEntry(HttpContext.Connection.RemoteIpAddress).HostName;
                                //IP adress
                                IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
                                //Location
                                UserGeoLocation location = new UserGeoLocation();
                                location = await _apiClientService.GetLocationAsync(remoteIpAddress.ToString());

                                //userDb.ComputerName= ComputerName;
                                userDb.IpAddress = remoteIpAddress.ToString();
                                userDb.Location = string.Format("{0}, {1}, {2}", location.country_name, location.zip, location.city);
                                userDb.GeoData = Newtonsoft.Json.JsonConvert.SerializeObject(location);

                                _db.SaveChanges();

                                try
                                {
                                    EmailMessage em = new EmailMessage();
                                    em.Subject = _stringLocalizer["Potvrda prijave i pristupni podaci"];
                                    em.Content = String.Format(
                                        @_stringLocalizer["Potvrda prijave i pristupni podaci mail"],
                                        Input.FirstName, Input.LastName, Input.Email, Input.Password, callbackUrl);
                                    em.FromAddresses = new List<EmailAddress>
                                    {
                                        new EmailAddress{ Name=_stringLocalizer["Centralna izborna komisija Bosne i Hercegovine"], Address=_emailConfiguration.EmailFrom}
                                    };
                                    em.ToAddresses = new List<EmailAddress>
                                    {
                                        new EmailAddress{ Name=string.Format("{0} {1}", Input.FirstName, Input.LastName), Address=Input.Email}
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
                            }

                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Nemate pravo pristupa jer se ne nalazite u centralnom biračkom spisku. Provjerite podatke koje ste unijeli.");
                            string urlStr = String.Format("{0}/{1}/?JMBG={2}&FirstName={3}&LastName={4}&Email={5}&PhoneNumber={6}", _config["ByMailUrl"], "Request/Cbs", Input.JMBG, Input.FirstName, Input.LastName, Input.Email, Input.PhoneNumber);

                            var uri = new Uri(urlStr);
                            return Redirect(uri.AbsoluteUri);

                        }
                    }
                }
                //Kandidati
                //if (Input.Application == 2)
                //{
                //    //1. Prva provjera, da li postoji samo mail, ako postoji mail izmjena email
                //    if (emailExist)
                //    {
                //        ModelState.AddModelError(string.Empty, _stringLocalizer["Email je već iskorišten za registraciju naloga, promijenite email"]);

                //    }
                //    else
                //    {
                //        //2. Da li je upisan u CBS obavijest ako nije, a registruje se ako jeste
                //        if (userExistInCbs != null)
                //        {
                //            var user = CreateUser();
                //            user.UserName = Input.Email;
                //            user.Email = Input.Email;
                //            var result = await _userManager.CreateAsync(user, Input.Password);

                //            if (result.Succeeded)
                //            {
                //                _logger.LogInformation("User created a new account with password: {0}", Input.Email);
                //                await _userManager.AddToRoleAsync(user, "CAND_KORISNIK");
                //                var userId = await _userManager.GetUserIdAsync(user);
                //                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                //                var callbackUrl = Url.Page(
                //                    "/Account/ConfirmEmail",
                //                    pageHandler: null,
                //                    values: new { area = "Identity", userId = userId, code = code },
                //                    protocol: Request.Scheme);

                //                var userDb = _db.AspNetUsers.Where(a => a.UserName == Input.Email).FirstOrDefault();
                //                userDb.PhoneNumber = Input.PhoneNumber;
                //                userDb.IdCbs = userExistInCbs.RegId;
                //                userDb.Language = Input.Language;
                //                //Computer name
                //                //string ComputerName=Dns.GetHostEntry(HttpContext.Connection.RemoteIpAddress).HostName;
                //                //IP adress
                //                IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
                //                //Location
                //                UserGeoLocation location = new UserGeoLocation();
                //                location = await _apiClientService.GetLocationAsync(remoteIpAddress.ToString());

                //                //userDb.ComputerName= ComputerName;
                //                userDb.IpAddress = remoteIpAddress.ToString();
                //                userDb.Location = string.Format("{0}, {1}, {2}", location.country_name, location.zip, location.city);
                //                userDb.GeoData = Newtonsoft.Json.JsonConvert.SerializeObject(location);

                //                _db.SaveChanges();

                //                try
                //                {
                //                    EmailMessage em = new EmailMessage();
                //                    em.Subject = _stringLocalizer["Potvrda prijave i pristupni podaci"];
                //                    em.Content = String.Format(
                //                        @_stringLocalizer["Potvrda prijave i pristupni podaci mail"],
                //                        Input.FirstName, Input.LastName, Input.Email, Input.Password, callbackUrl);
                //                    em.FromAddresses = new List<EmailAddress>
                //                    {
                //                        new EmailAddress{ Name=_stringLocalizer["Centralna izborna komisija Bosne i Hercegovine"], Address=_emailConfiguration.SmtpUsername}
                //                    };
                //                    em.ToAddresses = new List<EmailAddress>
                //                    {
                //                        new EmailAddress{ Name=string.Format("{0} {1}", Input.FirstName, Input.LastName), Address=Input.Email}
                //                    };

                //                    _mailer.Send(em);

                //                }
                //                catch (Exception ex)
                //                {
                //                    ModelState.AddModelError(string.Empty, "Korisnik je uspješno kreiran, ali email korisniku nije poslan!");
                //                    _logger.LogError("Email nije poslan prilikom kreiranja korisnika: {0} | {1}.", Input.Email, ex.ToString());
                //                }

                //                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                //                {
                //                    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                //                }
                //            }

                //            foreach (var error in result.Errors)
                //            {
                //                ModelState.AddModelError(string.Empty, error.Description);
                //            }
                //        }
                //        else
                //        {
                //            ModelState.AddModelError(string.Empty, "Nemate pravo pristupa jer se ne nalazite u centralnom biračkom spisku. Provjerite podatke koje ste unijeli.");

                //        }
                //    }


                //}
            //}
            

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
