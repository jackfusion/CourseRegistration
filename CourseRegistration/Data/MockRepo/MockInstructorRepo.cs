using CourseRegistration.Data.Interfaces;
using CourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.MockRepo
{
    public class MockInstructorRepo : IInstructorRepo
    {
        private readonly static List<Instructors> _instructors = new List<Instructors>
        {
            new Instructors { I_Id = 001, FirstName = "Jack", LastName = "Smith", EmailAddress = "jacksmith@mail.com", C_Id = 001},
            new Instructors { I_Id = 002, FirstName = "Luck", LastName = "Hairy", EmailAddress = "luckhairy@mail.com", C_Id = 002},
            new Instructors { I_Id = 003, FirstName = "Darrick", LastName = "Dark", EmailAddress = "darrickdark@mail.com", C_Id = 003},
        };

        public void CreateInstructor(Instructors input)
        {
            int code = _instructors.Max(i => i.I_Id) + 1;
            input.I_Id = code;
            _instructors.Add(input);
        }
        public IEnumerable<Instructors> GetAllInstructors()
        {
            return _instructors;
        }

        public Instructors GetInstructorsById(int id)
        {
            return _instructors.FirstOrDefault(i => i.I_Id == id);
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void UpdateInstructor(Instructors input)
        {
            var itemInTheList = _instructors.FirstOrDefault(i => i.I_Id == input.I_Id);

            if(itemInTheList != null)
            {
                itemInTheList.FirstName = input.FirstName;
                itemInTheList.LastName = input.LastName;
                itemInTheList.EmailAddress = input.EmailAddress;
                itemInTheList.C_Id = input.C_Id;
            }
        }
    }   
}
