﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InsuranceQuoteGenerator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "", new { controller = "Auth", action = "Login" });
            routes.MapRoute("Login", "Login", new { controller = "Auth", action = "Login" });
            routes.MapRoute("Logout", "Logout", new { controller = "Auth", action = "Logout" });
            routes.MapRoute("Home", "Estimate", new { controller = "Estimate", action = "Index" });
            routes.MapRoute("Main", "Estimate/Index", new { controller = "Estimate", action = "Index" });
            routes.MapRoute("Admin", "Auth/Admin", new { controller = "Auth", action = "Admin" });

        }
    }
}
