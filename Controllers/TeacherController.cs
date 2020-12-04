using CollegeManagement.Data;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TeacherController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var obj = _db.Teachers
                .Include(d => d.Department)
                .Include(c=>c.Course)
                .ToList();
            return View(obj);
        }

        //GET : Create
        public IActionResult Create()
        {
            ViewBag.listOfDepartment = _db.Departments.ToList();
            ViewBag.listOfCourse = _db.Courses.ToList();
            return View();
        }

        //POST : Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.listOfDepartment = _db.Departments.ToList();
            ViewBag.listOfCourse = _db.Courses.ToList();
            return View(obj);
        }


        public IActionResult Edit(int id)
        {
            var obj = _db.Teachers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            ViewBag.listOfDepartment = _db.Departments.ToList();
            ViewBag.listOfCourse = _db.Courses.ToList();
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.listOfDepartment = _db.Departments.ToList();
            ViewBag.listOfCourse = _db.Courses.ToList();
            return View(obj);
        }


        public IActionResult Delete(int id)
        {
            var obj = _db.Teachers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Teachers.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
