using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Models;
using MyApp.DB.DBOperations;

namespace MVSTASK3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        StudentRepository repository = null;
        public HomeController()
        {
            repository = new StudentRepository();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentModel model)
        {
            if(ModelState.IsValid)
            {
                int id = repository.AddStudent(model);
                if(id > 0)
                {
                    ModelState.Clear();
                    ViewBag.issuccess = "Data Added";
                    
                }
            }
            return View();
        }

        public ActionResult GetAllRecords()
        {
            var result = repository.GetAllStudent();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var Student = repository.GetStudent(id);
            return View(Student);
        }

        public ActionResult Edit(int id)
        {
            var Student = repository.GetStudent(id);
            return View(Student);
        }
        [HttpPost]
        public ActionResult Edit(StudentModel model)
        {
            if(ModelState.IsValid)
            {
                repository.UpdateStudent(model.Id, model);
                return RedirectToAction("GetAllRecords");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            repository.DeleteStudent(id);
            return RedirectToAction("getAllRecords");
        }
    }
}