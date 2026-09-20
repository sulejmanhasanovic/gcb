using Administration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Administration.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IdentityManagerContext _db;
        private readonly IConfiguration _config;
        IDataProtector dataProtector;
        public HomeController(ILogger<HomeController> logger, IdentityManagerContext db, IConfiguration config, IDataProtectionProvider provider)
        {
            _logger = logger;
            _db = db;
            _config = config;
            dataProtector = provider.CreateProtector("#Cik123678IdentityManagerc!$");
        }

        public IActionResult Index()
        {
            ViewBag.Home = true;
            var applications = _db.Applications.ToList();
            foreach (var app in applications)
            {
                app.Url = dataProtector.Protect(app.Id.ToString());
            }
            ViewBag.applications = applications;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TermsOfUse()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}