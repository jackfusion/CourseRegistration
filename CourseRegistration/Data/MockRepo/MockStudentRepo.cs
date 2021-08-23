﻿using CourseRegistration.Data.Interfaces;
using CourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.MockRepo
{
    public class MockStudentRepo : IStudentRepo
    {
        private readonly static List<Students> _students = new List<Students>
        {
            new Students { S_Id = 00001, FirstName = "Jim", LastName = "Black", EmailAddress = "jimblack@mail.com", PhoneNumber = "2045553344", C_Id = 001},
            new Students { S_Id = 00002, FirstName = "Jack", LastName = "White", EmailAddress = "jackwhite@mail.com", PhoneNumber = "2045552244", C_Id = 002},
            new Students { S_Id = 00003, FirstName = "George", LastName = "Grey", EmailAddress = "georgegrey@mail.com", PhoneNumber = "2045553322", C_Id = 003},
            new Students { S_Id = 00004, FirstName = "Jill", LastName = "Fusion", EmailAddress = "jillfusion@mail.com", PhoneNumber = "2045554444", C_Id = 001},
            new Students { S_Id = 00005, FirstName = "Jam", LastName = "blur", EmailAddress = "jamblur@mail.com", PhoneNumber = "2045555544", C_Id = 001},
            new Students { S_Id = 00006, FirstName = "John", LastName = "Butt", EmailAddress = "johnbutt@mail.com", PhoneNumber = "2045556644", C_Id = 003},
            new Students { S_Id = 00007, FirstName = "Mary", LastName = "Jo", EmailAddress = "maryjo@mail.com", PhoneNumber = "2045557744", C_Id = 002},

        };

        public void CreateStudent(Students input)
        {
            int code = _students.Max(s => s.S_Id) + 1;
            input.S_Id = code;
            _students.Add(input);
        }

        public IEnumerable<Students> GetAllStudents()
        {
            return _students;
        }

        public Students GetStudentsById(int id)
        {
            return _students.FirstOrDefault(s => s.S_Id == id);
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void UpdateStudent(Students input)
        {
            var itemInTheList = _students.FirstOrDefault(s => s.S_Id == input.S_Id);

            if (itemInTheList != null)
            {
                itemInTheList.FirstName = input.FirstName;
                itemInTheList.LastName = input.LastName;
                itemInTheList.EmailAddress = input.EmailAddress;
                itemInTheList.PhoneNumber = input.PhoneNumber;
                itemInTheList.C_Id = input.C_Id;
            }
        }
    }
}
