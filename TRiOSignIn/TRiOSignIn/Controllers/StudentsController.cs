using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRiOSignIn.Models;
using TRiOSignIn.ViewModels;

namespace TRiOSignIn.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize]
        public ActionResult Index()
        {
            var students = _context.Students;

            return View(students);
        }

        [Authorize]
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Save(Student student)
        {
            ModelState.Remove("Id");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View("New", student);
            }

            if (student.Id == 0)
            {
                _context.Students.Add(student);
            }
            else
            {
                var oldStudent = _context.Students.Single(c => c.Id == student.Id);
                oldStudent.Id = student.Id;
                oldStudent.FirstName = student.FirstName;
                oldStudent.MiddleInitial = student.MiddleInitial;
                oldStudent.LastName = student.LastName;
                oldStudent.Email = student.Email;
                oldStudent.Phone = student.Phone;
                oldStudent.StudentId = student.StudentId;
                oldStudent.CardNumber = student.CardNumber;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Students");
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var student = _context.Students.SingleOrDefault(c => c.Id == id);
            var visits = _context.Visits.Where(m=> m.StudentId == id).ToList();

            if (student == null)
                return HttpNotFound();

            var viewModel = new StudentDetailViewModel();

            viewModel.Student = student;
            viewModel.Visits = visits;

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault(c => c.Id == id);

            if (student == null)
                return HttpNotFound();

            return View(student);
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}