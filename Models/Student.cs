using CollegeManagement.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Student
    {
        public Student()
        {
            StudentCourses = new List<StudentCourse>();
        }
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string StudentAddress { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Contact Number")]
        public string StudentContactNo { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string StudentEmail { get; set; }

        [Required]
        [Display(Name = "Courses")]
        /*[StudentCourseValidate(ErrorMessage = "Select at least 2")]*/
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    }

    
}
