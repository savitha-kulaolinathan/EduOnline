using StudentReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentReport.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        private StudentReportContext _context;
        public CoursesController()
        {
            _context = new StudentReportContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Index()
        {
            var courses = _context.Courses.ToList();

            return View(courses);
        }
        [HttpPost]
        public ActionResult Update(Course course)
        {

            if (course.Id == 0)
                _context.Courses.Add(course);
            else
            {
                var courseInDb = _context.Courses.Single(s => s.Id == course.Id);
                courseInDb.CourseName = course.CourseName;
                courseInDb.CourseDescription = course.CourseDescription;
                courseInDb.TutorName = course.TutorName;
                courseInDb.CourseRating = course.CourseRating;
                
            }

            _context.Courses.Add(course);
            _context.SaveChanges();
             return RedirectToAction("Index", "Courses");
        }


        public ActionResult Edit(int? id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (course == null)
                return HttpNotFound();
            _context.SaveChanges();

            return View("New", course);
            
        }
        public ActionResult Delete(int? id)
        {
            var courses = _context.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }

            return View(courses);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.Find(id);
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("Index", "Courses");

        }
    }
}