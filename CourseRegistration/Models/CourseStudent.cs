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
    public class courseStudent
    {
        [Key]
        public int id { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Student")]
        public int S_Id { get; set; }
        [ForeignKey("Instructor")]
        public int I_Id { get; set; }
        public Instructor Instructor { get; set; }
    }
}
