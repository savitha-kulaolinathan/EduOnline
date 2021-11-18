using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentReport.Models
{
    public class StudentReportContext : DbContext
    {
        internal object course;

        public StudentReportContext() : base("name=StudentReport")
        {
        }
            public DbSet<Student> Students { get; set; }
            public DbSet<Course> Courses { get; set; }
    
    

    }
}