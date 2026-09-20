using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Observers.Helpers;
using Observers.Models;
using Observers.Services;
using Syncfusion.Drawing;
using Syncfusion.EJ2.Base;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Observers.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        IDataProtector dataProtector;
        private ObserversContext _db;
        private IdentityManagerContext _dbidentity;
        private cbsdbContext _cbsdb;
        private IWebHostEnvironment hostingEnv;
        IEmailService _mailer;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;
        IEmailConfiguration _emailConfiguration;
        private readonly IStringLocalizer<DashboardController> _stringLocalizer;
        public DashboardController(ILogger<DashboardController> logger, ObserversContext db, IdentityManagerContext dbuser, IDataProtectionProvider provider, ILoggerFactory loggerFactory, IWebHostEnvironment env, IEmailService mailer, SignInManager<IdentityUser> signInManager, IConfiguration config, IEmailConfiguration emailConfiguration, IStringLocalizer<DashboardController> stringLocalizer, cbsdbContext cbsdb)
        {
            _logger = logger;
            _db = db;
            _dbidentity = dbuser;
            dataProtector = provider.CreateProtector("#Cik123678Observers!$");
            this.hostingEnv = env;
            _mailer = mailer;
            _signInManager = signInManager;
            _config = config;
            _emailConfiguration = emailConfiguration;
            _stringLocalizer = stringLocalizer;
            _cbsdb = cbsdb;
        }

        public IActionResult Index(string id = "")
        {

            int statusApplication = 0;
            string decryptedId = "";
            int idAcc = 0;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            //Preusmjeravanje u administraciju ako nije korisnik s portala
            if (User.IsInRole("OBS_Admin") && string.IsNullOrEmpty(id))
            {
                return Redirect("/Admin/Statistic");
            }

            if (User.IsInRole("OBS_Oik") && string.IsNullOrEmpty(id))
            {
                return Redirect("/Admin/Oik");
            }

            var user = new AspNetUser();
            user = _dbidentity.AspNetUsers.Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();

            //Ako je korisnik sa portala preko usera uzeti Regid
            if (User.IsInRole("CAND_Korisnik") || User.IsInRole("OBS_Korisnik") || User.IsInRole("PS_Korisnik"))
            {

                decryptedId = user.IdObs.ToString();
                idAcc = int.Parse(decryptedId);
                var application = _dbidentity.Applications.Where(a => a.Id == 3).FirstOrDefault();
                if (application.OpenDate != null && application.OpenDate > DateTime.Now.Date)
                {
                    statusApplication = 1;
                    ViewBag.OpenDate = application.OpenDate.Value.ToString("dd.MM.yyyy");
                }

                if (application.CloseDate != null && application.CloseDate < DateTime.Now.Date)
                {
                    statusApplication = 2;
                }
            }

            //Ako je iz administracije id preko query string
            else
            {
                decryptedId = dataProtector.Unprotect(id);
                idAcc = int.Parse(decryptedId);
            }


            ViewBag.StatusApplication = statusApplication;

            //var data = _db.AccreditationObservers.Where(a => a.Id == user.IdObs).FirstOrDefault();
            //ViewBag.ObserverPersons = _db.AccreditationObserverPeople.Where(a => a.AccreditationObserverId == user.IdObs).ToList();

            var data = _db.Data_AOs.Where(a => a.Id == idAcc).FirstOrDefault();
            List<AOPersonsView> obsPersons = new();

            if (User.IsInRole("OBS_Oik"))
            {
                obsPersons = _db.AOPersonsViews.FromSqlInterpolated($"GetObserverPersonsOik {idAcc},{user.IdMunicipality}").AsEnumerable().ToList();
            }
            else
            {
                obsPersons = _db.AOPersonsViews.FromSqlInterpolated($"GetObserverPersons {idAcc}").AsEnumerable().ToList();
            }


            ViewBag.ObserverPersons = obsPersons;
            ViewBag.AODecisions = _db.Data_AODecisions.Where(a => a.AccreditationObserverId == idAcc).ToList();

            if (data != null && data.AccreditationTypeId == 1)
            {
                ViewBag.Municipalities = _db.LookUp_Municipalities.FromSqlInterpolated($"GetMunicipalities {data.Code}").AsEnumerable().Select(a => new
                {
                    Id = a.Id.ToString(),
                    Name = a.Code.ToString() + " " +
       ((culture.Name == "bs-Cyrl-BA")
           ? Observers.Helpers.Converter.ConvertToCyrillic(a.NameLatin).ToString()
           : a.NameLatin)
                })
                .OrderBy(a => a.Name)
                .ToList();

            }
            else
            {

                ViewBag.Municipalities = _db.LookUp_Municipalities
                .Select(a => new
                {
                    Id = a.Id.ToString(),
                    Name = a.Code.ToString() + " " +
                    ((culture.Name == "bs-Cyrl-BA")
           ? a.NameCyrillic
           : a.NameLatin)
                })
                .OrderBy(a => a.Name)
                .ToList();
            }

            ViewBag.Dkp = _db.LookUp_Dkps
            .Select(a => new
            {
                Id = a.Id.ToString(),
                Name = (culture.Name == "bs-Cyrl-BA") ? a.NameSr : (culture.Name == "hr-BA") ? a.NameHr : a.NameBs
            })
            .OrderBy(a => a.Name)
            .ToList();

            ViewBag.RejectionReason = _db.LookUp_RejectionReasons.Where(a=>a.DocumentTypeId==1)
            .Select(a => new
            {
                Id = a.Id,
                Name = (culture.Name == "bs-Cyrl-BA") ? a.NameSr : (culture.Name == "hr-BA") ? a.NameHr : a.NameBs
            })
            .OrderBy(a => a.Id)
            .ToList();

            ViewBag.RejectionReasonPersons = _db.LookUp_RejectionReasons.Where(a => a.DocumentTypeId == 2)
.Select(a => new
{
    Id = a.Id,
    Name = (culture.Name == "bs-Cyrl-BA") ? a.NameSr : (culture.Name == "hr-BA") ? a.NameHr : a.NameBs
})
.OrderBy(a => a.Id)
.ToList();

            ViewBag.Country = _db.LookUp_Countries
                .Select(a => new
                {
                    Id = a.Id,
                    Name = (culture.Name == "bs-Cyrl-BA") ? a.NameSr
                         : (culture.Name == "hr-BA") ? a.NameHr
                         : (culture.Name == "en-GB") ? a.NameE
                         : a.NameBs
                })
                .OrderBy(a => a.Name)
                .ToList();

            var reasons = new Reasons(_db);
            ViewBag.Message = reasons.CheckReasons(data);

            return View(data);

        }

        [HttpPost]
        [AllowAnonymous]
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

        [AcceptVerbs("Post")]
        public IActionResult SaveIdentity(IList<IFormFile> UploadAttachmentIdentity)
        {
            return SaveFile(UploadAttachmentIdentity, 1);
        }

        [AcceptVerbs("Post")]
        public IActionResult SaveRequest(IList<IFormFile> UploadAttachmentRequest)
        {
            return SaveFile(UploadAttachmentRequest, 2);
        }

        [AcceptVerbs("Post")]
        public IActionResult RemoveIdentity(IList<IFormFile> UploadAttachmentIdentity)
        {
            return RemoveFile(UploadAttachmentIdentity);
        }

        public IActionResult RemoveRequest(IList<IFormFile> UploadAttachmentRequest)
        {
            return RemoveFile(UploadAttachmentRequest);
        }

        public IActionResult RemoveFile(IList<IFormFile> UploadFiles)
        {
            try
            {
                foreach (var file in UploadFiles)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var filePath = Path.Combine(hostingEnv.WebRootPath);
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

        private IActionResult SaveFile(IList<IFormFile> UploadFiles, int idtype)
        {
            try
            {
                var UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                foreach (var file in UploadFiles)
                {
                    if (UploadFiles != null)
                    {



                        string id = Request.Form["id"];

                        int idint = int.Parse(id);
                        string folderId = "";
                        var obs = _db.Data_AOs.Where(a => a.Id == idint).FirstOrDefault();
                        if (obs != null)
                        {
                            folderId = obs.Id.ToString();
                        }

                        //string folderId = UserId.ToString();
                        var filename = string.Format("{0}_{1}_{2}{3}", idtype, DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"), Path.GetFileNameWithoutExtension(ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"')), ".pdf");
                        string path = string.Format(@"{0}/{1}/{2}", hostingEnv.ContentRootPath, _config["OBSPath"], folderId);
                        bool exists = Directory.Exists(path);
                        if (!exists)
                        {
                            Directory.CreateDirectory(path);
                        }
                        else
                        {

                            // Process the list of files found in the directory.
                            string[] fileEntries = Directory.GetFiles(path);
                            int i = 0;
                            foreach (string fileName in fileEntries)
                                if (Path.GetFileName(fileName).StartsWith(idtype.ToString()))
                                {
                                    i++;
                                    if (i >= 5)
                                    {
                                        Response.Clear();
                                        Response.StatusCode = 404;
                                        Response.Headers.Add("status", "Maximalan broj dokumenata je pet.");
                                        return Content("");
                                    }
                                }
                        }
                        string filenameDisk = path + $@"/{filename}";
                        string filenameDatabase = string.Format(@"/{0}/{1}/{2}", _config["OBSPath"], folderId, filename);

                        string documentSize = "0";
                        string name = file.FileName;
                        if (Path.GetExtension(file.FileName).ToLower() == ".jpg" || Path.GetExtension(file.FileName).ToLower() == ".jpeg" || Path.GetExtension(file.FileName).ToLower() == ".png" || Path.GetExtension(file.FileName).ToLower() == ".bmp")
                        {
                            PdfDocument documentPdf = new PdfDocument();
                            documentPdf.PageSettings.Margins.All = 0;
                            MemoryStream fs = new MemoryStream();
                            file.CopyTo(fs);

                            PdfPage page = page = documentPdf.Pages.Add();

                            float PageWidth = page.Graphics.ClientSize.Width;
                            float PageHeight = page.Graphics.ClientSize.Height;

                            PdfImage image = PdfImage.FromStream(fs);
                            float myWidth = image.Width;
                            float myHeight = image.Height;
                            //Adding new page

                            float shrinkFactor;

                            if (myWidth > PageWidth)
                            {
                                shrinkFactor = myWidth / PageWidth;
                                myWidth = PageWidth;
                                myHeight = myHeight / shrinkFactor;
                            }

                            if (myHeight > PageHeight)
                            {
                                shrinkFactor = myHeight / PageHeight;
                                myHeight = PageHeight;
                                myWidth = myWidth / shrinkFactor;
                            }

                            float XPosition = (PageWidth - myWidth) / 2;
                            float YPosition = (PageHeight - myHeight) / 2;



                            page.Graphics.DrawImage(image, XPosition, YPosition, myWidth, myHeight);
                            MemoryStream stream = new MemoryStream();

                            documentPdf.Save(stream);


                            PdfLoadedDocument pdf = new PdfLoadedDocument(stream);
                            PdfCompressionOptions options = new PdfCompressionOptions();
                            options.CompressImages = true;
                            options.ImageQuality = 50;
                            options.OptimizeFont = true;
                            options.OptimizePageContents = true;
                            options.RemoveMetadata = true;

                            pdf.Compress(options);
                            MemoryStream streamPdf = new MemoryStream();

                            pdf.Save(streamPdf);
                            pdf.Close(true);
                            System.IO.File.WriteAllBytes(filenameDisk, streamPdf.ToArray());

                            name = name.Replace(Path.GetExtension(file.FileName), ".pdf");

                            fs.Dispose();
                            documentSize = Converter.ToFileSize(streamPdf.Length);
                        }
                        else
                        {

                            using (FileStream fs = System.IO.File.Create(filenameDisk))
                            {
                                file.CopyTo(fs);
                                documentSize = Converter.ToFileSize(fs.Length);
                                fs.Flush();
                            }
                        }

                        var document = new Data_AODocument();
                        document.DataId = int.Parse(id);
                        document.DocumentDate = DateOnly.FromDateTime(DateTime.Now);
                        document.DocumentName = name;
                        document.DocumentPath = filenameDatabase;
                        document.DocumentSize = documentSize;
                        document.IdUserInserted = UserId;
                        document.DateInserted = DateTime.Now;
                        document.DocumentType = idtype;

                        _db.Data_AODocuments.Add(document);

                        _db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
            }
            return Content("");
        }

        public IActionResult GetDocuments(int id = 0, int idtype = 0)
        {
            int? IdStatus = 0;
            var documents = _db.Data_AODocuments.Where(a => a.DataId == id && a.DocumentType == idtype).ToList();
            var prp = _db.Data_AOs.Where(a => a.Id == id).FirstOrDefault();
            return PartialView("_Documents", documents);
        }

        [HttpPost]
        public IActionResult SaveData(Data_AO obs)
        {
            if (ModelState.IsValid)
            {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                var culture = rqf.RequestCulture.Culture;



                var obsData = _db.Data_AOs.Where(a => a.Id == obs.Id).FirstOrDefault();

                if (obsData != null)
                {
                    obsData.Name = obs.Name;
                    obsData.Address = obs.Address;
                    obsData.Telephone = obs.Telephone;
                    obsData.Email = obs.Email;
                    obsData.Language = obs.Language;
                    obsData.AccreditationTypeId = obs.AccreditationTypeId;
                    obsData.Reason = obs.Reason;
                    obsData.OIK = obs.OIK;
                    obsData.CIK = obs.CIK;
                    obsData.DKP = obs.DKP;
                    obsData.GCB = obs.GCB;
                    obsData.CBS = obs.CBS;
                    obsData.BM = obs.BM;
                    obsData.IdStatus = obs.IdStatus;
                    obsData.IdUserUpdated = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    obsData.DateUpdated = DateTime.Now;

                    if (obsData.IdStatus == 0)
                    {
                        obsData.IdReason = obs.IdReason;
                        obsData.Approved = obs.IdReason == 1;
                        obsData.NoOfDecision = obs.NoOfDecision;
                        obsData.Comment = obs.Comment;

                        //Valid
                        if (obsData.IdReason == 1)
                            {
                                obsData.IdStatus = 4;
                            }
                            else
                            {
                                obsData.IdStatus = 2;
                            }
                    }

                    if (obs.IdStatus == 2)
                    {
                        obsData.DateSend = DateTime.Now;
                    }

                }

                _db.SaveChanges();

                return Json(new { obs = obs, status = "Success" });
            }

            return View(obs);

        }

        [HttpPost]
        public IActionResult SaveDataObserver([FromBody] ObserverRequest req)
        {
            var obs = req.Obs;

            var typeAction = obs.Id == 0 ? "add" : "update";

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 1) Provjera kandidat
            var candsCheck = _db.CandidatesViews.FirstOrDefault(a => a.JMB == obs.JMBG);

            Data_AOPerson obsData;
            if (typeAction == "update")
            {
                obsData = _db.Data_AOPersons.FirstOrDefault(a => a.Id == obs.Id);
                if (obsData == null) return NotFound();
            }
            else
            {
                obsData = new Data_AOPerson
                {
                    AccreditationObserverId = obs.AccreditationObserverId,
                    IdUserInserted = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    DateInserted = DateTime.Now
                };
                _db.Data_AOPersons.Add(obsData);
            }

            obsData.LastName = obs.LastName;
            obsData.FirstName = obs.FirstName;
            obsData.JMBG = obs.JMBG;
            obsData.IdentityId = obs.IdentityId;
            obsData.Passport = obs.Passport;
            if (!string.IsNullOrEmpty(obs.Passport) && string.IsNullOrEmpty(obs.JMBG))
                obsData.JMBG = obs.Passport;
            obsData.CountryId = obs.CountryId;
            obsData.Language = obs.Language;
            obsData.Approved = obs.Approved;

            if (!User.IsInRole("CAND_Korisnik") && !User.IsInRole("OBS_Korisnik") && !User.IsInRole("PS_Korisnik"))
                obsData.ReasonRejected = obs.ReasonRejected;


            switch (req.Scope)
            {
                case "CIK": obsData.CIK = true; break;
                case "OIK": obsData.OIK = true; break;
                case "CBS": obsData.CBS = true; break;
                case "BM": obsData.BM = true; break;
                case "GCB": obsData.GCB = true; break;
                case "DKP": obsData.DKP = true; break;
            }


            obsData.IsCandidate = (candsCheck != null);
            //2.Provjera duplikata
            var duplicateCheck = _db.Data_AOPersons
                .FirstOrDefault(a => a.JMBG == obs.JMBG && a.Id != obsData.Id);

            obsData.IsDuplicate = (duplicateCheck != null);

            obsData.Approved = !obsData.IsCandidate && obsData.IsDuplicate != true;

            if (typeAction == "update")
            {
                obsData.IdUserUpdated = User.FindFirstValue(ClaimTypes.NameIdentifier);
                obsData.DateUpdated = DateTime.Now;
            }

            _db.SaveChanges();

            if (req.MunicipalityId >0)
            {
                var muniId = req.MunicipalityId.Value;
                var userMuniId = _dbidentity.AspNetUsers.Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();

                var exists = _db.Data_AOPersonMunicipalities
                    .FirstOrDefault(x => x.AccreditationObserverPersonId == obsData.Id
                                      && x.MunicipalitiesId == req.MunicipalityId.Value);

                if (exists == null)
                {
                    _db.Data_AOPersonMunicipalities.Add(new Data_AOPersonMunicipality
                    {
                        AccreditationObserverPersonId = obsData.Id,
                        MunicipalitiesId = User.IsInRole("OBS_Oik") ? userMuniId.IdMunicipality : req.MunicipalityId.Value
                    });
                    _db.SaveChanges();
                }
            }

            if (req.DkpId>0)
            {
                if (req.DkpId == null || req.DkpId <= 0)
                    return Json(new { status = "Error", message = "DkpId is required for DKP." });

                var exists = _db.Data_AOPersonDkps
                    .FirstOrDefault(x => x.AccreditationObserverPersonId == obsData.Id
                                      && x.DkpId == req.DkpId.Value);

                if (exists == null)
                {
                    _db.Data_AOPersonDkps.Add(new Data_AOPersonDkp
                    {
                        AccreditationObserverPersonId = obsData.Id,
                        DkpId = req.DkpId.Value
                    });
                    _db.SaveChanges();
                }
            }

            var user = _dbidentity.AspNetUsers.FirstOrDefault(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            List<AOPersonsView> ObserverPersons;
            if (User.IsInRole("OBS_Oik"))
            {
                ObserverPersons = _db.AOPersonsViews
                    .FromSqlInterpolated($"GetObserverPersonsOik {obs.AccreditationObserverId},{user.IdMunicipality}")
                    .AsEnumerable().ToList();
            }
            else
            {
                ObserverPersons = _db.AOPersonsViews
                    .FromSqlInterpolated($"GetObserverPersons {obs.AccreditationObserverId}")
                    .AsEnumerable().ToList();
            }

            return Json(new
            {
                obs = obsData,
                typeAction = typeAction,
                observerPersons = ObserverPersons,
                status = "Success"
            });
        }

        [HttpPost]
        public IActionResult ToggleApproved(int id, bool approved)
        {
            var obsData = _db.Data_AOPersons.FirstOrDefault(x => x.Id == id);
            if (obsData == null)
                return NotFound();

            obsData.Approved = approved;
            obsData.IdUserUpdated = User.FindFirstValue(ClaimTypes.NameIdentifier);
            obsData.DateUpdated = DateTime.Now;

            _db.SaveChanges();

            return Json(new
            {
                status = "Success",
                id = obsData.Id,
                approved = obsData.Approved
            });
        }

        [HttpPost]
        public IActionResult DeleteDataObserver(int id)
        {
            try
            {
                var data = _db.Data_AOPersons.FirstOrDefault(a => a.Id == id);
                if (data == null)
                    return Json(new { success = "notfound" });

                var accreditationObserverId = data.AccreditationObserverId;

                var muni = _db.Data_AOPersonMunicipalities
                    .Where(x => x.AccreditationObserverPersonId == id)
                    .ToList();

                if (muni.Any())
                    _db.Data_AOPersonMunicipalities.RemoveRange(muni);

                var dkp = _db.Data_AOPersonDkps
                    .Where(x => x.AccreditationObserverPersonId == id)
                    .ToList();

                if (dkp.Any())
                    _db.Data_AOPersonDkps.RemoveRange(dkp);


                _db.Data_AOPersons.Remove(data);

                _db.SaveChanges();

                var user = _dbidentity.AspNetUsers
                    .FirstOrDefault(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

                List<AOPersonsView> obsPersons;

                if (User.IsInRole("OBS_Oik"))
                {
                    obsPersons = _db.AOPersonsViews
                        .FromSqlInterpolated($"GetObserverPersonsOik {accreditationObserverId},{user.IdMunicipality}")
                        .AsEnumerable().ToList();
                }
                else
                {
                    obsPersons = _db.AOPersonsViews
                        .FromSqlInterpolated($"GetObserverPersons {accreditationObserverId}")
                        .AsEnumerable().ToList();
                }

                return Json(new { observerPersons = obsPersons, success = "success" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Dashboard DeleteDataObserver: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        public void DeleteFile(int id)
        {
            try
            {
                var document = _db.Data_AODocuments.Where(a => a.Id == id).FirstOrDefault();
                if (document != null)
                {
                    string path = string.Format(@"{0}/{1}", hostingEnv.ContentRootPath, document.DocumentPath);
                    FileInfo file = new FileInfo(path);

                    if (file.Exists)
                    {
                        file.Delete();
                        _db.Data_AODocuments.Remove(document);
                        _db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
            }
        }

        [AllowAnonymous]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
        [AllowAnonymous]
        public IActionResult LogoutJS()
        {
            _signInManager.SignOutAsync();
            return Json(new { url = "/Home/Index" });
        }

        public IActionResult GetMenu()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicationId = 3;

            var pageIds = (
                from ur in _dbidentity.AspNetUserRoles
                join r in _dbidentity.AspNetRoles
                    on ur.RoleId equals r.Id
                join pr in _dbidentity.Pages2Roles
                    on r.RoleId equals pr.RoleId
                where ur.UserId == userId
                   && r.ApplicationId == applicationId
                select pr.PageId
            )
            .Distinct();

            var pages = _dbidentity.ViewPages
                .Where(p => pageIds.Contains(p.Id))
                .ToList();

            var groupIds = pages
                .Select(p => p.PageGroupId)
                .Distinct()
                .ToList();

            var groups = _dbidentity.PageGroups
                .Where(g => groupIds.Contains(g.Id))
                .OrderByDescending(g => g.Id)
                .ToList();

            return Json(new
            {
                groups,
                pages
            });
        }

        public IActionResult RotateFile(int doctype, string path, int angle)
        {
            var pathdoc = string.Format("{0}{1}", hostingEnv.ContentRootPath, path);

            PdfDocument finalDoc = new PdfDocument();
            FileStream stream1 = new FileStream(pathdoc, FileMode.Open, FileAccess.Read);
            PdfLoadedDocument ldocument = new PdfLoadedDocument(stream1);
            finalDoc.ImportPageRange(ldocument, 0, ldocument.Pages.Count - 1);

            if (angle == 1)
                finalDoc.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90;

            if (angle == 2)
                finalDoc.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle180;

            if (angle == 3)
                finalDoc.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle270;

            MemoryStream stream = new MemoryStream();

            finalDoc.Save(stream);
            stream.Position = 0;
            finalDoc.Close(true);


            string fileName = string.Format("{0}_{1}_{2}.pdf", Guid.NewGuid().ToString(), "RotatedOBS", (angle * 90).ToString());

            string pathreturn = "";
            int index = path.LastIndexOf("/");
            if (index >= 0)
                pathreturn = path.Substring(0, index);

            string pathDoc = string.Format("{0}{1}", hostingEnv.ContentRootPath, pathreturn);

            System.IO.DirectoryInfo di = new DirectoryInfo(pathDoc);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            foreach (FileInfo file in di.GetFiles())
            {
                if (file.Name.Contains("_RotatedOBS_"))
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception e)
                    {

                    }

                }
            }

            System.IO.File.WriteAllBytes(hostingEnv.ContentRootPath + pathreturn + "/" + fileName, stream.ToArray());
            stream.Dispose();

            return Json(new { result = "success", path = pathreturn + "/" + fileName });
        }

        [HttpPost]
        public IActionResult GetObserverPersonMunicipalities(int Id)
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            var muni = _db.AOPersonMunicipalities.Where(a => a.Id == Id).ToList();
            foreach (var m in muni)
            {
                m.NameLatin = (culture.Name == "bs-Cyrl-BA") ? m.NameCyrillic : m.NameLatin;
            }
            return Json(new { muni = muni });
        }

        [HttpPost]
        public IActionResult GetObserverPersonDkp(int Id)
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            var dkp = _db.AOPersonDkps.Where(a => a.Id == Id).ToList();
            foreach (var d in dkp)
            {
                d.NameBs = (culture.Name == "bs-Cyrl-BA") ? d.NameSr : d.NameBs;
            }

            return Json(new { dkp = dkp });
        }

        [HttpPost]
        public IActionResult InsertObserverPersonMuni(int IdMuni, int IdPerson)
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            var muniExist = _db.Data_AOPersonMunicipalities.Where(a => a.MunicipalitiesId == IdMuni && a.AccreditationObserverPersonId == IdPerson).FirstOrDefault();
            if (muniExist == null)
            {
                Data_AOPersonMunicipality obs = new Data_AOPersonMunicipality();
                obs.MunicipalitiesId = IdMuni;
                obs.AccreditationObserverPersonId = IdPerson;

                _db.Data_AOPersonMunicipalities.Add(obs);
                _db.SaveChanges();
            }
            var muni = _db.AOPersonMunicipalities.Where(a => a.Id == IdPerson).ToList();

            foreach (var m in muni)
            {
                m.NameLatin = (culture.Name == "bs-Cyrl-BA") ? m.NameCyrillic : m.NameLatin;
            }

            return Json(new { muni = muni });

        }

        public IActionResult DeleteObserverPersonMunicipalities(int Id, int IdPerson)
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            var muni = _db.Data_AOPersonMunicipalities.Where(a => a.Id == Id).FirstOrDefault();
            _db.Data_AOPersonMunicipalities.Remove(muni);
            _db.SaveChanges();
            var muniList = _db.AOPersonMunicipalities.Where(a => a.Id == IdPerson).ToList();
            foreach (var m in muniList)
            {
                m.NameLatin = (culture.Name == "bs-Cyrl-BA") ? m.NameCyrillic : m.NameLatin;
            }
            return Json(new { muni = muniList });
        }

        [HttpPost]
        public IActionResult InsertObserverPersonDkp(int IdDkp, int IdPerson)
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            var muniExist = _db.Data_AOPersonDkps.Where(a => a.DkpId == IdDkp && a.AccreditationObserverPersonId == IdPerson).FirstOrDefault();
            if (muniExist == null)
            {
                Data_AOPersonDkp obs = new Data_AOPersonDkp();
                obs.DkpId = IdDkp;
                obs.AccreditationObserverPersonId = IdPerson;

                _db.Data_AOPersonDkps.Add(obs);
                _db.SaveChanges();
            }
            var dkp = _db.AOPersonDkps.Where(a => a.Id == IdPerson).ToList();
            foreach (var d in dkp)
            {
                d.NameBs = (culture.Name == "bs-Cyrl-BA") ? d.NameSr : d.NameBs;
            }
            return Json(new { dkp = dkp });

        }

        public IActionResult DeleteObserverPersonDkp(int Id, int IdPerson)
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            var dkp = _db.Data_AOPersonDkps.Where(a => a.Id == Id).FirstOrDefault();
            _db.Data_AOPersonDkps.Remove(dkp);
            _db.SaveChanges();
            var dkpList = _db.AOPersonDkps.Where(a => a.Id == IdPerson).ToList();
            return Json(new { dkp = dkpList });
        }


        [HttpPost]
        public void ChangeStatus(int id, int idstatus)
        {
            var obsData = _db.Data_AOs.Where(a => a.Id == id).FirstOrDefault();

            if (idstatus == 5)
            {
                var obsHistory = _db.Data_AORequests.Where(a => a.IdAO == id).FirstOrDefault();
                if (obsHistory == null)
                {
                    obsHistory = new Data_AORequest
                    {
                        IdAO = id,
                        IdStatus = obsData.IdStatus,
                        IdReason = obsData.IdReason,
                        DateSend = obsData.DateSend,
                        IdUserInserted = User.Identity.Name,
                        DateInserted = DateTime.Now,
                        Comment=obsData.Comment
                    };
                    _db.Data_AORequests.Add(obsHistory);
                }

                idstatus = 1;
            }

            if (obsData != null)
            {
                obsData.IdStatus = idstatus;
                _db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDataCbs(string jmbg)
        {
            try
            {
                if (string.IsNullOrEmpty(jmbg))
                    return BadRequest("JMBG is required");

                var person = await _cbsdb.VoterOnlines
                    .Where(x => x.RegId == jmbg)
                    .Select(x => new
                    {
                        RegId = x.RegId,
                        FirstName = x.FirstName,
                        LastName = x.LastName
                    })
                    .FirstOrDefaultAsync();

                if (person == null)
                    return NotFound("Person not found");

                return Json(person);
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                _logger.LogError(ex, "SQL ERROR in GetDataCbs for JMBG {Jmbg}", jmbg);

                return StatusCode(500, new
                {
                    message = "Greška pri pristupu CBS bazi."
                });
            }
            catch (Exception ex)
            {
                // sve ostalo
                _logger.LogError(ex, "GENERAL ERROR in GetDataCbs for JMBG {Jmbg}", jmbg);

                return StatusCode(500, new
                {
                    message = "Neočekivana greška."
                });
            }
        }


        private static string BuildDecisionNumber(string protocolNo, int seq)
        {
            if (string.IsNullOrWhiteSpace(protocolNo))
                return null;

            protocolNo = protocolNo.Trim();

            var parts = protocolNo.Split('/');
            if (parts.Length != 2)
                return $"{protocolNo}-{seq}";

            var protocol = parts[0];
            var year = parts[1];

            return $"{protocol}-{seq}/{year}";
        }

        [HttpPost]
        public IActionResult SaveDecision([FromBody] DecisionRequest req)
        {
            try
            {
                if (req.AccreditationObserverId <= 0)
                    return Json(new { status = "Error", message = "Invalid observer id" });

                var ao = _db.Data_AOs.FirstOrDefault(x => x.Id == req.AccreditationObserverId);
                if (ao == null)
                    return Json(new { status = "Error", message = "Observer not found" });

                var protocolNo = ao.NoOfDecision;
                if (string.IsNullOrWhiteSpace(protocolNo))
                    return Json(new { status = "Error", message = "Broj protokola nije unesen." });

                var maxSeq = _db.Data_AODecisions
                    .Where(x => x.AccreditationObserverId == req.AccreditationObserverId)
                    .Select(x => (int?)x.Sequence)
                    .Max() ?? 0;

                var nextSeq = maxSeq + 1;
                var decisionNo = BuildDecisionNumber(protocolNo, nextSeq);

                var dec = new Data_AODecision
                {
                    AccreditationObserverId = req.AccreditationObserverId,
                    DecisionDate = req.DecisionDate,
                    SessionNumber = req.SessionNumber,
                    Sequence = nextSeq,
                    DecisionNumber = decisionNo,
                    DecisionTypeId = req.DecisionTypeId
                };

                _db.Data_AODecisions.Add(dec);
                _db.SaveChanges();

                if (req.DecisionTypeId == 1) { 
                    // 1) uzmi samo one koji su odobreni, a NEMAJU još DecisionId
                    var newlyApproved = _db.Data_AOPersons
                        .Where(p => p.AccreditationObserverId == req.AccreditationObserverId
                                 //&& p.Approved == true
                                 && (p.DecisionId == null || p.DecisionId == 0))
                        .ToList();

                    // 2) dodijeli ovu odluku samo njima
                    foreach (var p in newlyApproved)
                    {
                        p.DecisionId = dec.Id;
                    }

                    // 3) u odluci upiši broj posmatrača koji su baš sada “uhvaćeni”
                    dec.NumberOfPerson = newlyApproved.Count(p => p.Approved == true);
                }
                // (opciono) audit za odluku
                dec.IdUserInserted = User.FindFirstValue(ClaimTypes.NameIdentifier);
                dec.DateInserted = DateTime.Now;

                _db.SaveChanges();

                var decisions = _db.Data_AODecisions
                    .Where(x => x.AccreditationObserverId == req.AccreditationObserverId)
                    .OrderByDescending(x => x.Sequence)
                    .ToList();

                return Json(new { status = "Success", decision = dec, decisions = decisions });
            }
            catch (Exception ex)
            {
                _logger.LogError($"SaveDecision error: {ex}");
                return StatusCode(500, new { status = "Error", message = "Internal server error" });
            }
        }

        [HttpPost]
        public IActionResult GetNextDecisionInfo(int accreditationObserverId)
        {
            var ao = _db.Data_AOs.FirstOrDefault(x => x.Id == accreditationObserverId);
            if (ao == null)
                return Json(new { status = "Error", message = "Not found" });

            var protocolNo = ao.NoOfDecision;

            var maxSeq = _db.Data_AODecisions
                .Where(x => x.AccreditationObserverId == accreditationObserverId)
                .Select(x => (int?)x.Sequence)
                .Max() ?? 0;

            var nextSeq = maxSeq + 1;
            var decisionNo = BuildDecisionNumber(protocolNo, nextSeq);

            // ⭐ posmatrači koji će ući u ovu odluku
            var numberOfPersons = _db.Data_AOPersons
                .Count(p => p.AccreditationObserverId == accreditationObserverId
                         && p.Approved == true
                         && (p.DecisionId == null || p.DecisionId == 0));

            return Json(new
            {
                status = "Success",
                protocolNo = protocolNo,
                sequence = nextSeq,
                decisionNumber = decisionNo,
                numberOfPersons = numberOfPersons
            });
        }

[HttpPost]
    public IActionResult GetDecisionPersonsPreview([FromBody] DataManagerRequest dm, int accreditationObserverId)
    {
        // Query: samo oni koji će biti ovjereni ovom odlukom
        var query = _db.Data_AOPersons
            .Where(p => p.AccreditationObserverId == accreditationObserverId
                     && p.Approved == true
                     && (p.DecisionId == null || p.DecisionId == 0))
            .Select(p => new
            {
                p.Id,
                p.LastName,
                p.FirstName,
                p.JMBG,
                p.IdentityId,
                p.Language
            })
            .AsQueryable();

        var count = query.Count();

        // DataOperations: paging/sorting/filter
        var dataOps = new DataOperations();
        IEnumerable<dynamic> data = query;

        if (dm.Where != null && dm.Where.Count > 0)
            data = dataOps.PerformFiltering(data, dm.Where, dm.Where[0].Operator);

        if (dm.Sorted != null && dm.Sorted.Count > 0)
            data = dataOps.PerformSorting(data, dm.Sorted);

        if (dm.Skip != 0)
            data = dataOps.PerformSkip(data, dm.Skip);

        if (dm.Take != 0)
            data = dataOps.PerformTake(data, dm.Take);

        return Json(new { result = data, count = count });
    }

        [HttpPost]
        public IActionResult UpdateObserverStatus([FromBody] ObserverStatusRequest req)
        {
            var obsData = _db.Data_AOPersons.FirstOrDefault(x => x.Id == req.Id);
            if (obsData == null)
                return NotFound();

            obsData.Approved = req.Approved;
            obsData.IdReason = req.IdReason;

            // po želji možeš i ReasonRejected tekst povući iz lookup tabele
            var reason = _db.LookUp_RejectionReasons.FirstOrDefault(x => x.Id == req.IdReason);
            obsData.ReasonRejected = reason != null ? reason.NameBs : null;

            obsData.IdUserUpdated = User.FindFirstValue(ClaimTypes.NameIdentifier);
            obsData.DateUpdated = DateTime.Now;

            _db.SaveChanges();

            var user = _dbidentity.AspNetUsers.FirstOrDefault(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            List<AOPersonsView> observerPersons;
            if (User.IsInRole("OBS_Oik"))
            {
                observerPersons = _db.AOPersonsViews
                    .FromSqlInterpolated($"GetObserverPersonsOik {obsData.AccreditationObserverId},{user.IdMunicipality}")
                    .AsEnumerable()
                    .ToList();
            }
            else
            {
                observerPersons = _db.AOPersonsViews
                    .FromSqlInterpolated($"GetObserverPersons {obsData.AccreditationObserverId}")
                    .AsEnumerable()
                    .ToList();
            }

            return Json(new
            {
                status = "Success",
                observerPersons = observerPersons
            });
        }

    }
}