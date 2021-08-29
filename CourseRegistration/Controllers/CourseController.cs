using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseRegistration.Data.Interfaces;
using CourseRegistration.Models;
using CourseRegistration.Data;
using CourseRegistration.ModelsDto;

namespace CourseRegistration.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepo _courseRepo;
        private readonly Mapper _mapper = new Mapper();

        public CourseController(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }
        public IActionResult Index()
        {
            var list = _courseRepo.GetAllCourses()
                .Select(i => _mapper.Map(i))
                .ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var c = _mapper.Map(_courseRepo.GetCoursesByID(id));
            return View(c);
        }
        [HttpPost]
        public ActionResult Create(CourseDto input)
        {
            _courseRepo.CreateCourse(_mapper.Map(input));
            _courseRepo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(CourseDto course)
        {
            if(ModelState.IsValid)
            { 
            _courseRepo.UpdateCourse(_mapper.Map(course));
            _courseRepo.SaveChanges();
            return RedirectToAction(nameof(Index));
            }
            return View (course);
        }
    }
}
