using CourseRegistration.Data.Interfaces;
using CourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.SqlRepo
{
    public class SqlStudentRepo : IStudentRepo
    {
        private readonly AppDbContext _context;

        public SqlStudentRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateStudent(Student input)
        {
            if (input == null)
            {
                throw new ArgumentException(nameof(input));
            }
            _context.Students.Add(input);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentsById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.S_Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateStudent(Student input)
        {
            var itemInTheList = _context.Students.FirstOrDefault(s => s.S_Id == input.S_Id);

            if (itemInTheList != null)
            {
                itemInTheList.FirstName = input.FirstName;
                itemInTheList.LastName = input.LastName;
                itemInTheList.EmailAddress = input.EmailAddress;
                itemInTheList.PhoneNumber = input.PhoneNumber;
                itemInTheList.C_Id = input.C_Id;
            };
        }
    }
}
