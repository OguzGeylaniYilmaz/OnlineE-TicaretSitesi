using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial(Current c)
        {
            context.Currents.Add(c);
            context.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult Partial2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Partial2(Current current)
        {
            var values = context.Currents.FirstOrDefault(x => x.CurrentEmail == current.CurrentEmail && x.CurrentPassword == current.CurrentPassword);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.CurrentEmail, false);
                Session["CurrentEmail"] = values.CurrentEmail.ToString();
                return RedirectToAction("Index", "Partial2");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
           
        }


        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var values = context.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["UserName"] = values.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
    }
}