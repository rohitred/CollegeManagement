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
                .ThenInclude(c => c.Course)
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
                    DateOfBirth=obj.DateOfBirth,
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


        public IActionResult Edit(int id)
        {
            var obj = _db.Students
                .Include(c => c.StudentCourses)
                .FirstOrDefault(s => s.StudentId == id);
            if (obj == null)
            {
                return NotFound();
            }
            StudentViewModel student = new StudentViewModel()
            {
                StudentName = obj.StudentName,
                StudentAddress = obj.StudentAddress,
                StudentContactNo = obj.StudentContactNo,
                StudentEmail = obj.StudentEmail,
                StudentId = obj.StudentId,

            };

            foreach (var course in obj.StudentCourses)
            {
                student.StudentCourses.Add(course.CourseId);
            }
            ViewBag.listOfCourses = _db.Courses.ToList();
            return View(student);
        }


        //POST : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentViewModel obj)
        {
            if (ModelState.IsValid)
            {

                var dbData = _db.Students.Find(obj.StudentId);
                if (dbData == null)
                {
                    return NotFound();
                }
                dbData.StudentEmail = obj.StudentEmail;
                dbData.StudentAddress = obj.StudentAddress;
                dbData.StudentContactNo = obj.StudentContactNo;
                dbData.StudentName = obj.StudentName;
                dbData.DateOfBirth = obj.DateOfBirth;
                var oldCourses = _db.StudentCourses.Where(i => i.StudentId == obj.StudentId).ToList();
                _db.StudentCourses.RemoveRange(oldCourses);
                var courses = _db.Courses.Where(i => obj.StudentCourses.Contains(i.CourseId)).ToList();
                foreach (var course in courses)
                {
                    var newStudentCourse = new StudentCourse()
                    {
                        StudentId = obj.StudentId,
                        CourseId = course.CourseId,
                    };

                    dbData.StudentCourses.Add(newStudentCourse);
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


        public IActionResult Delete(int id)
        {
            var studentObj = _db.Students.Find(id);
            if (studentObj == null)
            {
                return NotFound();
            }
            var selectedCourse = _db.StudentCourses.Where(i => i.StudentId == studentObj.StudentId);
            _db.Students.Remove(studentObj);
            _db.StudentCourses.RemoveRange(selectedCourse);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

