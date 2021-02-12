using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
    public class StudentController : Controller
    {

        static IList<Student> studentList = new List<Student>{
                new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 20 } ,
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 17 } ,
                new Student() { StudentId = 7, StudentName = "Rob" , Age = 19 }
            };

        // GET: Student
        public ActionResult Index()
        {
            return View(studentList.OrderBy(s => s.StudentId).ToList());
        }
        //[NonAction]
        //public Student GetStudent(int id)
        //{
        //    return studentList.Where(s => s.StudentId == id).FirstOrDefault();
        //}
        //[ActionName("Find")]
        //public ActionResult GetById(int id)
        //{
        //    // get student from the database 
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Edit(Student std)
        //{
        //    // update student to the database

        //    return RedirectToAction("Index");
        //}

        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    // delete student from the database whose id matches with specified id

        //    return RedirectToAction("Index");
        //}
        public ActionResult Edit(int Id)
        {
            //here, get the student from the database in the real application

            //getting a student from collection for demo purpose
            var std = studentList.Where(s => s.StudentId == Id).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(Student std)
        {
            //update student in DB using EntityFramework in real-life application

            //update list by removing old student and adding updated student for demo purpose
            var student = studentList.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
            studentList.Remove(student);
            studentList.Add(std);

            return RedirectToAction("Index");
        }
    }
}