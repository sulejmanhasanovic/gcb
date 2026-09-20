using Administration.Models;
using Administration.Services;
using Administration.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

using System.Security.Claims;
using System;

namespace Administration.Controllers
{
    //[Authorize(Roles = "IM_Admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private IdentityManagerContext _db;
        private ElectionRepositoryContext _dbER;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer<AdminController> _stringLocalizer;
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly IEmailService _mailer;
        public AdminController(
            IdentityManagerContext db,
            ElectionRepositoryContext dbER,
            UserManager<IdentityUser> userManager, 
            ILogger<AdminController> logger, 
            IConfiguration configuration,
            IStringLocalizer<AdminController> stringLocalizer, 
            IEmailConfiguration emailConfiguration,
            IEmailService mailer)
        {
            _logger = logger;
            _db = db;
            _dbER = dbER;
            _userManager = userManager;
            _configuration = configuration;
            _emailConfiguration = emailConfiguration;
            _stringLocalizer = stringLocalizer;
            _mailer = mailer;
        }

        public IActionResult Index()
        {
            if (!User.IsInRole("MEC_Admin"))
            {
                List<AspNetRole> roles = _db.AspNetRoles.ToList();
                ViewBag.roles = roles;
                ViewBag.parties = _db.ViewPoliticalEntities.ToList();
                ViewBag.observers = _db.ViewObservers.ToList();
                ViewBag.Municipalities = _dbER.EIzboriMunicipalitiesViews.ToList();
                ViewBag.Organizations = _db.ComplaintsOrganizationsViews.ToList();

                //ViewBag.parties1 = JsonConvert.SerializeObject(_db.ViewPoliticalEntities.Select(x => new SelectListItem() { Text = x.NameOnballot, Value = x.Id.ToString() }).ToList());
                //ViewBag.observers1 = JsonConvert.SerializeObject(_db.ViewObservers.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());
                //ViewBag.Municipalities1 = JsonConvert.SerializeObject(_db.ViewMunicipalities.Select(x => new SelectListItem() { Text = x.NameLatin, Value = x.Id.ToString() }).ToList());

                //ViewBag.users = _db.ManageUsers.OrderBy(a => a.Email).ToList();

                ViewBag.usersPRP = _db.UsersByAppViews.Where(a => a.ApplicationId == 1).Take(20).ToList();
                //ViewBag.usersPRP = new List<UsersByAppView>();
                ViewBag.rolesPRP = JsonConvert.SerializeObject(roles.Where(a => a.ApplicationId == 1).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());

                ViewBag.usersCAND = _db.UsersByAppViews.Where(a => a.ApplicationId == 2).OrderBy(a => a.PartyId).ToList();
                ViewBag.rolesCAND = JsonConvert.SerializeObject(roles.Where(a => a.ApplicationId == 2).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());


                ViewBag.usersOBS = _db.UsersByAppViews.Where(a => a.ApplicationId == 3).OrderBy(a => a.IdObs).ToList();
                ViewBag.rolesOBS = JsonConvert.SerializeObject(roles.Where(a => a.ApplicationId == 3).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());

                ViewBag.usersPS = _db.UsersByAppViews.Where(a => a.ApplicationId == 5).OrderBy(a => a.PartyId).ToList();
                ViewBag.rolesPS = JsonConvert.SerializeObject(roles.Where(a => a.ApplicationId == 5).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());

                ViewBag.usersBOO = _db.UsersByAppViews.Where(a => a.ApplicationId == 6).Take(2).ToList();
                //ViewBag.usersBO = new List<UsersByAppView>();
                ViewBag.rolesBOO = JsonConvert.SerializeObject(roles.Where(a => a.ApplicationId == 6).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());

                ViewBag.usersBO = _db.UsersByAppViews.Where(a => a.ApplicationId == 7).ToList();
                //ViewBag.usersBO = new List<UsersByAppView>();
                ViewBag.rolesBO = JsonConvert.SerializeObject(roles.Where(a => a.ApplicationId == 7).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());

                //ViewBag.usersMEC = _db.UsersByAppViews.Where(a => a.ApplicationId == 7 && a.RoleName == "BO_MEC").OrderBy(a => a.IdMunicipality).ToList();
                //ViewBag.rolesMEC = JsonConvert.SerializeObject(roles.Where(a => a.ApplicationId == 7 && a.Name == "BO_MEC").Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());

                ViewBag.usersADMINS = _db.UsersByAppViews.Where(a => a.ApplicationId == 9).ToList();
                ViewBag.rolesADMINS = JsonConvert.SerializeObject(roles.Where(a => a.ApplicationId == 9).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());


                ViewBag.usersCOM = _db.UsersByAppViews.Where(a => a.ApplicationId == 8).ToList();
                ViewBag.rolesCOM = JsonConvert.SerializeObject(roles.Where(a => a.ApplicationId == 8).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());

            }
            else if (User.IsInRole("MEC_Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var munId = _db.AspNetUsers.Where(a => a.Id == userId).Select(a => a.IdMunicipality).FirstOrDefault();
                EIzboriMunicipalitiesView munData = _dbER.EIzboriMunicipalitiesViews.Where(a=>a.Id == munId).FirstOrDefault();
                List<AspNetRole> roles = _db.AspNetRoles.ToList();
                ViewBag.roles = roles;
                ViewBag.munData = munData;
                ViewBag.Municipalities = _dbER.EIzboriMunicipalitiesViews.ToList();
                ViewBag.usersBO_MEC = _db.UsersByAppViews.Where(a => a.ApplicationId == 7 && a.RoleName == "BO_MEC" && a.IdMunicipality == munId).ToList();
                ViewBag.rolesBO_MEC = JsonConvert.SerializeObject(roles.Where(a => a.ApplicationId == 7 && a.Name == "BO_MEC").Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());

                ViewBag.usersCOM_MEC = _db.UsersByAppViews.Where(a => a.ApplicationId == 8 && a.RoleName == "COM_MEC_Korinsik" && a.IdMunicipality == munId).ToList();
                ViewBag.rolesCOM_MEC = JsonConvert.SerializeObject(roles.Where(a => a.ApplicationId == 8 && a.Name == "COM_MEC_Korinsik").Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());
                //ViewBag.usersMEC = _db.UsersByAppViews.Where(a => a.ApplicationId == 7).OrderBy(a => a.IdMunicipality).ToList();
                //ViewBag.rolesMEC = JsonConvert.SerializeObject(roles.Where(a => a.ApplicationId == 7).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());

            }
            return View();

        }

        public ActionResult UpdateUser(ManageUser user)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                AspNetUser userupdate = _db.AspNetUsers.Where(or => or.Id == user.Id).FirstOrDefault();
                userupdate.AccessFailedCount = user.AccessFailedCount;
                userupdate.LockoutEnd = user.LockoutEnd;
                userupdate.FirstLog = user.FirstLog;
                userupdate.EmailConfirmed = user.EmailConfirmed;
                userupdate.PartyId = user.PartyId;
                userupdate.IdObs=user.IdObs;
                userupdate.IdMunicipality = user.IdMunicipality;

            if (!string.IsNullOrEmpty(user.RoleId))
                {
                    var role = _db.AspNetUserRoles.Where(a => a.UserId == user.Id).FirstOrDefault();
                    _db.AspNetUserRoles.Remove(role);
                    AspNetUserRole newrole = new AspNetUserRole();
                    newrole.UserId = user.Id;
                    newrole.RoleId = user.RoleId;
                    _db.AspNetUserRoles.Add(newrole);
                }
                try
                {
                    _db.SaveChanges();
                     return Json(new { response = "Success" });
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error Admin update user:{0}", ex.ToString());
                    return Json(new { response = "Error" });
                }
            }

