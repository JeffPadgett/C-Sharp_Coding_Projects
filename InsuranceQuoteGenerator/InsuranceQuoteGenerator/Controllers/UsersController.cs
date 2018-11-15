using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceQuoteGenerator.Controllers
{
    [Authorize(Roles = "admin")]
    [Authorize(Roles = "user")]
    public class UsersController : Controller
    {
        
        public ActionResult Index()
        {
            return Content("Users Page.");
        }
    }
}