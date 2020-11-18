using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var totalCurrent = c.Currents.Count().ToString();
            var totalProducts = c.Products.Count().ToString();
            var totalStaffs = c.Stuffs.Count().ToString();
            var totalCategories = c.Categories.Count().ToString();
            var totalStock = c.Products.Sum(x => x.Stock).ToString();
            var totalBrands = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            var criticalProduct = c.Products.Count(x => x.Stock < 20).ToString();
            var maxPriceProduct = (from p in c.Products orderby p.SalePrice descending select p.ProductName).FirstOrDefault();
            var minPriceProduct = (from p in c.Products orderby p.SalePrice ascending select p.ProductName).FirstOrDefault();
            var totalIphone = c.Products.Count(x => x.ProductName == "IPhone 6S").ToString();
            var totalLaptops = c.Products.Count(x => x.Category.CategoryName == "Computer").ToString();
            var moneySafe = c.SalesMovements.Sum(x => x.TotalAmount).ToString();
            var topSaller = c.Products.Where(p => p.ProductID == (c.SalesMovements.GroupBy(x => x.ProductId).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();

            DateTime time = DateTime.Today;
            var todaysSale = c.SalesMovements.Count(x => x.Date == time).ToString();
            var todaysSafe = c.SalesMovements.Where(x => x.Date == time).Sum(y => (decimal?)y.TotalAmount).ToString();
            var maxBrand = c.Products.GroupBy(x => x.Brand).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();

            ViewBag.current = totalCurrent;
            ViewBag.product = totalProducts;
            ViewBag.staff = totalStaffs;
            ViewBag.category = totalCategories;
            ViewBag.stock = totalStock;
            ViewBag.brand = totalBrands;
            ViewBag.critic = criticalProduct;
            ViewBag.maxPrice = maxPriceProduct;
            ViewBag.minPrice = minPriceProduct;
            ViewBag.ıphone = totalIphone;
            ViewBag.laptop = totalLaptops;
            ViewBag.money = moneySafe;
            ViewBag.todaySale = todaysSale;
            ViewBag.todaySafe = todaysSafe;
            ViewBag.brand = maxBrand;
            ViewBag.saller = topSaller;

            return View();
        }

        public ActionResult EasyTables()
        {
            var query = from x in c.Currents
                        group x by x.CurrentCity into g
                        select new ClassGroup
                        {
                            City = g.Key,
                            Number = g.Count()
                        };

            return View(query.ToList());
        }

        public PartialViewResult Partial()
        {
            var query2 = from x in c.Stuffs
                         group x by x.Department.DepartmentName into g
                         select new ClassGroup2
                         {
                             Department = g.Key,
                             Number = g.Count()
                         };

            return PartialView(query2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var query = c.Currents.ToList();
            return PartialView(query);
        }

        public PartialViewResult Partial3()
        {
            var query = c.Products.ToList();
            return PartialView(query);
        }

        public PartialViewResult Partial4()
        {

            var query = from x in c.Products group x by x.Brand into g
                        select new ClassGroup3
                        {
                            Brand = g.Key,
                            Number = g.Count()
                        };
            return PartialView(query.ToList());
        }
    }
}