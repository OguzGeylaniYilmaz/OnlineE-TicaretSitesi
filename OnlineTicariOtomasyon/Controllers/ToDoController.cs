using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ToDoController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var value = c.Currents.Count().ToString();
            ViewBag.vle = value;
            var value2 = c.Products.Count().ToString();
            ViewBag.vle2 = value2;
            var value3 = c.Categories.Count().ToString();
            ViewBag.vle3 = value3;
            var value4 = (from x in c.Currents select x.CurrentCity).Distinct().Count().ToString();
            ViewBag.vle4 = value4;

            var todolist = c.ToDos.ToList();
            return View(todolist);
        }
    }
}