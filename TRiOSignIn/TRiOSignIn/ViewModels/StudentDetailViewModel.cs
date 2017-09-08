using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRiOSignIn.Models;

namespace TRiOSignIn.ViewModels
{
    public class StudentDetailViewModel
    {
        public Student Student { get; set; }
        public List<Visit> Visits { get; set; }
        public string Day { get; set; }
        public string Week { get; set; }
        public string Semester { get; set; }
    }
}