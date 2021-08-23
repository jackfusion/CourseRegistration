using CourseRegistration.Data.Interfaces;
using CourseRegistration.Models;
using CourseRegistration.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.MockRepo
{
    public class MockInstructorRepo : IInstructorRepo
    {
        private readonly static List<Instructor> _instructors = new List<Instructor>
        {
            new Instructor { I_Id = 001, FirstName = "Jack", LastName = "Smith", EmailAddress = "jacksmith@mail.com", C_Id = 001},
            new Instructor { I_Id = 002, FirstName = "Luck", LastName = "Hairy", EmailAddress = "luckhairy@mail.com", C_Id = 002},
            new Instructor { I_Id = 003, FirstName = "Darrick", LastName = "Dark", EmailAddress = "darrickdark@mail.com", C_Id = 003},
        };

        public void CreateInstructor(Instructor input)
        {
            int code = _instructors.Max(i => i.I_Id) + 1;
            input.I_Id = code;
            _instructors.Add(input);
        }

        public IEnumerable<Instructor> GetAllInstructors()
        {
            return _instructors;
        }

        public Instructor GetInstructorsById(int id)
        {
            return _instructors.FirstOrDefault(i => i.I_Id == id);
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void UpdateInstructor(Instructor input)
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
