using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;


namespace OnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {

        Context c = new Context();

        public ActionResult Index()
        {
            var pics = c.Products.ToList();
            return View(pics);
        }
    }
}