using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRiOSignIn.Models;

namespace TRiOSignIn.ViewModels
{
    public class KioskEditViewModel
    {
        public Kiosk Kiosk { get; set; }
        public List<Lab> Labs { get; set; }
    }
}