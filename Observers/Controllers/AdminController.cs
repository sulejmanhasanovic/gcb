using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;
using System.Net.Http.Headers;
using Syncfusion.EJ2.Base;
using System.Collections;
using Observers.Models;
using Microsoft.AspNetCore.Localization;
using Observers.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Observers.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private ObserversContext _db;
        private IdentityManagerContext _dbidentity;
        IDataProtector _dataProtector;
        private IWebHostEnvironment _hostingEnv;
        public AdminController(ILogger<AdminController> logger, ObserversContext db, IDataProtectionProvider provider, IdentityManagerContext dbidentity,  IWebHostEnvironment hostingEnv)
        {
            _logger = logger;
            _db = db;
            _dbidentity = dbidentity;
            _hostingEnv = hostingEnv;
            _dataProtector = provider.CreateProtector("#Cik123678Observers!$");
        }

        public IActionResult Index(int id=1)
        {
            if (User.IsInRole("CAND_Korisnik") || User.IsInRole("OBS_Korisnik"))
            {
                return Redirect("/Dashboard/Index");
            }


            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            var data = id == 0
    ? _db.AOViews.Where(a => a.IdStatus == 2 || a.IdStatus == 4).ToList()
    : _db.AOViews.Where(a => a.IdStatus == id).ToList();

            if (culture.Name == "bs-Cyrl-BA")
            {
                foreach (var l in data)
                {
                    l.Name = Converter.ConvertToCyrillic(l.Name);
                    l.NameLatin = Converter.ConvertToCyrillic(l.NameLatin);
                    l.Municipality = Converter.ConvertToCyrillic(l.Municipality);
                    l.Address = Converter.ConvertToCyrillic(l.Address);
                }
            }

            ViewBag.Data = data;


            return View();
        }


        public IActionResult Statistic(int id = 1)
        {
            var statusCounts = _db.AOViews
                .GroupBy(x => x.IdStatus)
                .Select(g => new
                {
                    id = g.Key,
                    count = g.Count()
                })
                .ToList();

            var allStatuses = new[]
            {
        new { id = 1, name = "Unos toku" },
        new { id = 2, name = "Odbijen zahtjev" },
        new { id = 3, name = "Poslan zahtjev" },
        new { id = 4, name = "Odobren zahtjev" }
    };

            var obs = allStatuses
                .Select(s => new
                {
                    id = s.id,
                    name = s.name,
                    count = statusCounts
                        .Where(x => x.id == s.id)
                        .Select(x => x.count)
                        .FirstOrDefault()
                })
                .ToList();

            ViewBag.obs = obs;

            ViewBag.TypeOfOrganizationStat = _db.AOTypeStatViews
                .OrderBy(a => a.Id)
                .ToList();

            ViewBag.TypeOfOrganizationPersonStat = _db.AOPersonStatViews
                .OrderBy(a => a.Id)
                .ToList();

            return View("Statistic");
        }

        public IActionResult Oik(int id = 1)
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;
            var user = _dbidentity.AspNetUsers.Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            var data = _db.AOViews.FromSqlInterpolated($"[GetAccOrganizationsViewOIK] {user.IdMunicipality}").AsEnumerable().ToList();


            if (culture.Name == "bs-Cyrl-BA")
            {
                foreach (var l in data)
                {
                    l.Name = Converter.ConvertToCyrillic(l.Name);
                    l.NameLatin = Converter.ConvertToCyrillic(l.NameLatin);
                    l.Municipality = Converter.ConvertToCyrillic(l.Municipality);
                    l.Address = Converter.ConvertToCyrillic(l.Address);
                }
            }

            ViewBag.Data = data;


            return View("Index");
        }


        [HttpPost]
        public IActionResult StartDataEntry(string id, string language)
        {
            try
            {
                if (language == "S")
                {
                    Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("bs-Cyrl-BA")),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
                }
                else if (language == "H")
                {
                    Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("hr-BA")),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
                }
                else
                {
                    Response.Cookies.Append(
                     CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("bs-Latn-BA")),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
                }

                string encryptedId = _dataProtector.Protect(id);
                //HttpContext.Session.SetString("pid", encryptedId);
                var redirectUrl = Url.Content(string.Format("~/Dashboard/Index/?id={0}", encryptedId));
                return Json(new { url = redirectUrl });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Admin StartDataEntry: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        public IActionResult Register()
        {
            return View("Register");
        }


        [HttpPost]
        public IActionResult SaveOBS(InputModel registerModel)
        {
            var obs = new Data_AO();
            obs.Name = registerModel.Name;
            obs.Address = registerModel.Address;
            obs.AccreditationTypeId = registerModel.IdType;
            obs.Telephone = registerModel.Phone;
            obs.Email = registerModel.Email;
            obs.Language = registerModel.Language;
            obs.IdStatus = 1;
            _db.Data_AOs.Add(obs);
            _db.SaveChanges();
            string encryptedId = _dataProtector.Protect(obs.Id.ToString());
            //HttpContext.Session.SetString("pid", encryptedId);
            var redirectUrl = Url.Content(string.Format("~/Dashboard/Index/?id={0}", encryptedId));
            return Redirect(redirectUrl);
        }



        public IActionResult NewSearch()
        {
            try
            {
                return View("Search");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Admin StartDataEntry: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        public IActionResult DeleteData(int id)
        {
            try
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var culture = rqf.RequestCulture.Culture;

                var data = _db.Data_AOs.Where(a => a.Id == id).FirstOrDefault();
                if (data != null)
                {
                    _db.Data_AOs.Remove(data);
                    _db.SaveChanges();
                }
                var acc = _db.AOViews.ToList();

                if (culture.Name == "bs-Cyrl-BA")
                {
                    foreach (var l in acc)
                    {
                        l.Name = Converter.ConvertToCyrillic(l.Name);
                        l.NameLatin = Converter.ConvertToCyrillic(l.NameLatin);
                        l.Municipality = Converter.ConvertToCyrillic(l.Municipality);
                        l.Address = Converter.ConvertToCyrillic(l.Address);
                    }
                }

                return Json(new { observer = acc, success = "success" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Admin DeleteData: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [AcceptVerbs("Post")]
        public IActionResult RemoveDocument(IList<IFormFile> UploadAttachment)
        {
            return RemoveFile(UploadAttachment);
        }

        public IActionResult RemoveFile(IList<IFormFile> UploadFiles)
        {
            try
            {
                foreach (var file in UploadFiles)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var filePath = Path.Combine(_hostingEnv.WebRootPath);
                    var fileSavePath = filePath + "\\" + fileName;
                    if (!System.IO.File.Exists(fileSavePath))
                    {
                        System.IO.File.Delete(fileSavePath);
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
            }
            return Content("");
        }

        [HttpPost]
        public IActionResult UpdateNoOfDecision(int id, string noOfDecision)
        {
            try
            {
                if (id <= 0)
                    return Json(new { status = "Error", message = "Invalid Id" });

                var item = _db.Data_AOs
                    .FirstOrDefault(x => x.Id == id);

                if (item == null)
                    return Json(new { status = "Error", message = "Record not found" });

                item.NoOfDecision = string.IsNullOrWhiteSpace(noOfDecision)
                    ? null
                    : noOfDecision.Trim();

                item.IdUserUpdated = User.FindFirstValue(ClaimTypes.NameIdentifier);
                item.DateUpdated = DateTime.Now;

                _db.SaveChanges();

                return Json(new
                {
                    status = "Success",
                    id = item.Id,
                    noOfDecision = item.NoOfDecision
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateNoOfDecision error: {ex}");
                return StatusCode(500, new
                {
                    status = "Error",
                    message = "Internal server error"
                });
            }
        }

        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "*")]
            [Display(Name = "Naziv")]
            public string Name { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Adresa")]
            public string Address { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Broj telefona")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "*")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Jezik")]
            public string Language { get; set; }


            [Required(ErrorMessage = "*")]
            [Display(Name = "Slažem se")]
            public bool Agree { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Vrsta organizacije")]
            public int IdType { get; set; }
        }

    }
}