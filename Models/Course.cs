using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentReport.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }
        [Display(Name = "Tutor Name")]
        public string TutorName { get; set; }
        [Display(Name = "Course  Rating")]
        [Range(1,10)]
        public int CourseRating { get; set; }
    }

   
}