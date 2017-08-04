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
    public class LabsController : Controller
    {
        private ApplicationDbContext _context;

        public LabsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Labs
        public ActionResult Index()
        {
            var labs = _context.Labs.Include(c => c.Building).Include(m => m.Department);
            return View(labs);
        }

        public ActionResult Details(int id)
        {
            var viewModel = new LabDetailViewModel();
            var lab = _context.Labs.Include(c => c.Building).Include(c => c.Department).SingleOrDefault(c => c.Id == id);

            if (lab == null)
            {
                return HttpNotFound();
            }
            else
            {
                var visits = _context.Visits.Include(c => c.Student).Where(m => m.LabId == lab.Id).ToList();

                viewModel.Lab = lab;
                viewModel.Visits = visits;

                return View(viewModel);
            }   
        }

        public ActionResult New()
        {
            var viewModel = new LabNewViewModel();

            viewModel.Buildings = _context.Buildings.ToList();
            viewModel.Departments = _context.Departments.ToList();

            return View(viewModel);
        }

        public ActionResult Save(Lab lab)
        {
            if (lab.Id == 0)
            {
                _context.Labs.Add(lab);
            }
            else
            {
                var oldLab = _context.Labs.Single(c => c.Id == lab.Id);
                oldLab.Id = lab.Id;
                oldLab.Name = lab.Name;
                oldLab.Room = lab.Room;
                oldLab.BuildingId = lab.BuildingId;
                oldLab.DepartmentId = lab.DepartmentId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Labs");
        }

        public ActionResult Edit(int id)
        {
            var lab = _context.Labs.SingleOrDefault(c => c.Id == id);

            if (lab == null)
                return HttpNotFound();

            var viewModel = new LabNewViewModel();

            viewModel.Lab = lab;
            viewModel.Buildings = _context.Buildings.ToList();
            viewModel.Departments = _context.Departments.ToList();

            return View(viewModel);
        }
    }
}