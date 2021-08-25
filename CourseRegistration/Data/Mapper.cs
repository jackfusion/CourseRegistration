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
        public Course Map(CourseDto input)
        {
            return new Course
            {
                C_Id = input.C_Id,
                Number = input.Number,
                Name = input.Name,
                Description = input.Description
            };
        }

        public CourseDto Map(Course input)
        {
            return new CourseDto
            {
                C_Id = input.C_Id,
                Number = input.Number,
                Name = input.Name,
                Description = input.Description
            };
        }

        public Student Map(StudentDto input)
        {
            return new Student
            {
                S_Id = input.S_Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                EmailAddress = input.EmailAddress,
                PhoneNumber = input.PhoneNumber
            };
        }

        public StudentDto Map(Student input)
        {
            return new StudentDto
            {
                S_Id = input.S_Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                EmailAddress = input.EmailAddress,
                PhoneNumber = input.PhoneNumber
            };
        }

        public Instructor Map(InstructorDto input)
        {
            return new Instructor
            {
                I_Id = input.I_Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                EmailAddress = input.EmailAddress,
                C_Id = input.C_Id
            };
        }
        public InstructorDto Map(Instructor input)
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
