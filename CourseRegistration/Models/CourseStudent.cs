using CourseRegistration.Models;
using CourseRegistration.ModelsDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.MockRepo
{
    public class CourseStudent
    {
        [Key]
        public int CS_Id { get; set; }
        
        [ForeignKey("Student")]
        public int S_Id { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Course")]
        public int C_Id { get; set; }
        public Course Course { get; set; }
    }
}
