using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceQuoteGenerator.Controllers;
using InsuranceQuoteGenerator.ViewModels;

namespace InsuranceQuoteGenerator.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View(new AuthLogin
            {
                Test = "This is a test"

            });
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form)
        {
            return Content("Hey there " + form.Username + "You set your password to " + form.Password);
        }
    }
}