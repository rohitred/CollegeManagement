using CollegeManagement.Data;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly ApplicationDbContext _db;
        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var department = _db.Departments.ToList();
            return View(department);
        }

        //GET : Create department
        public IActionResult Create()
        {
            return View();
        }

        //POST : Create department
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department obj)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET : Edit department
        public IActionResult Edit(int id)
        {
            var obj = _db.Departments.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST : Edit department
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department obj)
        {
            if (ModelState.IsValid)
            {
                
                _db.Departments.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var obj = _db.Departments.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Departments.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
