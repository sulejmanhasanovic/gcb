using Administration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Policy;
using Administration.Helpers;

namespace Administration.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        IDataProtector dataProtector;
        private IdentityManagerContext _db;
        private ElectionRepositoryContext _dbER;
        private PoliticalSubjectContext _dbPS;
        private CandidatesContext _dbCAND;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public DashboardController(
            ILogger<DashboardController> logger, 
            IdentityManagerContext db,
            ElectionRepositoryContext dbER,
            PoliticalSubjectContext dbPS,
            CandidatesContext dbCAND,
            IDataProtectionProvider provider, 
            ILoggerFactory loggerFactory, 
            SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager,
            IConfiguration config)
        {
            _logger = logger;
            _db = db;
            _dbER = dbER;
            _dbPS = dbPS;
            _dbCAND = dbCAND;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            dataProtector = provider.CreateProtector("#Cik123678IdentityManagerc!$");
        }

        public IActionResult Index()
        {
            //var applications = _db.Applications.OrderBy(a=>a.Sort).ToList();

            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //foreach(var app in applications)
            //{
            //    app.Url=dataProtector.Protect(app.Id.ToString());
            //}
            //ViewBag.applications = applications;

            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            ViewBag.voterStat = _dbER.EIzboriElectionVoterViews
                 .GroupBy(p => new { p.PoolingStationType })
                 .Select(g => new { PoolingStationType = (culture.Name == "bs-Cyrl-BA") ? Converter.ConvertToCyrillic(g.Key.PoolingStationType) : g.Key.PoolingStationType,  count = g.Count() })
                 .OrderByDescending(g => g.count).ToList();

            ViewBag.psStat = _dbPS.PoliticalEntitiesViews
                 .Where(a=>a.EIzboriPoliticalEntityStatus == 5 || a.EIzboriPoliticalEntityStatus == 6 || a.EIzboriPoliticalEntityStatus == 7 || a.EIzboriPoliticalEntityStatus == 10)
                 .GroupBy(p => new { p.ApplicationNameB })
                 .Select(g => new { ApplicationNameB = (culture.Name == "bs-Cyrl-BA") ? Converter.ConvertToCyrillic(g.Key.ApplicationNameB) : g.Key.ApplicationNameB, count = g.Count() })
                 .OrderByDescending(g => g.count).ToList();


            ViewBag.coalStat = _dbPS.CoalitionsViews
                 .Where(a => a.EIzboriPoliticalEntityStatus == 5 || a.EIzboriPoliticalEntityStatus == 6 || a.EIzboriPoliticalEntityStatus == 7 || a.EIzboriPoliticalEntityStatus == 10)
                 .GroupBy(p => new { p.ApplicationNameB })
                 .Select(g => new { ApplicationNameB = (culture.Name == "bs-Cyrl-BA") ? Converter.ConvertToCyrillic(g.Key.ApplicationNameB) : g.Key.ApplicationNameB, count = g.Count() })
                 .OrderByDescending(g => g.count).ToList();
            return View();
        }


        public IActionResult Applications(string id)
        {
            string iddecrypted=dataProtector.Unprotect(id);
            int idapp = int.Parse(iddecrypted);
            var app= _db.Applications.Where(a=>a.Id==idapp).FirstOrDefault();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string environment = _config["Environment"];
            string url = string.Empty;
            if (environment == "Production") {
                url = string.Format("{0}/{1}?auid={2}", app.Url, "Account/Login/", userId);
                if(app.Id == 5)
                {
                    url = string.Format("{0}/{1}?auid={2}", app.Url, "Dashboard/Login/", userId);
                }
            }
            else
            {
                url = string.Format("{0}/{1}?auid={2}", app.UrlDev, "Account/Login/", userId);
                if (app.Id == 5)
                {
                    url = string.Format("{0}/{1}?auid={2}", app.UrlDev, "Dashboard/Login/", userId);
                }
            }
            

            if (app.Id==1 && (User.IsInRole("PRP_Admin") || User.IsInRole("PRP_Unos") || User.IsInRole("PRP_Obrada") || User.IsInRole("PRP_Korisnik") || User.IsInRole("PRP_Info") || User.IsInRole("PRP_Izvjestaji") || User.IsInRole("PRP_Supervizor")))
            {
                return Redirect(url);

            }else if (app.Id==2 && (User.IsInRole("CAND_Korisnik") || User.IsInRole("CAND_Admin") || User.IsInRole("CAND_Obrada")))
            {
                return Redirect(url);
            }else if (app.Id==3 && (User.IsInRole("OBS_Korisnik") || User.IsInRole("OBS_Admin") || User.IsInRole("OBS_Oik")))
            {
                return Redirect(url);
            }
            else if (app.Id==5 && (User.IsInRole("PS_Korisnik") || User.IsInRole("PS_Potpisi") || User.IsInRole("PS_Admin") || User.IsInRole("PS_Obrada")))
            {
                return Redirect(url);
            }
            else if (app.Id == 6 && (User.IsInRole("BOO_Admin") || User.IsInRole("BOO_Obrada")))
            {
                return Redirect(url);
            }
            else if (app.Id == 7 && (User.IsInRole("BO_Admin") || User.IsInRole("BO_Obrada") || User.IsInRole("BO_Payroll") || User.IsInRole("BO_Trainer")))
            {
                return Redirect(url);
            }
            else if (app.Id == 8 && (User.IsInRole("COM_Admin") || User.IsInRole("COM_Obrada") || User.IsInRole("COM_MEC_Obrada")))
            {
                return Redirect(url);
            }
            else
            {
                ViewBag.msg = "Korinsik nije autorizovan za pristup ovoj aplikaciji";
                return RedirectToAction("Index");
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            var url = string.Format("{0}/{1}", _config["IdentityUrl"], "Dashboard");
            return Redirect(url);
            //return LocalRedirect("/Home");
        }

        [AllowAnonymous]
        [HttpPost]
        public void SetLanguage(string culture)
        {
            try
            {
                Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Dashboard SetLanguage: {ex}");
            }
        }


        public IActionResult GetMenu()
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            var claimsId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var applicationIds = (
                from userRole in _db.AspNetUserRoles
                join role in _db.AspNetRoles
                    on userRole.RoleId equals role.Id
                where userRole.UserId == claimsId
                select role.ApplicationId
            )
            .Distinct()
            .ToList();

            var applications = _db.Applications
                .Where(a => applicationIds.Contains(a.Id))
                .OrderBy(a => a.Sort)
                .ToList();

            foreach (var app in applications)
            {
                app.Url = dataProtector.Protect(app.Id.ToString());
            }

            return Json(new
            {
                applications = applications,
                culture = culture.Name
            });
        }

    }
}