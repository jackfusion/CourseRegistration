using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseRegistration.Data.Interfaces;
using CourseRegistration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseRegistration.Data;
using CourseRegistration.ModelsDto;

namespace CourseRegistration.Controllers
{
    public class StudentController : Controller
    {
        private ICourseRepo _coursesRepo;
        private IStudentRepo _studentRepo;
        private readonly Mapper _mapper = new Mapper();

        public StudentController(IStudentRepo studentRepo, ICourseRepo courseRepo)
        {
            _coursesRepo = courseRepo;
            _studentRepo = studentRepo;
        }
        public IActionResult Index()
        {
            var courses = _coursesRepo.GetAllCourses();
            var students = _studentRepo.GetAllStudents()
                .Select(c =>
                {
                    c.Courses = courses.Where(s => s.C_Id == c.C_Id)
                                       .FirstOrDefault() ?? new Models.Courses
                                       {
                                           Name = "n/a"
                                       };
                    return c;
                })
                .Select(s => _mapper.Map(s))
                .ToList();

            return View(students);
        }

        public IEnumerable<string> GetStudentsByS_Id(int? id)
        {
            var result = _studentRepo.GetAllStudents()
                .Where(c => c.C_Id == id)
                .Select(c => $"{c.LastName} {c.FirstName}<br>");

            if (result == null || result.Count() == 0)
            {
                return new List<string> { "No Student found" };
            }

            return result;
        }

        public ActionResult Create()
        {
            var list = _coursesRepo.GetAllCourses()
                .Select(s => _mapper.Map(s))
                .ToList();
            ViewBag.Courses = new SelectList(list, nameof(CourseDto.C_Id), nameof(CourseDto.Name));
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            var list = _coursesRepo.GetAllCourses()
                .Select(s => _mapper.Map(s))
                .ToList();
            ViewBag.CourseDto = new SelectList(list, nameof(CourseDto.C_Id), nameof(CourseDto.Name));
            var s = _studentRepo.GetStudentsById(id);
            return View(s);
        }

        [HttpPost]
        public ActionResult Create(StudentDto student)
        {
            _studentRepo.CreateStudent(_mapper.Map(student));
            _studentRepo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(StudentDto student)
        {
            _studentRepo.UpdateStudent(_mapper.Map(student));
            _studentRepo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
