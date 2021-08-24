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
        private readonly ICourseRepo _coursesRepo;
        private readonly IInstructorRepo _instructorRepo;
        private readonly Mapper _mapper = new Mapper();


        public InstructorController(IInstructorRepo instructorRepo, ICourseRepo courseRepo)
        {
            _coursesRepo = courseRepo;
            _instructorRepo = instructorRepo;
        }
        public IActionResult Index()
        {
            var course = _coursesRepo.GetAllCourses();
            var instructor = _instructorRepo.GetAllInstructors()
                .Select(c =>
                {
                    c.Course = course.Where(i => i.C_Id == c.C_Id)
                                    .FirstOrDefault() ?? new Models.Course
                                    {
                                        Name = "n/a"
                                    };
                    return c;
                })
                .Select(i => _mapper.Map(i))
                .ToList();
            return View(instructor);
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
            var list = _coursesRepo.GetAllCourses()
                .Select(i => _mapper.Map(i))
                .ToList();
            ViewBag.Courses = new SelectList(list, nameof(CourseDto.C_Id), nameof(CourseDto.Name));
            return View();
        }

        public ActionResult Edit(int id)
        {
            var list = _coursesRepo.GetAllCourses()
                .Select(i => _mapper.Map(i))
                .ToList();
            ViewBag.Course = new SelectList(list, nameof(CourseDto.C_Id), nameof(CourseDto.Name));
            var i = _mapper.Map(_instructorRepo.GetInstructorsById(id));
            return View(i);
        }

        [HttpPost]
        public ActionResult Create(InstructorDto instructor)
        {
            _instructorRepo.CreateInstructor(_mapper.Map(instructor));
            _instructorRepo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(InstructorDto instructor)
        {
            _instructorRepo.UpdateInstructor(_mapper.Map(instructor));
            _instructorRepo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
