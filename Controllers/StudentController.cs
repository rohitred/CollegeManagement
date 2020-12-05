using CollegeManagement.Data;
using CollegeManagement.Models;
using CollegeManagement.Models.ViewModel;
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
                .Include(s => s.StudentCourses)
                .ThenInclude(c=>c.Course)
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
        public IActionResult Create(StudentViewModel obj)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student()
                {
                    StudentName = obj.StudentName,
                    StudentAddress = obj.StudentAddress,
                    StudentContactNo = obj.StudentContactNo,
                    StudentEmail = obj.StudentEmail,
                };
                _db.Students.Add(student);
                _db.SaveChanges();
                var courses = _db.Courses.Where(i => obj.StudentCourses.Contains(i.CourseId)).ToList();
                foreach (var course in courses)
                {
                    var newStudentCourse = new StudentCourse()
                        {
                        StudentId = student.StudentId,
                        CourseId = course.CourseId,
                    };
                        
                    student.StudentCourses.Add(newStudentCourse);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.listOfCourses = _db.Courses.ToList();
                return View(obj);
            }
        }
    }
}

