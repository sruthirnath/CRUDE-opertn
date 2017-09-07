using StudentManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagmentSystem.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()

        {
            DetailsContext obj = new DetailsContext();
            List<Student> Students=obj.Students.ToList();
            return View(Students);
        }

        public ActionResult createnew4()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createnew4(Student s)
        {
            DetailsContext obj = new DetailsContext();
            obj.Students.Add(s);
            obj.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult delete(int id )
        {
            DetailsContext obj = new DetailsContext();
            Student Students= obj.Students.Where(c => c.ID == id).FirstOrDefault();
            obj.Students.Remove(Students);
            obj.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult edit(int id)
        {
            DetailsContext obj = new DetailsContext();
            Student Students = obj.Students.Where(c => c.ID == id).FirstOrDefault();
            return View(Students);


        }
        [HttpPost]
        public ActionResult edit(Student s)
        {
            DetailsContext obj = new DetailsContext();
            Student Students = obj.Students.Where(c => c.ID == s.ID).FirstOrDefault();
           obj.Entry(Students).CurrentValues.SetValues(s);
           obj.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchResults(String name)
        {
            DetailsContext obj = new DetailsContext();
            Student Students = obj.Students.Where(c => c.Name == name).FirstOrDefault();

            return PartialView(Students);
        }

        public JsonResult validation(string Name)
        {
            DetailsContext db = new DetailsContext();
            bool isvalid = true;
            string um = (from b in db.Students where b.Name == Name select b.Name).FirstOrDefault();
            if (um != null)
               isvalid = false;
           
            return Json(isvalid, JsonRequestBehavior.AllowGet);
        }

    }
}