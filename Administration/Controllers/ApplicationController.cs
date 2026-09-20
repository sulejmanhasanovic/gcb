using Administration.Helpers;
using Administration.Models;
using Administration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Syncfusion.EJ2.Base;
using System.Collections;
using System.Diagnostics;
using System.Security.Claims;

namespace Administration.Controllers
{
    [Authorize(Roles = "IM_Admin")]
    public class ApplicationController : Controller
    {
        private IdentityManagerContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public ApplicationController(IdentityManagerContext db, UserManager<IdentityUser> userManager, ILogger<AdminController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.Applications = _db.Applications.ToList();
                return View();
        }

        public IActionResult UrlDatasource([FromBody] DataManagerRequest dm)
        {
            IEnumerable DataSource = _db.Applications.OrderBy(a => a.Id).ToList();
            DataOperations operation = new DataOperations();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<Application>().Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
        }

        public ActionResult CrudUpdate([FromBody] ICRUDModel<Application> user, string action)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var pc = user.value;
            if (user.action == "update")
            {
                Application app = _db.Applications.Where(or => or.Id == pc.Id).FirstOrDefault();
                app.NameBs = pc.NameBs;
                app.NameHr = pc.NameHr;
                app.NameSr = pc.NameSr;
                app.Active = pc.Active;
                app.DescriptionBs = pc.DescriptionBs;
                app.DescriptionHr = pc.DescriptionHr;
                app.DescriptionSr = pc.DescriptionSr;
                app.OpenDate= pc.OpenDate;
                app.CloseDate= pc.CloseDate;
                app.Notification= pc.Notification;
                app.Icon= pc.Icon;
                app.Url= pc.Url;

                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error Application update user:{0}", ex.ToString());                }
            
            }
            return Json(user.value);
        }

    }
}