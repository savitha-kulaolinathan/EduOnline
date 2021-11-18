using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentReport.Models
{
    public class Min18YearsIfSTudent:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (Student)validationContext.ObjectInstance;   
            if (student.BirthDate == null)
                return new ValidationResult("Birthdate is required.");
            var age = DateTime.Today.Year - student.BirthDate.Value.Year;
            return (age >= 18) ? ValidationResult.Success
                : new ValidationResult("Student should be atleast 18 years old.");


        }
    }
}