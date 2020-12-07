using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [Display(Name ="Name")]
        [StringLength(60, MinimumLength = 4)]
        public string CourseName { get; set; }
        [Required]
        [Display(Name ="Course Code")]
        public string CourseCode { get; set; }
        [Required]
        [Display(Name ="Course Description")]
        public string CourseDescription { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
