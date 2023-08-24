using Microsoft.AspNetCore.Mvc;
using StudentEx.Models;
using StudentEx.PersistanceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEx.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Student s)
        {

            StudentContext.GetStudent(s);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult List()
        {
            List<Student> student = StudentContext.ListOfStudents();
            return View(student);
        }
        
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Student student = StudentContext.GetStudentById(Id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(int id,Student s)
        {
            StudentContext.EditStudent(id,s);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Student student = StudentContext.GetStudentById(Id);
            return View(student);
        }
        
    }

}
