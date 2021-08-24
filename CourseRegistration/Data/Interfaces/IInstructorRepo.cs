using CourseRegistration.Models;
using CourseRegistration.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.Interfaces
{
    public interface IInstructorRepo
    {
        IEnumerable<Instructor> GetAllInstructors();
        Instructor GetInstructorsById(int id);
        void CreateInstructor(Instructor input);
        void UpdateInstructor(Instructor input);
        bool SaveChanges();
    }
}
