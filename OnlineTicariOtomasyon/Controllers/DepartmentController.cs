using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        Context c = new Context();
        // GET: Department
        public ActionResult Index()
        {
            var values = c.Departments.Where(x=>x.Status== true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Status = false;   
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDepartment(int id)
        {
            var x = c.Departments.Find(id);
            return View("GetDepartment", x);
        }

        public ActionResult UpdateDepartment(Department d)
        {
            var dep = c.Departments.Find(d.DepartmentID);
            dep.DepartmentName = d.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDetail(int id)
        {
            var values = c.Stuffs.Where(x => x.DepartmentId == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(values);
        }
        public ActionResult DepartmentStuffSales(int id)
        {
            var values = c.SalesMovements.Where(x => x.StuffId == id).ToList();
            var stuff = c.Stuffs.Where(x => x.StaffID == id).Select(y => y.StaffName + " " + y.StuffSurname).FirstOrDefault();
            ViewBag.getStuff = stuff;
            return View(values);

        }

    }
}