        public async Task<JsonResult> InsertUserOLD(string email, string idRole, string idParty, string idObs)
        {
            try
            {
                var userExist = _db.AspNetUsers.Where(a => a.UserName == email).FirstOrDefault();
                if (userExist == null)
                {
                    if (!string.IsNullOrEmpty(email))
                    {
                        var user = CreateUser();
                        user.UserName = email;
                        user.Email = email;
                        user.EmailConfirmed = true;
                        string defaultPass = Administration.Helpers.GeneratePass.GenerateRandomPassword();
                        var result = await _userManager.CreateAsync(user, defaultPass);

                        var userId = await _userManager.GetUserIdAsync(user);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                        if (result.Succeeded)
                        {
                            AspNetUserRole newrole = new AspNetUserRole();
                            newrole.UserId = user.Id;
                            newrole.RoleId = idRole;
                            _db.AspNetUserRoles.Add(newrole);
                            _db.SaveChanges();

                            if (!string.IsNullOrEmpty(idParty))
                            {
                                int idp= int.Parse(idParty);
                                var u = _db.AspNetUsers.Where(a => a.UserName == email).FirstOrDefault();
                                u.PartyId = idp;
                                _db.SaveChanges();
                            }


                            if (!string.IsNullOrEmpty(idObs))
                            {
                                int idobs=int.Parse(idObs);
                                var u = _db.AspNetUsers.Where(a => a.UserName == email).FirstOrDefault();
                                u.IdObs= idobs;
                                _db.SaveChanges();                          
                            }


                            var callbackUrl = Url.Page(
                                  "/Account/ConfirmEmail",
                                  pageHandler: null,
                                  values: new { area = "Identity", userId = userId, code = code },
                                  protocol: Request.Scheme);

                                EmailMessage em = new EmailMessage();
                                em.Subject = _stringLocalizer["Potvrda prijave i pristupni podaci"];
                                em.Content = String.Format(
                                    @_stringLocalizer["Potvrda prijave i pristupni podaci mail"],
                                    email, defaultPass, callbackUrl);
                                em.FromAddresses = new List<EmailAddress>
                                    {
                                        new EmailAddress{ Name=_stringLocalizer["Centralna izborna komisija Bosne i Hercegovine"], Address=_emailConfiguration.EmailFrom}
                                    };
                                em.ToAddresses = new List<EmailAddress>
                                    {
                                        new EmailAddress{ Name=string.Format("{0}", email), Address=email}
                                    };

                                _mailer.Send(em);

                        }
                    }
                    else
                    {
                        return new JsonResult(new { response = "Error" });
                    }
                   
                }
                else
                {
                    return Json(new { response = "Exist" });
                }

                return new JsonResult(new { response = "Success" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { response = "Error" });
                _logger.LogError("Create CIK user:{0}", ex.ToString());
            }
        }

        public async Task<JsonResult> InsertUser(UsersByAppView data)
        {
            try
            {
                var userExist = _db.AspNetUsers.Where(a => a.UserName == data.Email).FirstOrDefault();
                string roleName = _db.AspNetRoles.Where(a=>a.Id == data.RoleId).Select(a=>a.Name).FirstOrDefault();
                if (userExist == null)
                {
                    if (!string.IsNullOrEmpty(data.Email))
                    {
                        var user = CreateUser();
                        user.UserName = data.Email;
                        user.Email = data.Email;
                        user.EmailConfirmed = true;
                        string defaultPass = Administration.Helpers.GeneratePass.GenerateRandomPassword();
                        var result = await _userManager.CreateAsync(user, defaultPass);

                        var userId = await _userManager.GetUserIdAsync(user);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                        if (result.Succeeded)
                        {
                            AspNetUserRole newrole = new AspNetUserRole();
                            newrole.UserId = user.Id;
                            newrole.RoleId = data.RoleId;
                            _db.AspNetUserRoles.Add(newrole);
                            _db.SaveChanges();

                            if (data.PartyId != null)
                            {
                                var u = _db.AspNetUsers.Where(a => a.UserName == data.Email).FirstOrDefault();
                                u.PartyId = data.PartyId;
                                _db.SaveChanges();
                            }


                            if (data.IdObs != null)
                            {
                                var u = _db.AspNetUsers.Where(a => a.UserName == data.Email).FirstOrDefault();
                                u.IdObs = data.IdObs;
                                _db.SaveChanges();
                            }

                            else if (User.IsInRole("MEC_Admin"))
                            {
                                var mecAdminId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                                var munId = _db.AspNetUsers.Where(a => a.Id == mecAdminId).Select(a => a.IdMunicipality).FirstOrDefault();
                                EIzboriMunicipalitiesView munData = _dbER.EIzboriMunicipalitiesViews.Where(a => a.Id == munId).FirstOrDefault();
                                var u = _db.AspNetUsers.Where(a => a.UserName == data.Email).FirstOrDefault();
                                u.IdMunicipality = munData.Id;
                                _db.SaveChanges();
                            }

                            if (data.IdMunicipality != null)
                            {
                                var u = _db.AspNetUsers.Where(a => a.UserName == data.Email).FirstOrDefault();
                                u.IdMunicipality = data.IdMunicipality;
                                _db.SaveChanges();
                            }
                            if (data.OrgId != null)
                            {
                                var u = _db.AspNetUsers.Where(a => a.UserName == data.Email).FirstOrDefault();
                                u.OrgId = data.OrgId;
                                _db.SaveChanges();
                            }


                            var callbackUrl = Url.Page(
                                  "/Account/ConfirmEmail",
                                  pageHandler: null,
                                  values: new { area = "Identity", userId = userId, code = code },
                                  protocol: Request.Scheme);

                            EmailMessage em = new EmailMessage();
                            em.Subject = _stringLocalizer["Potvrda prijave i pristupni podaci"];
                            em.Content = String.Format(
                                @_stringLocalizer["Potvrda prijave i pristupni podaci mail"],
                                data.Email, defaultPass, callbackUrl);
                            em.FromAddresses = new List<EmailAddress>
                                    {
                                        new EmailAddress{ Name=_stringLocalizer["Centralna izborna komisija Bosne i Hercegovine"], Address=_emailConfiguration.EmailFrom}
                                    };
                            em.ToAddresses = new List<EmailAddress>
                                    {
                                        new EmailAddress{ Name=string.Format("{0}", data.Email), Address=data.Email}
                                    };

                            _mailer.Send(em);

                        }
                    }
                    else
                    {
                        return new JsonResult(new { response = "Error", msg = "Došlo je do greške prilikom kreiranja korisnika." });
                    }

                }
                else
                {
                    return Json(new { response = "Exist", msg = "Korisnik sa ovim email-om već postoji." });
                }

                int? appId;
                bool isMec = false;
                List<UsersByAppView> gridData = new List<UsersByAppView>();
                appId = _db.AspNetRoles.Where(a => a.Id == data.RoleId).Select(a => a.ApplicationId).FirstOrDefault();
                //ovdje trebamo vratiti korisnike jer nemamo id u gridu i yato e readi change password ili edit ako ne uradimo refresh
                if (!User.IsInRole("MEC_Admin"))
                {
                    
                    gridData = _db.UsersByAppViews.Where(a => a.ApplicationId == appId).ToList();
                }
                else
                {
                    isMec = true;
                    var mecAdminId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var munId = _db.AspNetUsers.Where(a => a.Id == mecAdminId).Select(a => a.IdMunicipality).FirstOrDefault();
                    gridData = _db.UsersByAppViews.Where(a => a.ApplicationId == 7 && a.RoleName == "BO_MEC" && a.IdMunicipality == munId).ToList();
                }


                return new JsonResult(new { response = "Success", msg="Uspješno ste dodali korisnika.", gridData= gridData, appId= appId, isMec=isMec });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { response = "Error" });
                _logger.LogError("Create CIK user:{0}", ex.ToString());
            }
        }

