using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Required]
        [EmailAddress]
        public string TeacherEmail { get; set; }
        [Required]
        public string TeacherAddress { get; set; }
        [Required]
        [Phone]
        public string TeacherContactNo { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
