using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.ModelsDto
{
    public class CourseDto
    {
        [DisplayName("Course ID")]
        [Key]
        public int C_Id { get; set; }
        [DisplayName("Number")]
        [Required]
        public int Number { get; set; }
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}