        public async Task<IdentityResult> ChangePassword(string userId)
        {
            try
            {

                IdentityUser user = await _userManager.FindByIdAsync(userId);
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                string defaultPass = _configuration.GetValue<string>("AppSettings:DefaultPass");
                IdentityResult passwordChangeResult = await _userManager.ResetPasswordAsync(user, resetToken, _configuration.GetValue<string>("AppSettings:DefaultPass"));
                if (passwordChangeResult.Succeeded)
                {
                    var fl = new FirstLogin(_db);
                    fl.setFirstLog(user.Email, true);

                    //posalji email
                    EmailMessage em = new EmailMessage();
                    em.Subject = _stringLocalizer["Promjena lozinke i pristupni podaci"];
                    em.Content = String.Format(
                        @_stringLocalizer["Potvrda prijave i pristupni podaci mail"],
                        user.Email, defaultPass);

                    em.FromAddresses = new List<EmailAddress>
                                    {
                                        new EmailAddress{ Name=_stringLocalizer["Centralna izborna komisija Bosne i Hercegovine"], Address=_emailConfiguration.EmailFrom}
                                    };
                    em.ToAddresses = new List<EmailAddress>
                                    {
                                        new EmailAddress{ Name=string.Format("{0}", user.Email), Address=user.Email}
                                    };

                    _mailer.Send(em);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Change password in Account Controller {0}", ex.ToString());
            }
            return null;
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        public IActionResult GetPRPUsers()
        {
            try
            {

                List<UsersByAppView>  usersPRP = _db.UsersByAppViews.Where(a => a.ApplicationId == 1).ToList();
 
                return Json(new { response = "Success", gridData = usersPRP });
            }
            catch (Exception ex)
            {
                return  Json(new { response = "Error" });
                _logger.LogError("Create CIK user:{0}", ex.ToString());
            }
        }

        public IActionResult GetBOOUsers()
        {
            try
            {

                List<UsersByAppView> usersBOO = _db.UsersByAppViews.Where(a => a.ApplicationId == 6).ToList();

                return  Json(new { response = "Success", gridData = usersBOO });
            }
            catch (Exception ex)
            {
                return  Json(new { response = "Error" });
                _logger.LogError("Create CIK user:{0}", ex.ToString());
            }
        }

        public async Task<JsonResult> CreateMecAdmins(string email, string idRole, string idParty, string idObs)
        {
            try
            {
                List<EIzboriMunicipalitiesView> eIzboriMunicipalitiesViews = _dbER.EIzboriMunicipalitiesViews.ToList();
                var MecAdminRoleId = _db.AspNetRoles.Where(a=>a.Name == "MEC_Admin").Select(a=>a.Id).FirstOrDefault();
                //eIzboriMunicipalitiesViews.ForEach(async a =>
                foreach (var a in eIzboriMunicipalitiesViews)
                {
                    //if(a.Code == "001")
                    //{
                        var userName = "MEC_Admin_" + a.Code + "@izbori.ba";
                        string defaultPass = "MEC_Admin_" + a.Code;
                        var userExist = _db.AspNetUsers.Where(a => a.UserName == userName).FirstOrDefault();
                        if (userExist == null)
                        {
                            var user = CreateUser();
                            user.UserName = userName;
                            user.Email = userName;
                            user.EmailConfirmed = true;

                            var result = await _userManager.CreateAsync(user, defaultPass);
                            var userId = await _userManager.GetUserIdAsync(user);
                            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                            if (result.Succeeded)
                            {
                                AspNetUserRole newrole = new AspNetUserRole();
                                newrole.UserId = user.Id;
                                newrole.RoleId = MecAdminRoleId;
                                _db.AspNetUserRoles.Add(newrole);
                                _db.SaveChanges();


                                //int idp = int.Parse(idParty);
                                var u = _db.AspNetUsers.Where(a => a.UserName == userName).FirstOrDefault();
                                u.IdMunicipality = a.Id;
                                _db.SaveChanges();

                            }
                        //}
                    }

                }

                return new JsonResult(new { response = "Success" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { response = "Error" });
                _logger.LogError("Create CIK user:{0}", ex.ToString());
            }
        }

        [HttpPost]
        public async Task<JsonResult> DeleteUser(string id)
        {
            try
            {
                if (id == null)
                {
                    return Json(new { response = "Error", msg = _stringLocalizer["Id je null"] });
                }

                //spasi korisnika u delete
                //AspNetUser userToDelete = _db.AspNetUsers.Where(a=>a.Id == id).FirstOrDefault();
                ////AspNetUsersDeleted aspNetUsersDeleted = new AspNetUsersDeleted();

                //AspNetUsersDeleted aspNetUsersDeleted = JsonConvert.DeserializeObject<AspNetUsersDeleted>(JsonConvert.SerializeObject(userToDelete));

                //_db.AspNetUsersDeleteds.Add(aspNetUsersDeleted);
                //_db.SaveChanges();

                var user = await _userManager.FindByIdAsync(id);
                var rolesForUser = await _userManager.GetRolesAsync(user);

                using (var transaction = _db.Database.BeginTransaction())
                {
                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            // item should be the name of the role
                            var result = await _userManager.RemoveFromRoleAsync(user, item);
                        }
                    }

                    await _userManager.DeleteAsync(user);
                    transaction.Commit();
                }

                return Json(new { response = "Success", msg = _stringLocalizer["Korinsik je uspješno izbisan!"] });

            }
            catch (Exception ex)
            {
                return Json(new { response = "Error", msg = _stringLocalizer["Došlo je do greške prilikom brisanja!"] });
            }
        }
    }
}