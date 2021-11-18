using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentReport.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter Student's first name.")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]       
        public string LastName { get; set; }
        
        [Display(Name = "Date of birth")]
        [Min18YearsIfSTudent]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Course Name")]
        public Course Course { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Display(Name = "Date of Enrollment")]
        public DateTime? CourseEnrolledDate { get; set; }
        [Display(Name ="Course Status")]
        public int CourseStatus { get; set; }
        public string Grade { get; set; }
    }
}

