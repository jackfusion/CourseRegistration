using CourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.Interfaces
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentsById(int id);
        void CreateStudent(Student input);
        void UpdateStudent(Student input);
        bool SaveChanges();
    }
}
