using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        Context c = new Context();
        // GET: Current
        public ActionResult Index()
        {
            var crt = c.Currents.Where(x => x.Status == true).ToList();
            return View(crt);
        }
        [HttpGet]
        public ActionResult NewCurrent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCurrent(Current current)
        {
            current.Status = true;
            c.Currents.Add(current);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCurrent(int id)
        {
            var x = c.Currents.Find(id);
            x.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCurrent(int id)
        {
            var x = c.Currents.Find(id);
            return View("GetCurrent",x);
        }

        public ActionResult UpdateCurrent(Current current)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCurrent");
            }
            var x = c.Currents.Find(current.CurrentID);
            x.CurrentName = current.CurrentName;
            x.CurrentSurname = current.CurrentSurname;
            x.CurrentCity = current.CurrentCity;
            x.CurrentEmail = current.CurrentEmail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerSales(int id)
        {
            var values = c.SalesMovements.Where(x => x.CurrentId == id).ToList();
            var crt = c.Currents.Where(x => x.CurrentID == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.crrnt = crt;
            return View(values);
        }
    }
}