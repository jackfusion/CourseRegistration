using CourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.ModelsDto
{
    public class InstructorDto
    {
        [DisplayName("Teacher ID")]
        public int I_Id { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [DisplayName("Course ID")]
        public int? C_Id { get; set; }
        public CourseDto Course { get; set; }
    }
}
