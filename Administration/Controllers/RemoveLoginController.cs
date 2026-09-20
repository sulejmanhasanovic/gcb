using Administration.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Administration.Controllers
{

    public class RemoveLoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IdentityManagerContext _db;
        public RemoveLoginController(ILogger<HomeController> logger, IdentityManagerContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@action",
                            SqlDbType =  System.Data.SqlDbType.NVarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = "DELETE"
                        } };
            _db.Database.ExecuteSqlRaw("RemoveUncomfirmedUsers @action", param);


            return Json(new { status="Success" });
        }
    }
}