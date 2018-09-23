using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestEF.Models;

namespace TestEF.Controllers
{
    public class GroceryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Grocery
        public ActionResult Index()
        {
            return View(db.grocery_list.ToList());
        }

        // GET: Grocery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grocery_list grocery_list = db.grocery_list.Find(id);
            if (grocery_list == null)
            {
                return HttpNotFound();
            }
            return View(grocery_list);
        }

        // GET: Grocery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grocery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "grocery_id,grocery_item,grocery_amount")] grocery_list grocery_list)
        {
            if (ModelState.IsValid)
            {
                db.grocery_list.Add(grocery_list);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grocery_list);
        }

        // GET: Grocery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grocery_list grocery_list = db.grocery_list.Find(id);
            if (grocery_list == null)
            {
                return HttpNotFound();
            }
            return View(grocery_list);
        }

        // POST: Grocery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "grocery_id,grocery_item,grocery_amount")] grocery_list grocery_list)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grocery_list).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grocery_list);
        }

        // GET: Grocery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grocery_list grocery_list = db.grocery_list.Find(id);
            if (grocery_list == null)
            {
                return HttpNotFound();
            }
            return View(grocery_list);
        }

        // POST: Grocery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            grocery_list grocery_list = db.grocery_list.Find(id);
            db.grocery_list.Remove(grocery_list);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
