using IdentityManager.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Observers.Models;

namespace Observers.Controllers
{
    public class AccountController: Controller
    {
        private readonly ILogger<AccountController> _logger;
        IDataProtector dataProtector;
        private IdentityManagerContext _dbidentity;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(ILogger<AccountController> logger, IdentityManagerContext dbidentity, IDataProtectionProvider provider, ILoggerFactory loggerFactory, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _dbidentity = dbidentity;
            dataProtector = provider.CreateProtector("#Cik123678Observers!$");
            _signInManager = signInManager;
        }


        [HttpGet]
        public async Task<ActionResult> Login(string auid)
        {
            var user = await _signInManager.UserManager.FindByIdAsync(auid);

            if (user != null)
            {

                await _signInManager.SignInAsync(user, true);
            }

            var app = _dbidentity.Applications.Where(a => a.Id == 3).FirstOrDefault();
            ViewBag.app = app;
            if (app.Active == false || (app.Active==true && !string.IsNullOrEmpty(app.Notification)))
            {
                return Redirect("/Home/Index");
            }
            else
            {
                var userDb = _dbidentity.AspNetUsers.Where(a => a.Id == auid).FirstOrDefault();
                string cultureString = "bs-Latn-BA";
                if (userDb.Language == "S")
                    cultureString = "bs-Cyrl-BA";

                if (userDb.Language == "H")
                    cultureString = "hr-BA";

                Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureString)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

                return Redirect("/Dashboard/Index");
            }
           
        }
    }
}
