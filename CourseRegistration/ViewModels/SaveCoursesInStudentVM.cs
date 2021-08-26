using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.ViewModels
{
    public class SaveCoursesInStudentVM
    {
        public List<CourseVM> Courses { get; set; }
        public int S_Id { get; set; }
    }
}
