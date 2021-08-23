using CourseRegistration.Data.Interfaces;
using CourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.SqlRepo
{
    public class SqlCoursesRepo : ICourseRepo
    {
        private readonly AppDbContext _context;

        public SqlCoursesRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateCourse(Course input)
        {
            if (input == null)
            {
                throw new ArgumentException(nameof(input));
            }
            _context.Courses.Add(input);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCoursesByID(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.C_Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateCourse(Course input)
        {
            var itemInTheList = _context.Courses.FirstOrDefault(c => c.C_Id == input.C_Id);

            if (itemInTheList != null)
            {
                itemInTheList.Number = input.Number;
                itemInTheList.Name = input.Name;
                itemInTheList.Description = input.Description;
            }
        }
    }
}
