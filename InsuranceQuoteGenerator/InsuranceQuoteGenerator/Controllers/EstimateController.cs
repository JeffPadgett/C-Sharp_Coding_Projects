using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceQuoteGenerator.Models;

namespace InsuranceQuoteGenerator.Controllers
{
    public class EstimateController : Controller
    {
        private ApplicationDbContext _context;

        public EstimateController()
        {
            _context = new ApplicationDbContext();
        }
        
        public ActionResult Index()
        {
            return View();
        }
    }
}