using CourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.Interfaces
{
    public interface ICourseRepo
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCoursesByID(int id);
        void CreateCourse(Course input);
        void UpdateCourse(Course input);
        bool SaveChanges();
    }
}
