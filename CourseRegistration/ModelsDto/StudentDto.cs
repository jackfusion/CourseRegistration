using CourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.ModelsDto
{
    public class StudentDto
    {
        [DisplayName("Student ID")]
        public int S_Id { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [DisplayName("Email Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [DisplayName("Phone Number")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        //[DisplayName("Course ID")]

        //public int? C_Id { get; set; }
        //public CourseDto Course { get; set; }
    }
}
