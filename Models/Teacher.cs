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
        [StringLength(60, MinimumLength = 3)]
        [Display(Name ="Name")]
        public string TeacherName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string TeacherEmail { get; set; }
        [Required]
        [Display(Name ="Address")]
        [StringLength(100, MinimumLength = 4)]
        public string TeacherAddress { get; set; }
        [Required]
        [Phone]
        [Display(Name ="Contact Number")]
        public string TeacherContactNo { get; set; }
        [Required]
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Required]
        [Display(Name ="Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
