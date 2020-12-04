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
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string StudentAddress { get; set; }
        [Required]
        [Phone]
        public string StudentContactNo { get; set; }
        [Required]
        [EmailAddress]
        
        public string StudentEmail { get; set; }

        [Required]
        /*[StudentCourseValidate(ErrorMessage = "Select at least 2")]*/
        public virtual ICollection<Course> Courses { get; set; }
    }

    
}
