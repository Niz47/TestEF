using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestEF.Models;

namespace TestEF.Controllers
{
    public class UploadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                    db.Image.Add(new ImageM { ImageName = Path.GetFileNameWithoutExtension(file.FileName), ImagePath = _FileName });
                    db.SaveChanges();
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ShowImage()
        {
            return View(db.Image.ToList());
        }
    }
}