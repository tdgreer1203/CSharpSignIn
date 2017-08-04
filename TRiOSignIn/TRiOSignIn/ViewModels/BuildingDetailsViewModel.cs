using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRiOSignIn.Models;

namespace TRiOSignIn.ViewModels
{
    public class BuildingDetailsViewModel
    {
        public Building Building { get; set; }
        public IEnumerable<Lab> Labs { get; set; }
    }
}