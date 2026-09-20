using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Observers.Models;
using Rotativa.AspNetCore;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace Observers.Controllers
{
   
    public partial class PdfController : Controller
    {
        private ObserversContext db;
        private ILogger _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public PdfController(IWebHostEnvironment hostingEnvironment, ObserversContext pc, ILogger<PdfController> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            db = pc;
            _logger = logger;
        }
        [Authorize]
        [HttpPost]
        public ActionResult Index()
        {
            try
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var culture = rqf.RequestCulture.Culture;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                string logo = Path.Combine(_hostingEnvironment.WebRootPath, "images", "grb.png");
                string logojs = Path.Combine(_hostingEnvironment.WebRootPath, "lib", "qrcode.min.js");
               // string pathsign = string.Format(@"{0}/{1}/{2}/{3}/{4}", _hostingEnvironment.ContentRootPath, "Docs", DateTime.Now.Year.ToString(), userId.ToString(), "p.png");

                int Id = int.Parse(HttpContext.Request.Form["Id"]);
                var data = db.Data_AOs.Where(a=>a.Id==Id).FirstOrDefault();
                if (culture.Name == "bs-Cyrl-BA")
                {
                    data.Name = Helpers.Converter.ConvertToCyrillic(data.Name);
                }

                var pdf = new Pdf
                {
                    main = data,
                    path = logo,
                    pathjs = logojs,
                    observers=db.AOPersonsViews.Where(a=>a.AccreditationObserverId==data.Id && a.DecisionId==null).ToList()
                };

                //cand.Status = 3;
                //db.SaveChanges();
                //string dataPath = _hostingEnvironment.WebRootPath;
                //ViewBag.path = dataPath;
                //if (data.AccreditationTypeId == 1)
                //{
                //    return new ViewAsPdf("Index1", pdf)
                //    {
                //        CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 8"
                //    };
                //}
                //else
                //{
                    return new ViewAsPdf("Index", pdf)
                    {
                        CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 8"
                    };
               // }
               


            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Pdf Index: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult AccreditationPrint()
        {
            try
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var culture = rqf.RequestCulture.Culture;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                //string logo = Path.Combine(_hostingEnvironment.ContentRootPath, "Templates", "1b.jpg");
                string logo = "";

                string logojs = Path.Combine(_hostingEnvironment.WebRootPath, "lib", "qrcode.min.js");
                // string pathsign = string.Format(@"{0}/{1}/{2}/{3}/{4}", _hostingEnvironment.ContentRootPath, "Docs", DateTime.Now.Year.ToString(), userId.ToString(), "p.png");

                int Id = int.Parse(HttpContext.Request.Form["Id"]);

                var data = db.Data_AOs.Where(a => a.Id == Id).FirstOrDefault();

                var observers = db.AOPersonsViews.Where(a => a.AccreditationObserverId == data.Id && a.Approved == true).ToList();

                observers.ForEach(d =>
                {
                    d.IsPrinted = true;
                });
                db.SaveChanges();

                if (data.AccreditationTypeId == 1)
                {
                    logo = Path.Combine(_hostingEnvironment.ContentRootPath, "Templates", string.Format(@"1{0}.jpg", data.Language));
                }
                if (data.AccreditationTypeId == 2)
                {
                    logo = Path.Combine(_hostingEnvironment.ContentRootPath, "Templates", string.Format(@"2{0}.jpg", data.Language));
                }
                if (data.AccreditationTypeId == 3)
                {
                    // logo = Path.Combine(_hostingEnvironment.ContentRootPath, "Templates", string.Format(@"3{0}.jpg", data.Language));
                    logo = Path.Combine(_hostingEnvironment.ContentRootPath, "Templates", "3.jpg");
                }
                if (culture.Name == "bs-Cyrl-BA")
                {
                    data.Name = Helpers.Converter.ConvertToCyrillic(data.Name);
                }

                var pdf = new PdfAccreditation
                {
                    main = data,
                    path = logo,
                    pathjs = logojs,
                    observers = observers
                };

                return new ViewAsPdf("Accreditation", pdf)
                {
                    CustomSwitches = "--orientation Landscape --page-offset 0 --disable-smart-shrinking"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Pdf Index: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult AccreditationPrintSelect()
        {
            try
            {
                var selectedIds = (HttpContext.Request.Form["SelectedId"].ToString() ?? "")
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .Where(x => int.TryParse(x, out _))
                    .Select(int.Parse)
                    .ToList();

                if (!selectedIds.Any())
                    return BadRequest("Nema odabranih ID-ova (SelectedId).");

                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var culture = rqf?.RequestCulture.Culture;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                string logo = "";
                string logojs = Path.Combine(_hostingEnvironment.WebRootPath, "lib", "qrcode.min.js");

                if (!int.TryParse(HttpContext.Request.Form["Id"], out int accId))
                    return BadRequest("Neispravan Id.");

                var data = db.Data_AOs.FirstOrDefault(a => a.Id == accId);
                if (data == null)
                    return NotFound("AccreditationObserver nije pronađen.");

                switch (data.AccreditationTypeId)
                {
                    case 1:
                        logo = Path.Combine(_hostingEnvironment.ContentRootPath, "Templates", $"1{data.Language}.jpg");
                        break;
                    case 2:
                        logo = Path.Combine(_hostingEnvironment.ContentRootPath, "Templates", $"2{data.Language}.jpg");
                        break;
                    case 3:
                        logo = Path.Combine(_hostingEnvironment.ContentRootPath, "Templates", "3.jpg");
                        break;
                }

                if (culture?.Name == "bs-Cyrl-BA")
                    data.Name = Helpers.Converter.ConvertToCyrillic(data.Name);

                // Učitaj iz tabele ono što možeš mijenjati
                var validPersons = db.Data_AOPersons
                    .Where(x => selectedIds.Contains(x.Id) && x.Approved)
                    .ToList();

                if (!validPersons.Any())
                    return NotFound("Nijedan odabrani posmatrač nije pronađen ili nije odobren.");

                foreach (var person in validPersons)
                {
                    person.IsPrinted = true;
                }

                db.SaveChanges();

                var validIds = validPersons.Select(x => x.Id).ToList();

                // View koristiš samo za prikaz/PDF
                var observers = db.AOPersonsViews
                    .Where(x => validIds.Contains(x.Id))
                    .ToList();

                var pdf = new PdfAccreditation
                {
                    main = data,
                    path = logo,
                    pathjs = logojs,
                    observers = observers
                };

                return new ViewAsPdf("Accreditation", pdf)
                {
                    CustomSwitches = "--orientation Landscape --page-offset 0 --disable-smart-shrinking"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Pdf Index");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public ActionResult PrintDecisionAccept(int decisionId, int observerId)
        {
            try
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var culture = rqf.RequestCulture.Culture;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                string logo = Path.Combine(_hostingEnvironment.WebRootPath, "images", "grb.png");
                var main = db.Data_AOs.Where(a => a.Id == observerId).FirstOrDefault();
                var data = db.ObserverPersonsViews.Where(a => a.DecisionId == decisionId && a.ObsApproved == true).ToList();
                var decision = db.Data_AODecisions.Where(d => d.Id == decisionId).FirstOrDefault();

                string AccDate = "";
                string AccNumber = "";
                string AccPs = "";
                string Sign = "";

                var pdf = new PdfDecisionAccept
                {
                    Organization=main,
                    main = data,
                    path = logo,
                    AccDate = AccDate,
                    AccNumber = AccNumber,
                    AccPs = AccPs,
                    Sign = Sign,
                    decision = decision,
                    DateSend = main.DateSend
                };

                return new ViewAsPdf("DecisionAccept", pdf)
                {
                    CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 8 --print-media-type"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Pdf Index: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
		public ActionResult PrintDecisionReject(int decisionId, int observerId)
		{
			try
			{
				var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
				var culture = rqf.RequestCulture.Culture;
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                string logo = Path.Combine(_hostingEnvironment.WebRootPath, "images", "grb.png");
                var main = db.Data_AOs.Where(a => a.Id == observerId).FirstOrDefault();
				var data = db.ObserverPersonsViews.Where(a => a.DecisionId == decisionId && a.ObsApproved == false).ToList();
                var decision=db.Data_AODecisions.Where(d => d.Id == decisionId).FirstOrDefault();

                string AccDate = "";
				string AccNumber = "";
				string AccPs = "";
                string Sign = "";

                var pdf = new PdfDecisionReject
				{
                    Organization=main,
                    main = data,
                    path = logo,
                    AccDate = AccDate,
					AccNumber = AccNumber,
					AccPs = AccPs,
                    Sign = Sign,
                    decision = decision,
                    DateSend = main.DateSend
                };

				return new ViewAsPdf("DecisionReject", pdf)
				{
					CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 8 --print-media-type"
                };
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error Pdf Index: {ex}");
				return StatusCode(500, "Internal server error");
			}
		}

        public ActionResult PrintDecisionOrganizationReject(int decisionId, int observerId)
        {
            try
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var culture = rqf.RequestCulture.Culture;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                string logo = Path.Combine(_hostingEnvironment.WebRootPath, "images", "grb.png");
                var main = db.Data_AOs.Where(a => a.Id == observerId).FirstOrDefault();
                var data = db.ObserverPersonsViews.Where(a => a.DecisionId == decisionId && a.ObsApproved == false).ToList();
                var decision = db.Data_AODecisions.Where(d => d.Id == decisionId).FirstOrDefault();

                string AccDate = "";
                string AccNumber = "";
                string AccPs = "";
                string Sign = "";

                var pdf = new PdfDecisionReject
                {
                    Organization=main,
                    main = data,
                    path = logo,
                    AccDate = AccDate,
                    AccNumber = AccNumber,
                    AccPs = AccPs,
                    Sign = Sign,
                    decision = decision,
                    DateSend = main.DateSend
                };

                return new ViewAsPdf("DecisionRejectOrganization", pdf)
                {
                    CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 8 --print-media-type"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Pdf Index: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        public ActionResult DeleteDecision(int Id, int decisionId)
        {
            try
            {
                using var transaction = db.Database.BeginTransaction();

                try
                {
                    var people = db.Data_AOPersons
                        .Where(a => a.DecisionId == decisionId)
                        .ToList();

                    foreach (var p in people)
                    {
                        p.DecisionId = null;
                    }

                    var decision = db.Data_AODecisions
                        .FirstOrDefault(a => a.Id == decisionId);

                    if (decision == null)
                    {
                        throw new Exception("Decision nije pronađen.");
                    }

                    db.Data_AODecisions.Remove(decision);

                    db.SaveChanges();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }



                var decisionlist = db.Data_AODecisions.Where(a => a.AccreditationObserverId == Id).ToList();
                return Json(new { decisionlist });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Pdf Index: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}