using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TRiOSignIn.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name."), MaxLength(100), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name."), MaxLength(100), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(2), Display(Name = "Middle Initial")]
        public string MiddleInitial { get; set; }

        [Required(ErrorMessage = "Please enter your email address."), MaxLength(100), EmailAddress, Display(Name = "Email Address")]
        public string Email { get; set; }

        [MaxLength(20), Display(Name = "Phone Number"), Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your student ID number."), MaxLength(100), Display(Name = "Student ID Number")]
        public string StudentId { get; set; }

        [MaxLength(75), Display(Name = "Card Number")]
        public string CardNumber { get; set; }
    }
}