using CourseRegistration.Data.Interfaces;
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
        public void CreateCourseStudent(courseStudent input)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<courseStudent> GetAllCourseStudent()
        {
            return _context.CourseStudent.ToList();
        }

        public courseStudent GetCourseStudentByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateCourseStudent(courseStudent input)
        {
            throw new NotImplementedException();
        }
    }
}
