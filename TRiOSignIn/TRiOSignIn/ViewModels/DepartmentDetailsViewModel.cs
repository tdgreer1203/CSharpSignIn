using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRiOSignIn.Models;

namespace TRiOSignIn.ViewModels
{
    public class DepartmentDetailsViewModel
    {
        public Department Department { get; set; }
        public IEnumerable<Lab> Labs { get; set; }
    }
}