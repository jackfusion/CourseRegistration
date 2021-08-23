using CourseRegistration.Models;
using CourseRegistration.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data
{
    public class Mapper
    {
        public Courses Map(CourseDto input)
        {
            return new Courses
            {
                C_Id = input.C_Id,
                Number = input.Number,
                Name = input.Name,
                Description = input.Description
            };
        }

        public CourseDto Map(Courses input)
        {
            return new CourseDto
            {
                C_Id = input.C_Id,
                Number = input.Number,
                Name = input.Name,
                Description = input.Description
            };
        }

        public Students Map(StudentDto input)
        {
            return new Students
            {
                S_Id = input.S_Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                EmailAddress = input.EmailAddress,
                PhoneNumber = input.PhoneNumber,
                C_Id = input.C_Id
            };
        }

        public StudentDto Map(Students input)
        {
            return new StudentDto
            {
                S_Id = input.S_Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                EmailAddress = input.EmailAddress,
                PhoneNumber = input.PhoneNumber,
                C_Id = input.C_Id,
                Course = Map(input.Courses)
            };
        }

        public Instructors Map(InstructorDto input)
        {
            return new Instructors
            {
                I_Id = input.I_Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                EmailAddress = input.EmailAddress,
                C_Id = input.C_Id
            };
        }
        public InstructorDto Map(Instructors input)
        {
            return new InstructorDto
            {
                I_Id = input.I_Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                EmailAddress = input.EmailAddress,
                C_Id = input.C_Id,
                Course = Map(input.Course)
            };
        }
    }
}
