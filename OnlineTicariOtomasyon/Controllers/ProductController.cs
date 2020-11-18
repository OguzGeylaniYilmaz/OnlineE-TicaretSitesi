using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context c = new Context();
        // GET: Product
        public ActionResult Index(string p)
        {
            //var products = c.Products.Where(x => x.Status == true).ToList();
            var products = from x in c.Products select x;
            if(!string.IsNullOrEmpty(p))
            {
                products = products.Where(y => y.ProductName.Contains(p)); 
            }

            return View(products.ToList());
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> value = (from x in c.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();

            ViewBag.getValue = value;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var value = c.Products.Find(id);
            //value.Status = false;
            c.Products.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int id)
        {
            
            List<SelectListItem> value = (from x in c.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();

            ViewBag.getValue = value;
            var product = c.Products.Find(id);
            return View("GetProduct", product);

        }

        public ActionResult UpdateProduct(Product p)
        {
            var product = c.Products.Find(p.ProductID);
            product.Brand = p.Brand;
            product.SalePrice = p.SalePrice;
            product.PurchasePrice = p.PurchasePrice;
            product.Status = p.Status;
            product.Stock = p.Stock;
            product.ProductName = p.ProductName;
            product.ProductImage = p.ProductImage;
            product.CategoryId = p.CategoryId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var x = c.Products.ToList();
            return View(x);
        }

        [HttpGet]
        public ActionResult SaleProduct(int id)
        {
            List<SelectListItem> value = (from x in c.Stuffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName + " " + x.StuffSurname,
                                               Value = x.StaffID.ToString()
                                           }).ToList();
            var value2 = c.Products.Find(id);

            ViewBag.sale = value;
            ViewBag.vle2 = value2.ProductID;
            ViewBag.vle3 = value2.SalePrice;
            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(SalesMovement sales)
        {

            sales.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(sales);
            c.SaveChanges();
            return RedirectToAction("Sales","Index");
        }
    }
}