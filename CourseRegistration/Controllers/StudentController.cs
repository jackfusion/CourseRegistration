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
using CourseRegistration.ViewModels;
using CourseRegistration.Data.MockRepo;

namespace CourseRegistration.Controllers
{
    public class StudentController : Controller
    {
        private readonly ICourseRepo _coursesRepo;
        private readonly IStudentRepo _studentRepo;
        private readonly ICourseStudentRepo _courseStudentRepo;
        private readonly Mapper _mapper = new Mapper();

        public StudentController(IStudentRepo studentRepo, ICourseRepo courseRepo, ICourseStudentRepo courseStudentRepo)
        {
            _coursesRepo = courseRepo;
            _studentRepo = studentRepo;
            _courseStudentRepo = courseStudentRepo;
        }
        public IActionResult Index()
        {
            var course = _coursesRepo.GetAllCourses();
            var student = _studentRepo.GetAllStudents()
                //.Select(c =>
                //{
                //    c.Course = course.Where(s => s.C_Id == c.C_Id)
                //                       .FirstOrDefault() ?? new Models.Course
                //                       {
                //                           Name = "n/a"
                //                       };
                //    return c;
                //})
                .Select(s => _mapper.Map(s))
                .ToList();
            return View(student);
        }

        public IEnumerable<string> GetStudentsByS_Id(int? id)
        {
            var result = _studentRepo.GetAllStudents()
                .Where(c => c.S_Id == id)
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
            return View();
        }

        public ActionResult Edit(int id)
        {
            var list = _coursesRepo.GetAllCourses()
                .Select(s => _mapper.Map(s))
                .ToList();
            ViewBag.Course = new SelectList(list, nameof(CourseDto.C_Id), nameof(CourseDto.Name));
            var s = _mapper.Map(_studentRepo.GetStudentsById(id));
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
        public ActionResult GetCourseByStudentId(int Id)
        {
            var list = _courseStudentRepo.GetAllCourseStudent();
            var courses = _coursesRepo.GetAllCourses()
                .Select(c =>
                    new CourseVM
                    {
                        Id = c.C_Id,
                        Name = c.Name,
                        Description = c.Description,
                        IsActive = list
                        .Where(cs => cs.C_Id == c.C_Id && cs.S_Id == Id)
                        .FirstOrDefault() == null ? false : true
                    }
                )
                .ToList();
            SaveCoursesInStudentVM scs = new SaveCoursesInStudentVM { 
                Courses = courses,
                S_Id = Id
            };
            return PartialView(scs);
        }

        public ActionResult SaveCourse(SaveCoursesInStudentVM obj)
        {
            _courseStudentRepo.RemoveRange(obj.S_Id);
            var toAdd = obj.Courses
                .Where(c => c.IsActive)
                .Select(cs => new CourseStudent
                {
                    S_Id = obj.S_Id,
                    C_Id = cs.Id
                });

            _courseStudentRepo.AddRange(toAdd);
            _courseStudentRepo.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
