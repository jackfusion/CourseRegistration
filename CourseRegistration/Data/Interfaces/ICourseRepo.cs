using CourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.Interfaces
{
    public interface ICourseRepo
    {
        IEnumerable<Courses> GetAllCourses();
        Courses GetCoursesByID(int id);
        void CreateCourse(Courses input);
        void UpdateCourse(Courses input);
        bool SaveChanges();
    }
}
