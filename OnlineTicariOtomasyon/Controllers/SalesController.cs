using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        Context c = new Context();
        // GET: Sales
        public ActionResult Index()
        {
            var values = c.SalesMovements.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewSale()
        {
            List<SelectListItem> value = (from x in c.Products.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ProductName,
                                              Value = x.ProductID.ToString()
                                          }).ToList();
            List<SelectListItem> value2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Stuffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName + " " + x.StuffSurname,
                                               Value = x.StaffID.ToString()
                                           }).ToList();
            ViewBag.vle = value;
            ViewBag.vle2 = value2;
            ViewBag.vle3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(SalesMovement sales)
        {
            sales.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var x = c.SalesMovements.Add(sales);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetSales(int id)
        {

            List<SelectListItem> value = (from x in c.Products.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ProductName,
                                              Value = x.ProductID.ToString()
                                          }).ToList();
            List<SelectListItem> value2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Stuffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName + " " + x.StuffSurname,
                                               Value = x.StaffID.ToString()
                                           }).ToList();
            ViewBag.vle = value;
            ViewBag.vle2 = value2;
            ViewBag.vle3 = value3;
            var values = c.SalesMovements.Find(id);
            return View("GetSales", values);
        }

        public ActionResult UpdateSales(SalesMovement sales)
        {
            var x = c.SalesMovements.Find(sales.SalesID);
            x.CurrentId = sales.CurrentId;
            x.Piece = sales.Piece;
            x.Price = sales.Price;
            x.StuffId = sales.StuffId;
            x.Date = sales.Date;
            x.TotalAmount = sales.TotalAmount;
            x.ProductId = sales.ProductId;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult SalesDetail(int id)
        {
            var values = c.SalesMovements.Where(x => x.SalesID == id).ToList();
            return View(values);
        }

    }
}