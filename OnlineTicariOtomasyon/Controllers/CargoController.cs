using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        Context context = new Context();

        public ActionResult Index(string p)
        {

            var cargo = from x in context.CargoDetails select x;

            if (!string.IsNullOrEmpty(p))
            {
                cargo = cargo.Where(y => y.TrackingCode.Contains(p));
            }

            return View(cargo.ToList());
        }

        [HttpGet]
        public ActionResult NewCargo()
        {
            Random rnd = new Random();
            string[] characters = { "A", "B", "C", "D", "E", "F", "G", "H", "K" };
            int k1, k2, k3;
            k1 = rnd.Next(0, characters.Length);
            k2 = rnd.Next(0, characters.Length);
            k3 = rnd.Next(0, characters.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string code = s1.ToString() + characters[k1] + s2.ToString() + characters[k2] + s3.ToString() + characters[k3];
            ViewBag.trackingCode = code; 
            return View();
        }
        [HttpPatch]
        public ActionResult NewCargo(CargoDetail cargo)
        {
            context.CargoDetails.Add(cargo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CargoTracking(string id )
        {
            var values = context.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(values);
        }
    }
}