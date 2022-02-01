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
    public class ItemsTablesController : Controller
    {
        private StoresEntities1 db = new StoresEntities1();

        // GET: ItemsTables
        public ActionResult Index()
        {
            return View(db.ItemsTables.ToList());
        }

        // GET: ItemsTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemsTable itemsTable = db.ItemsTables.Find(id);
            if (itemsTable == null)
            {
                return HttpNotFound();
            }
            return View(itemsTable);
        }

        // GET: ItemsTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemsTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,SellPrice")] ItemsTable itemsTable)
        {
            if (ModelState.IsValid)
            {
                db.ItemsTables.Add(itemsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemsTable);
        }

        // GET: ItemsTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemsTable itemsTable = db.ItemsTables.Find(id);
            if (itemsTable == null)
            {
                return HttpNotFound();
            }
            return View(itemsTable);
        }

        // POST: ItemsTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,SellPrice")] ItemsTable itemsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemsTable);
        }

        // GET: ItemsTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemsTable itemsTable = db.ItemsTables.Find(id);
            if (itemsTable == null)
            {
                return HttpNotFound();
            }
            return View(itemsTable);
        }

        // POST: ItemsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemsTable itemsTable = db.ItemsTables.Find(id);
            db.ItemsTables.Remove(itemsTable);
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
