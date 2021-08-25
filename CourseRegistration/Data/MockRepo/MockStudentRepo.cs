using CourseRegistration.Data.Interfaces;
using CourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.MockRepo
{
    public class MockStudentRepo : IStudentRepo
    {
        private readonly static List<Student> _students = new List<Student>
        {
            new Student { S_Id = 00001, FirstName = "Jim", LastName = "Black", EmailAddress = "jimblack@mail.com", PhoneNumber = "2045553344"},
            new Student { S_Id = 00002, FirstName = "Jack", LastName = "White", EmailAddress = "jackwhite@mail.com", PhoneNumber = "2045552244"},
            new Student { S_Id = 00003, FirstName = "George", LastName = "Grey", EmailAddress = "georgegrey@mail.com", PhoneNumber = "2045553322"},
            new Student { S_Id = 00004, FirstName = "Jill", LastName = "Fusion", EmailAddress = "jillfusion@mail.com", PhoneNumber = "2045554444"},
            new Student { S_Id = 00005, FirstName = "Jam", LastName = "blur", EmailAddress = "jamblur@mail.com", PhoneNumber = "2045555544"},
            new Student { S_Id = 00006, FirstName = "John", LastName = "Butt", EmailAddress = "johnbutt@mail.com", PhoneNumber = "2045556644"},
            new Student { S_Id = 00007, FirstName = "Mary", LastName = "Jo", EmailAddress = "maryjo@mail.com", PhoneNumber = "2045557744"},

        };

        public void CreateStudent(Student input)
        {
            int code = _students.Max(s => s.S_Id) + 1;
            input.S_Id = code;
            _students.Add(input);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudentsById(int id)
        {
            return _students.FirstOrDefault(s => s.S_Id == id);
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void UpdateStudent(Student input)
        {
            var itemInTheList = _students.FirstOrDefault(s => s.S_Id == input.S_Id);

            if (itemInTheList != null)
            {
                itemInTheList.FirstName = input.FirstName;
                itemInTheList.LastName = input.LastName;
                itemInTheList.EmailAddress = input.EmailAddress;
                itemInTheList.PhoneNumber = input.PhoneNumber;
            }
        }
    }
}
