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

            });
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form)
        {
            if (!ModelState.IsValid)
                return View(form);

            if (form.Username != "Admin".ToLower() || form.Username != "User".ToLower())
            {
                ModelState.AddModelError("Username", "Please enter Admin or User as your username to define access restriction. Password is Pass");
                return View(form);
            }


            return Content("The from is valid.");

        }
    }
}