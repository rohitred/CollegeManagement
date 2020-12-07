using CollegeManagement.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models.ViewModel
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            StudentCourses = new List<int>();
        }
        [Key]
        public int StudentId { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string StudentName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
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
        [Display(Name = "Email")]
        public string StudentEmail { get; set; }

        
        [StudentCourseValidate(ErrorMessage = "You cannot select more than 2 courses")]
        [Display(Name = "Courses")]
        public ICollection<int> StudentCourses { get; set; }
    }
}
