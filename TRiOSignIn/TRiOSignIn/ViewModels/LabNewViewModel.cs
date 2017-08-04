using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRiOSignIn.Models;

namespace TRiOSignIn.ViewModels
{
    public class LabNewViewModel
    {
        public Lab Lab { get; set; }
        public IEnumerable<Building> Buildings { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}