using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name ="Name")]
        [StringLength(60, MinimumLength = 4)]
        public string DepartmentName { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        
    }
}
