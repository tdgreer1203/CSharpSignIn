using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRiOSignIn.Models;
using TRiOSignIn.ViewModels;

namespace TRiOSignIn.Controllers
{
    [Authorize]
    public class VisitsController : Controller
    {
        private ApplicationDbContext _context;

        public VisitsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var visits = _context.Visits.Include(c=> c.Student).Include(m=> m.Lab).ToList();

            return View(visits);
        }

        [HttpPost]
        public ActionResult Create(Student stu)
        {
            var student = _context.Students.SingleOrDefault(c => c.StudentId.Equals(stu.StudentId));

            if (student != null)
            {
                var lastVisit = _context.Visits.SingleOrDefault(m => m.StudentId == student.Id && m.isActive == true);

                if (lastVisit != null)
                {
                    lastVisit.EndTime = DateTime.Now;
                    lastVisit.isActive = false;
                }
                else
                {
                    var newVisit = new Visit();
                    newVisit.StartTime = DateTime.Now;
                    newVisit.EndTime = DateTime.Now;
                    newVisit.StudentId = student.Id;
                    newVisit.LabId = 1;
                    newVisit.isActive = true;
                    _context.Visits.Add(newVisit);
                }


                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Register", "Students");
            }
        }
    }
}