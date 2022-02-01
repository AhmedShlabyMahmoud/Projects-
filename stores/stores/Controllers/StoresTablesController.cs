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
    public class StoresTablesController : Controller
    {
        private StoresEntities1 db = new StoresEntities1();

        // GET: StoresTables
        public ActionResult Index()
        {
            return View(db.StoresTables.ToList());
        }

        // GET: StoresTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoresTable storesTable = db.StoresTables.Find(id);
            if (storesTable == null)
            {
                return HttpNotFound();
            }
            return View(storesTable);
        }

        // GET: StoresTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoresTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameStores")] StoresTable storesTable)
        {
            if (ModelState.IsValid)
            {
                db.StoresTables.Add(storesTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storesTable);
        }

        // GET: StoresTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoresTable storesTable = db.StoresTables.Find(id);
            if (storesTable == null)
            {
                return HttpNotFound();
            }
            return View(storesTable);
        }

        // POST: StoresTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameStores")] StoresTable storesTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storesTable);
        }

        // GET: StoresTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoresTable storesTable = db.StoresTables.Find(id);
            if (storesTable == null)
            {
                return HttpNotFound();
            }
            return View(storesTable);
        }

        // POST: StoresTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoresTable storesTable = db.StoresTables.Find(id);
            db.StoresTables.Remove(storesTable);
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
