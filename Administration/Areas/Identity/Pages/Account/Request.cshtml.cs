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
using AspNetCore.ReCaptcha;

namespace IdentityManager.Areas.Identity.Pages.Account
{
    public class RequestModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailService _mailer;
        private readonly IApiClientService _apiClientService;
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly IConfiguration _config;
        private IdentityManagerContext _dbidentity;
        public RequestModel(
            ILogger<RegisterModel> logger,
             IEmailService mailer,
             IApiClientService apiClientService,
             IEmailConfiguration emailConfiguration,
             IConfiguration config,
             IdentityManagerContext dbidentity)
        {
            _logger = logger;
            _mailer = mailer;
            _apiClientService = apiClientService;
            _emailConfiguration= emailConfiguration;
            _config= config;
            _dbidentity = dbidentity;
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
        public string IdType { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
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
            [Display(Name = "Slažem se")]
            public bool Agree { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null, string idType = null)
        {
            //var locked = _dbidentity.Applications.Where(a => a.Id == 1).FirstOrDefault();
            //ViewData["Closed"] = false;
            //if (DateTime.Now > locked.CloseDate)
            //{
                ViewData["Closed"] = false;
            //}

                ReturnUrl = returnUrl;
                IdType = idType;
                ViewData["idtype"] = idType;
        }

        [ValidateReCaptcha]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(string returnUrl = null, string idType = null)
        {
           
            if (ModelState.IsValid)
            {
                string form = "Request/Check";
                var JMBG = Input.JMBG;
                var FirstName = Input.FirstName;
                var LastName = Input.LastName;
                var Email = Input.Email;
                var PhoneNumber = Input.PhoneNumber;
                if (idType == "2")
                    form = "Request/Cbs";

                string urlStr = String.Format("{0}/{1}/?JMBG={2}&FirstName={3}&LastName={4}&Email={5}&PhoneNumber={6}", _config["ByMailUrl"], form, JMBG, FirstName, LastName, Email, PhoneNumber);

                var uri = new Uri(urlStr);
                return Redirect(uri.AbsoluteUri);
                
            }
            
            return Page();
        }

    }
}
