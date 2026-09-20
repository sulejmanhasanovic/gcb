using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Observers.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Observers.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly ILogger<ReportsController> _logger;
        private Observers.Models.ObserversContext _db;
        private Models.IdentityManagerContext _dbidentity;
        IDataProtector _dataProtector;
        public ReportsController(ILogger<ReportsController> logger, ObserversContext db, IDataProtectionProvider provider, IdentityManagerContext dbidentity)
        {
            _logger = logger;
            _db = db;
            _dbidentity = dbidentity;
            _dataProtector = provider.CreateProtector("#Cik123678Observers!$");
        }

        [HttpGet]
        public IActionResult Index(string filterParam = "0")
        {

            var obs = _db.ObserverPersonsViews.OrderBy(a=>a.Name).ToList();
            ViewBag.ReportData = obs;

            return View();
        }
    }
}