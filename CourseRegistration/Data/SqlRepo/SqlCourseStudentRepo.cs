﻿using CourseRegistration.Data.Interfaces;
using CourseRegistration.Data.MockRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.SqlRepo
{
    public class SqlCourseStudentRepo : ICourseStudentRepo
    {
        private readonly AppDbContext _context;

        public SqlCourseStudentRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateCourseStudent(CourseStudent input)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseStudent> GetAllCourseStudent()
        {
            return _context.CourseStudent.ToList();
        }

        public CourseStudent GetCourseStudentByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateCourseStudent(CourseStudent input)
        {
            throw new NotImplementedException();
        }
    }
}
