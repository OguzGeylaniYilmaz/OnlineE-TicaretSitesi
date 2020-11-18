using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        Context context = new Context();
        // GET: Category
        public ActionResult Index(int page = 1)
        {

            var values = context.Categories.ToList().ToPagedList(page, 4);

            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category ctg)
        {
            context.Categories.Add(ctg);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var cat = context.Categories.Find(id);
            context.Categories.Remove(cat);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCategory(int id)
        {
            var ctg = context.Categories.Find(id);
            return View("GetCategory", ctg);

        }
        public ActionResult UpdateCategory(Category ctg)
        {
            var x = context.Categories.Find(ctg.CategoryID);
            x.CategoryName = ctg.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}