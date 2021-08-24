using CourseRegistration.Data.MockRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.Interfaces
{
    public interface ICourseStudentRepo
    {
        IEnumerable<courseStudent> GetAllCourseStudent();
        courseStudent GetCourseStudentByID(int id);
        void CreateCourseStudent(courseStudent input);
        void UpdateCourseStudent(courseStudent input);
        bool SaveChanges();
    }
}
