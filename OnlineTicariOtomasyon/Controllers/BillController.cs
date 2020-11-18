using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class BillController : Controller
    {

        Context c = new Context();

        public ActionResult Index()
        {
            var list = c.Bills.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddBill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBill(Bill bill)
        {
            c.Bills.Add(bill);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetBills(int id)
        {
            var bills = c.Bills.Find(id);
            return View("GetBills", bills);
        }
        public ActionResult UpdateBill(Bill bill)
        {
            var x = c.Bills.Find(bill.BillID);
            x.BillSerialNo = bill.BillSerialNo;
            x.BillOrderNo = bill.BillOrderNo;
            x.TaxAdministration = bill.TaxAdministration;
            x.Date = bill.Date;
            x.Hour = bill.Hour;
            x.DeliveryPerson = bill.DeliveryPerson;
            x.Receiver = bill.Receiver;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BillDetails(int id)
        {
            var values = c.BillNotes.Where(x => x.BillID == id).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewBillNote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewBillNote(BillNote note)
        {
            c.BillNotes.Add(note);
            c.SaveChanges();
            return View();
        }
    }
}