using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRiOSignIn.Models
{
    public class Kiosk
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int LabId { get; set; }
        public Lab Lab { get; set; }
        public String Identifier { get; set; }
    }
}