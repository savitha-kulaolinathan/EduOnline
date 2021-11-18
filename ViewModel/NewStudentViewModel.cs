using StudentReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentReport.ViewModel
{
    public class NewStudentViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public Student Student { get; set; }
    }
}