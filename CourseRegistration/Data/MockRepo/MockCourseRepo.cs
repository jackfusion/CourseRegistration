using CourseRegistration.Data.Interfaces;
using CourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.MockRepo
{
    public class MockCourseRepo : ICourseRepo
    {
        private readonly static List<Courses> _courses = new List<Courses>
        {
            new Courses { C_Id = 001, Number = 1, Name = "Math", Description = "Math"},
            new Courses { C_Id = 002, Number = 2, Name = "Computers", Description = "Teach Web Development"},
            new Courses { C_Id = 003, Number = 3, Name = "Gym", Description = "Gym"},
        };

        public void CreateCourse(Courses input)
        {
            int code = _courses.Max(c => c.C_Id) + 1;
            input.C_Id = code;
            _courses.Add(input);
        }

        public IEnumerable<Courses> GetAllCourses()
        {
            return _courses;
        }

        public Courses GetCoursesByID(int id)
        {
            return _courses.FirstOrDefault(c => c.C_Id == id);
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void UpdateCourse(Courses input)
        {
            var itemInTheList = _courses.FirstOrDefault(c => c.C_Id == input.C_Id);

            if (itemInTheList != null)
            {
                itemInTheList.Number = input.Number;
                itemInTheList.Name = input.Name;
                itemInTheList.Description = input.Description;
            }
        }
    }
}
