using CourseRegistration.Data.Interfaces;
using CourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.SqlRepo
{
    public class SqlInstructorRepo : IInstructorRepo
    {
        private readonly AppDbContext _context;

        public SqlInstructorRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateInstructor(Instructor input)
        {
            if (input == null)
            {
                throw new ArgumentException(nameof(input));
            }
            _context.Instructors.Add(input);
        }

        public IEnumerable<Instructor> GetAllInstructors()
        {
            return _context.Instructors.ToList();
        }

        public Instructor GetInstructorsById(int id)
        {
            return _context.Instructors.FirstOrDefault(i => i.I_Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateInstructor(Instructor input)
        {
            var itemInTheList = _context.Instructors.FirstOrDefault(i => i.I_Id == input.I_Id);

            if (itemInTheList != null)
            {
                itemInTheList.FirstName = input.FirstName;
                itemInTheList.LastName = input.LastName;
                itemInTheList.EmailAddress = input.EmailAddress;
                itemInTheList.C_Id = input.C_Id;
            }
        }
    }
}
