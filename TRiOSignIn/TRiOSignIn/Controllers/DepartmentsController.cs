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
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext _context;

        public DepartmentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Departments
        public ActionResult Index()
        {
            var departments = _context.Departments;

            return View(departments);
        }

        public ActionResult Details(int id)
        {
            var department = _context.Departments.SingleOrDefault(c => c.Id == id);

            if (department == null)
                return HttpNotFound();

            var viewModel = new DepartmentDetailsViewModel();

            viewModel.Department = department;
            viewModel.Labs = _context.Labs.Where(m => m.DepartmentId == department.Id).Include(c => c.Building).Include(c => c.Department).ToList();

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var department = _context.Departments.SingleOrDefault(c => c.Id == id);

            if (department == null)
                return HttpNotFound();

            return View(department);
        }

        public ActionResult Save(Department department)
        {
            ModelState.Remove("Id");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View("New", department);
            }

            if (department.Id == 0)
            {
                _context.Departments.Add(department);
            }
            else
            {
                var oldDepartment = _context.Departments.Single(c => c.Id == department.Id);
                oldDepartment.Name = department.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Departments");
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            var department = _context.Departments.SingleOrDefault(c => c.Id == id);

            if (department == null)
                return HttpNotFound();

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return RedirectToAction("Index", "Departments");
        }

        public ActionResult Create(Department department)
        {
            var newDepartment = new Department();

            newDepartment.Name = department.Name;

            return RedirectToAction("New", newDepartment);
        }
    }
}