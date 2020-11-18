using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class StuffController : Controller
    {
        Context c = new Context();
        // GET: Stuff
        public ActionResult Index()
        {
            var values = c.Stuffs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddStuff()
        {
            List<SelectListItem> value = (from x in c.Departments.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmentName,
                                              Value = x.DepartmentID.ToString()
                                          }).ToList();

            ViewBag.getStuff = value;
            return View();
        }

        [HttpPost]
        public ActionResult AddStuff(Stuff s)
        {

            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                s.StuffImage = "/Image/" + fileName + extension;
            }
            c.Stuffs.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetStuff(int id)
        {
            List<SelectListItem> value = (from x in c.Departments.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmentName,
                                              Value = x.DepartmentID.ToString()
                                          }).ToList();
            ViewBag.getStuff = value;
            var stf = c.Stuffs.Find(id);
            return View("GetStuff", stf);
        }

        public ActionResult UpdateStuff(Stuff stuff)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                stuff.StuffImage = "/Image/" + fileName + extension;
            }
            var x = c.Stuffs.Find(stuff.StaffID);
            x.StaffName = stuff.StaffName;
            x.StuffSurname = stuff.StuffSurname;
            x.StuffImage = stuff.StuffImage;
            x.DepartmentId = stuff.DepartmentId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StaffList()
        {
            var x = c.Stuffs.ToList();
            return View(x);
        }
    }
}