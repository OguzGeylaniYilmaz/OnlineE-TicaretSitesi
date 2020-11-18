using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {

        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentEmail"];
            var values = c.Currents.FirstOrDefault(x => x.CurrentEmail == mail);
            return View();
        }

        public ActionResult MyOrders()
        {
            var mail = (string)Session["CurrentEmail"];
            var id = c.Currents.Where(x => x.CurrentEmail == mail.ToString()).Select(y => y.CurrentID).FirstOrDefault();
            var values = c.SalesMovements.Where(z => z.CurrentId == id).ToList();
            return View(values);
        }

    }
}