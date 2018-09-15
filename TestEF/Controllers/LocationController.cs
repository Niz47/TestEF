using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestEF.Models;

namespace TestEF.Controllers
{
    public class LocationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Location()
        {
            string markers = "[";
            List<Locations> locations = db.Locations.ToList();
            foreach(Locations l in locations)
            {
                markers += "{";
                markers += string.Format("'title': '{0}',", l.CityName);
                markers += string.Format("'lat': '{0}',", l.Latitude);
                markers += string.Format("'lng': '{0}',", l.Longitude);
                markers += string.Format("'description': '{0}'", l.Description);
                markers += "},";
            }
            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }

        [HttpPost]
        public ActionResult Location(Locations location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
            }
            else
            {

            }
            return RedirectToAction("Location");
        }


    }
}