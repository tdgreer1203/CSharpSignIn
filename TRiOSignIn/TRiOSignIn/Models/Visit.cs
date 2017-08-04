using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace TRiOSignIn.Models
{
    public class Visit
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int LabId { get; set; }
        public Lab Lab { get; set; }

        public bool isActive { get; set; }

        public bool ForceClosed { get; set; }
    }
}