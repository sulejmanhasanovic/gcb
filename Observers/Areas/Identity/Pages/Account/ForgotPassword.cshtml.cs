// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Observers.Models;
using Observers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Localization;

namespace Observers.Areas.Identity.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        IEmailService _mailer;
        private readonly IConfiguration _config;
        IEmailConfiguration _emailConfiguration;
        private readonly ILogger<PageModel> _logger;
        private readonly IStringLocalizer<ForgotPasswordModel> _stringLocalizer;

        public ForgotPasswordModel(UserManager<IdentityUser> userManager, IEmailService mailer, ILogger<PageModel> logger, IEmailConfiguration emailConfiguration, IStringLocalizer<ForgotPasswordModel> stringLocalizer)
        {
            _userManager = userManager;
            _mailer = mailer;
            _logger = logger;
            _emailConfiguration= emailConfiguration;
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
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);


                try
                {
                    EmailMessage em = new EmailMessage();
                    em.Subject = _stringLocalizer["Zaboravljena šifra"];
                    em.Content = String.Format(_stringLocalizer["Zaboravljena šifra mail"], HtmlEncoder.Default.Encode(callbackUrl));
                    em.FromAddresses = new List<EmailAddress>
                                    {
                                        new EmailAddress{ Name=_stringLocalizer["Centralna izborna komisija Bosne i Hercegovine"], Address=_emailConfiguration.EmailFrom}
                                    };
                    em.ToAddresses = new List<EmailAddress>
                                    {
                                        new EmailAddress{ Name=Input.Email, Address=Input.Email}
                                    };

                    _mailer.Send(em);

                }
                catch (Exception ex)
                {
                    _logger.LogError("Email nije poslan kod zaboravljene šifre: {0} | {1}.", Input.Email, ex.ToString());
                }


                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
