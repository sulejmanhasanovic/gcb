// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using AspNetCore.ReCaptcha;
using Observers.Models;

namespace Observers.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<LoginModel> _logger;
        private IdentityManagerContext _db;
        public LoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger, IdentityManagerContext db, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
            _userManager = userManager;
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
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

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
            [EmailAddress]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "*")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        [ValidateReCaptcha]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = Url.Content("~/Dashboard/Index");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (!ModelState.IsValid)
                return Page();

            try
            {
                var email = Input.Email?.Trim();

                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    _logger.LogWarning("LOGIN FAIL: User not found. Email={Email}", email);
                    ModelState.AddModelError(string.Empty, "Neispravan email ili lozinka.");
                    return Page();
                }

                var result = await _signInManager.PasswordSignInAsync(
                    userName: email,                 
                    password: Input.Password,
                    isPersistent: Input.RememberMe,
                    lockoutOnFailure: false
                );

                _logger.LogInformation(
                    "LOGIN RESULT: Email={Email} Succeeded={Succeeded} 2FA={Requires2FA} LockedOut={LockedOut} NotAllowed={NotAllowed}",
                    email, result.Succeeded, result.RequiresTwoFactor, result.IsLockedOut, result.IsNotAllowed
                );

                if (result.Succeeded)
                {
                    var roles = (await _userManager.GetRolesAsync(user)).ToArray();
                    _logger.LogInformation("LOGIN ROLES: Email={Email} Roles=[{Roles}]", email, string.Join(",", roles));

                    var allowed = roles.Contains("OBS_Korisnik") || roles.Contains("OBS_Admin") || roles.Contains("OBS_Oik") || roles.Contains("CAND_Korisnik") || roles.Contains("PS_Korisnik");
                    if (!allowed)
                    {
                        _logger.LogWarning("LOGIN BLOCKED: Email={Email} Not in allowed roles.", email);
                        await _signInManager.SignOutAsync();
                        ModelState.AddModelError(string.Empty, "Nemate pravo pristupa.");
                        return Page();
                    }

                    var dbUser = _db.AspNetUsers.FirstOrDefault(a => a.UserName == email);
                    if (dbUser?.FirstLog == true)
                        return LocalRedirect(Url.Content("~/Identity/Account/Manage/ChangePassword"));

                    return LocalRedirect(returnUrl);
                }

                if (result.RequiresTwoFactor)
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });

                if (result.IsLockedOut)
                {
                    _logger.LogWarning("LOGIN LOCKED OUT: Email={Email}", email);
                    return RedirectToPage("./Lockout");
                }

                if (result.IsNotAllowed)
                {
                    _logger.LogWarning(
                        "LOGIN NOT ALLOWED: Email={Email} EmailConfirmed={EmailConfirmed} LockoutEnabled={LockoutEnabled}",
                        email, user.EmailConfirmed, user.LockoutEnabled
                    );

                    ModelState.AddModelError(string.Empty, "Prijava nije dozvoljena (npr. email nije potvrđen).");
                    return Page();
                }

                _logger.LogWarning("LOGIN FAIL: Invalid password? Email={Email} AccessFailedCount={AFC}", email, user.AccessFailedCount);
                ModelState.AddModelError(string.Empty, "Neispravan email ili lozinka.");
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "LOGIN ERROR: Email={Email}", Input.Email);
                ModelState.AddModelError(string.Empty, "Greška pri prijavi. Kontaktirajte podršku ili pokušajte kasnije.");
                return Page();
            }
        }
    }
}
