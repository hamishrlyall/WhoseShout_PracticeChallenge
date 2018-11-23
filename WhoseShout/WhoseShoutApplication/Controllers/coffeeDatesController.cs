using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WhoseShoutApplication.Models;

namespace WhoseShoutApplication.Controllers
{
    [Authorize]
    public class coffeeDatesController : Controller
    {
        private WhoseShoutDBEntities db = new WhoseShoutDBEntities();

        // GET: coffeeDates
        public ActionResult Index()
        {
            var coffeeDates = db.coffeeDates.Include(c => c.Colleague);
            return View(coffeeDates.ToList());
        }

        // GET: coffeeDates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coffeeDate coffeeDate = db.coffeeDates.Find(id);
            if (coffeeDate == null)
            {
                return HttpNotFound();
            }
            return View(coffeeDate);
        }

        // GET: coffeeDates/Create
        public ActionResult Create()
        {
            ViewBag.email = new SelectList(db.Colleagues, "email", "name");
            return View();
        }

        // POST: coffeeDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "coffeeDateID,name,email,dateTime,venue")] coffeeDate coffeeDate)
        {
            if (ModelState.IsValid)
            {
                db.coffeeDates.Add(coffeeDate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.email = new SelectList(db.Colleagues, "email", "name", coffeeDate.email);
            return View(coffeeDate);
        }

        // GET: coffeeDates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coffeeDate coffeeDate = db.coffeeDates.Find(id);
            if (coffeeDate == null)
            {
                return HttpNotFound();
            }
            ViewBag.email = new SelectList(db.Colleagues, "email", "name", coffeeDate.email);
            return View(coffeeDate);
        }

        // POST: coffeeDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "coffeeDateID,name,email,dateTime,venue")] coffeeDate coffeeDate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffeeDate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.email = new SelectList(db.Colleagues, "email", "name", coffeeDate.email);
            return View(coffeeDate);
        }

        // GET: coffeeDates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coffeeDate coffeeDate = db.coffeeDates.Find(id);
            if (coffeeDate == null)
            {
                return HttpNotFound();
            }
            return View(coffeeDate);
        }

        // POST: coffeeDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            coffeeDate coffeeDate = db.coffeeDates.Find(id);
            db.coffeeDates.Remove(coffeeDate);
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
