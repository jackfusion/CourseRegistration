using CourseRegistration.Data.MockRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.Interfaces
{
    public interface ICourseStudentRepo
    {
        IEnumerable<CourseStudent> GetAllCourseStudent();
        CourseStudent GetCourseStudentByID(int id);
        void CreateCourseStudent(CourseStudent input);
        void UpdateCourseStudent(CourseStudent input);
        bool SaveChanges();
        void RemoveRange(int S_ID);
        void AddRange(IEnumerable<CourseStudent> range);
    }
}
