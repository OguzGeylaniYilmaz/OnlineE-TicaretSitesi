using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class QRController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string code)
        {
            using (MemoryStream Ms = new MemoryStream())
            {
                QRCodeGenerator generator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qRCode = generator.CreateQrCode(code,QRCodeGenerator.ECCLevel.Q);
                using (Bitmap pic = qRCode.GetGraphic(10))
                {
                    pic.Save(Ms, ImageFormat.Png);
                    ViewBag.qrImage = "data:image/png;base64," + Convert.ToBase64String(Ms.ToArray());
                }
            }

            return View();
        }
    }
}