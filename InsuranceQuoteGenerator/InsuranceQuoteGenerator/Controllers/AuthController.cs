using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InsuranceQuoteGenerator.Controllers;
using InsuranceQuoteGenerator.ViewModels;

namespace InsuranceQuoteGenerator.Controllers
{
    public class AuthController : Controller
    {
        //An action used for when a user clicks the logout tab.
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Login");
        }

        //Very first get request that initalizes by default for the entire application.
        [HttpGet]
        public ActionResult Login()
        {
            return View(new AuthLogin
            {

            });
        }

        //Login action overloaded as a Post Method. Implimited after the user clicks login, that takes the form input as a parameter
        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(form);
             
            FormsAuthentication.SetAuthCookie(form.Username, true); //This is how we tell ASP.NET that a person is who he says he is.

            if (!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);

            if (form.Username == "Admin" && form.Password == "Pass")           
                return RedirectToRoute("Admin");
            
            else if (form.Username == "User" && form.Password == "Pass")           
                return RedirectToRoute("Home");
            
            else
            {
                ModelState.AddModelError("Username", @"Please enter either ""Admin"" or ""User"" in the input field, And ""Pass"" as a password");
                return View(form);
            }

        }

        //This is the action that calls the view for the administrator page. 
        public ActionResult Admin()
        {
            return View();
        }
    }
}