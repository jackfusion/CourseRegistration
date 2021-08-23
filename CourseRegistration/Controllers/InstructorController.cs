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
    public class InstructorController : Controller
    {
        private ICourseRepo _coursesRepo;
        private IInstructorRepo _instructorRepo;
        private readonly Mapper _mapper = new Mapper();


        public InstructorController(IInstructorRepo instructorRepo, ICourseRepo courseRepo)
        {
            _coursesRepo = courseRepo;
            _instructorRepo = instructorRepo;
        }
        public IActionResult Index()
        {
            var courses = _coursesRepo.GetAllCourses();
            var instructors = _instructorRepo.GetAllInstructors()
                .Select(c =>
                {
                    c.Course = courses
                                    .Where(i => i.C_Id == c.C_Id)
                                    .FirstOrDefault() ?? new Models.Courses
                                    {
                                        Name = "n/a"
                                    };
                    return c;
                })
                .Select(s => _mapper.Map(s))
                .ToList();
            return View(instructors);
        }

        public IEnumerable<string> GetInstructorByI_Id(int? id)
        {
            var result = _instructorRepo.GetAllInstructors()
                .Where(c => c.C_Id == id)
                .Select(c => $"{c.LastName} {c.FirstName} <br>");

            if (result == null || result.Count() == 0)
            {
                return new List<string> { "No Instructor found" };
            }

            return result;
        }
        public ActionResult Create()
        {
            var list = _coursesRepo.GetAllCourses().ToList();
            ViewBag.Courses = new SelectList(list, nameof(CourseDto.C_Id), nameof(CourseDto.Name));
            return View();
        }

        public ActionResult Edit(int id)
        {
            var list = _coursesRepo.GetAllCourses().ToList();
            ViewBag.Courses = new SelectList(list, nameof(Courses.C_Id), nameof(Courses.Name));
            var i = _instructorRepo.GetInstructorsById(id);
            return View(i);
        }

        [HttpPost]
        public ActionResult Create(Instructors instuctor)
        {
            _instructorRepo.CreateInstructor(instuctor);
            _instructorRepo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(Instructors instructor)
        {
            _instructorRepo.UpdateInstructor(instructor);
            _instructorRepo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
