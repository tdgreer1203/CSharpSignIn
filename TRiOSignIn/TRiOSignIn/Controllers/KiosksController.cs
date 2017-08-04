using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRiOSignIn.Models;
using TRiOSignIn.ViewModels;

namespace TRiOSignIn.Controllers
{
    [Authorize]
    public class KiosksController : Controller
    {
        private ApplicationDbContext _context;

        public KiosksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Buildings
        public ActionResult Index()
        {
            var kiosks = _context.Kiosks.Include(c => c.Lab);

            return View(kiosks);
        }

        public ActionResult Details(int id)
        {
            var kiosk = _context.Kiosks.Include(c => c.Lab).SingleOrDefault(c => c.Id == id);

            if (kiosk == null)
                return HttpNotFound();

            return View(kiosk);
        }

        public ActionResult Edit(int id)
        {
            var kiosk = _context.Kiosks.SingleOrDefault(c => c.Id == id);

            if (kiosk == null)
                return HttpNotFound();

            var viewModel = new KioskEditViewModel();

            viewModel.Kiosk = kiosk;
            viewModel.Labs = _context.Labs.ToList();

            return View(viewModel);
        }

        public ActionResult Save(Kiosk kiosk)
        {
            if (kiosk.Id == 0)
            {
                Guid g = new Guid();
                kiosk.Identifier = g.ToString();

                Response.Cookies["kioskInfo"]["kioskId"] = kiosk.Id.ToString();
                Response.Cookies["kioskInfo"]["kioskName"] = kiosk.Name;
                Response.Cookies["kioskInfo"]["kioskGUID"] = kiosk.Identifier;
                Response.Cookies["kioskInfo"].Expires = DateTime.MaxValue;

                _context.Kiosks.Add(kiosk);
            }
            else
            {
                var oldKiosk = _context.Kiosks.Single(c => c.Id == kiosk.Id);
                oldKiosk.Id = kiosk.Id;
                oldKiosk.Name = kiosk.Name;
                oldKiosk.Lab = kiosk.Lab;
                oldKiosk.Identifier = kiosk.Identifier;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Kiosks");
        }

        public ActionResult New()
        {
            var viewModel = new KioskEditViewModel();

            viewModel.Labs = _context.Labs.ToList();

            return View(viewModel);
        }
    }
}