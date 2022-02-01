using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using stores;

namespace stores.Controllers
{
    public class SafesController : Controller
    {
        private StoresEntities1 db = new StoresEntities1();

        // GET: Safes
        public ActionResult Index()
        {
            return View(db.Safes.ToList());
        }

        // GET: Safes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Safe safe = db.Safes.Find(id);
            if (safe == null)
            {
                return HttpNotFound();
            }
            return View(safe);
        }

        // GET: Safes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Safes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name_safe")] Safe safe)
        {
            if (ModelState.IsValid)
            {
                db.Safes.Add(safe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(safe);
        }

        // GET: Safes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Safe safe = db.Safes.Find(id);
            if (safe == null)
            {
                return HttpNotFound();
            }
            return View(safe);
        }

        // POST: Safes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name_safe")] Safe safe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(safe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(safe);
        }

        // GET: Safes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Safe safe = db.Safes.Find(id);
            if (safe == null)
            {
                return HttpNotFound();
            }
            return View(safe);
        }

        // POST: Safes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Safe safe = db.Safes.Find(id);
            db.Safes.Remove(safe);
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
