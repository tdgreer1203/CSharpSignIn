using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRiOSignIn.Models;
using TRiOSignIn.ViewModels;

namespace TRiOSignIn.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            if (Request.Cookies["kioskInfo"] == null)
                return RedirectToAction("Login", "Account");
            else
                return View();
        }
    }
}