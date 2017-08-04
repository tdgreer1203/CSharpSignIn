using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRiOSignIn.Models;
using TRiOSignIn.ViewModels;

namespace TRiOSignIn.Controllers
{
    [Authorize]
    public class BuildingsController : Controller
    {
        private ApplicationDbContext _context;

        public BuildingsController()
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
            var buildings = _context.Buildings;

            return View(buildings);
        }

        public ActionResult Details(int id)
        {
            var building = _context.Buildings.SingleOrDefault(c => c.Id == id);

            if (building == null)
                return HttpNotFound();

            var viewModel = new BuildingDetailsViewModel();

            viewModel.Building = building;
            viewModel.Labs = _context.Labs.Include(c => c.Building).Include(c => c.Department).Where(m => m.BuildingId == building.Id).ToList();

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var building = _context.Buildings.SingleOrDefault(c => c.Id == id);

            if (building == null)
                return HttpNotFound();

            return View(building);
        }

        public ActionResult Create(Building building)
        {
            var newBuilding = new Building();

            newBuilding.Name = building.Name;
            newBuilding.MapNumber = building.MapNumber;

            return RedirectToAction("New", newBuilding);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Save(Building building)
        {
            ModelState.Remove("Id");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View("New", building);
            }

            if (building.Id == 0)
            {
                _context.Buildings.Add(building);
            }
            else
            {
                var oldBuilding = _context.Buildings.Single(c => c.Id == building.Id);
                oldBuilding.Id = building.Id;
                oldBuilding.Name = building.Name;
                oldBuilding.MapNumber = building.MapNumber;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Buildings");
        }

        public ActionResult Delete(int id)
        {
            var building = _context.Buildings.SingleOrDefault(c => c.Id == id);

            if (building == null)
                return HttpNotFound();

            _context.Buildings.Remove(building);
            _context.SaveChanges();

            return RedirectToAction("Index", "Buildings");
        }
    }
}