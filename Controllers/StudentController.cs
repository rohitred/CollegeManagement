using CollegeManagement.Data;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var student = _db.Students
                .Include(s => s.Courses)
                .ToList();
            return View(student);
        }

        //GET :Create
        public IActionResult Create()
        {
            ViewBag.listOfCourses = _db.Courses.ToList();
            return View();
        }


        //POST : Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else {
                ViewBag.listOfCourses = _db.Courses.ToList();
                return View(obj);
            }
        }
    }
}

