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

        
        [StudentCourseValidate(ErrorMessage = "You cannot select more than 2 courses")]
        public ICollection<int> StudentCourses { get; set; }
    }
}
