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
    public class ColleaguesController : Controller
    {
        private WhoseShoutDBEntities db = new WhoseShoutDBEntities();

        // GET: Colleagues
        public ActionResult Index()
        {
            return View(db.Colleagues.ToList());
        }

        // GET: Colleagues/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colleague colleague = db.Colleagues.Find(id);
            if (colleague == null)
            {
                return HttpNotFound();
            }
            return View(colleague);
        }

        // GET: Colleagues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colleagues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColleagueId,name,email")] Colleague colleague)
        {
            if (ModelState.IsValid)
            {
                db.Colleagues.Add(colleague);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colleague);
        }

        // GET: Colleagues/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colleague colleague = db.Colleagues.Find(id);
            if (colleague == null)
            {
                return HttpNotFound();
            }
            return View(colleague);
        }

        // POST: Colleagues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColleagueId,name,email")] Colleague colleague)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colleague).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colleague);
        }

        // GET: Colleagues/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colleague colleague = db.Colleagues.Find(id);
            if (colleague == null)
            {
                return HttpNotFound();
            }
            return View(colleague);
        }

        // POST: Colleagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Colleague colleague = db.Colleagues.Find(id);
            db.Colleagues.Remove(colleague);
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
