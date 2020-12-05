using CollegeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Attributes
{
    public class StudentCourseValidateAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            List<int> instance = value as List<int>;
            int count = instance.Count();
            if (count <= 2)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }

    }
}
