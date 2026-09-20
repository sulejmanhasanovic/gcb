using Observers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Observers.Controllers
{
    public class ClassificationController : Controller
    {
        private readonly ILogger<ClassificationController> _logger;
        private ObserversContext _db;
        public ClassificationController(ILogger<ClassificationController> logger,  ObserversContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            try { 

                    ViewBag.data = _db.LookUp_Countries.ToArray();
                   
            return View();
            }catch(Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(LookUp_Country value)
        {
            try
            {
                        var countries = _db.LookUp_Countries.Where(a => a.Id == value.Id).FirstOrDefault();
                        countries.NameBs = value.NameBs;
                        countries.NameHr = value.NameHr;
                        countries.NameSr = value.NameSr;
                        countries.NameE = value.NameE;
                _db.SaveChanges();

                return Json(new {response="Success"});
            }catch(Exception ex)
            {
                return Json(new {response="Error"});
            }
        }

        [HttpPost]
        public ActionResult Insert(LookUp_Country value)
        {
            try
            {
                        var country = new LookUp_Country();
                        country.NameBs = value.NameBs;
                        country.NameHr = value.NameHr;
                        country.NameSr = value.NameSr;
                        country.NameE = value.NameE;
                _db.LookUp_Countries.Add(country);
                        _db.SaveChanges();
                return Json(new { response = "Success" });
            }
            catch(Exception ex)
            {
                return Json(new { response = "Error" });
            }
        }

        [HttpPost]
        public ActionResult Remove(int key)
        {
            try { 

					var country = _db.LookUp_Countries.Where(a => a.Id == key).FirstOrDefault();
					_db.LookUp_Countries.Remove(country);
					_db.SaveChanges();
                return Json(new { response = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { response = "Error" });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}