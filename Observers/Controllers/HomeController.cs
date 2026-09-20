using Observers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Observers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IdentityManagerContext _dbidentity;
        private ObserversContext _db;

        public HomeController(ILogger<HomeController> logger, IdentityManagerContext dbidentity, ObserversContext db)
        {
            _logger = logger;
            _dbidentity = dbidentity;
            _db = db;
        }

        public IActionResult Index()
        {
			return View();
        }

        public IActionResult Privacy()
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