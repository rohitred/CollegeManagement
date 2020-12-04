using CollegeManagement.Data;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Controllers
{
    public class CourseController : Controller
    {

        private readonly ApplicationDbContext _db;
        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var course = _db.Courses.ToList();
            return View(course);
        }

        //GET : Create course
        public IActionResult Create()
        {
            return View();
        }

        //POST : Create course
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course obj)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET : Edit Course
        public IActionResult Edit(int id)
        {
            var obj = _db.Courses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST : Edit Course
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course obj)
        {
            if (ModelState.IsValid)
            {

                _db.Courses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var obj = _db.Courses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Courses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
