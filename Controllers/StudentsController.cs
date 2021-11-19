using StudentReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using StudentReport.ViewModel;
using System.Data.Entity.Validation;

namespace StudentReport.Controllers
{
    public class StudentsController : Controller
    {
        private StudentReportContext _context;

        public StudentsController()
        {
            _context = new StudentReportContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var courses = _context.Courses.ToList();
            var viewModel = new NewStudentViewModel
            {
                Student = new Student(),
                Courses = courses
            };
            return View( "New",viewModel);
        }
            public ActionResult Index()
        {
            var students = _context.Students.Include(s => s.Course).ToList();
            return View(students);
        }
        
        //Both create  and update
        [HttpPost]
        public ActionResult Update(Student student)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new NewStudentViewModel
                {
                    Student = student,
                    Courses = _context.Courses.ToList()
                };
                return View("New", viewModel);
            }
            if (student.Id == 0)
                _context.Students.Add(student);
            else
            {
                var studentInDb = _context.Students.Single(s => s.Id == student.Id);
                studentInDb.FirstName = student.FirstName;
                studentInDb.LastName = student.LastName;
                studentInDb.CourseId = student.CourseId;
                studentInDb.CourseEnrolledDate = student.CourseEnrolledDate;
                studentInDb.CourseStatus = student.CourseStatus;
                studentInDb.Grade = student.Grade;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Students");

        }
        //Edit  action
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
                return HttpNotFound();
            var viewModel = new NewStudentViewModel
            {
                Student = student,
                Courses = _context.Courses.ToList()


            };
            return View("New", viewModel);
        }


        // Delete action
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var students = _context.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }

            return View(students);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index", "Students");

        }
    }
}