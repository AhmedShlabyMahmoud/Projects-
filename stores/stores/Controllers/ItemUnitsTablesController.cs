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
    public class ItemUnitsTablesController : Controller
    {
        private StoresEntities1 db = new StoresEntities1();

        // GET: ItemUnitsTables
        public ActionResult Index()
        {
            var itemUnitsTables = db.ItemUnitsTables.Include(i => i.ItemsTable);
            return View(itemUnitsTables.ToList());
        }

        // GET: ItemUnitsTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemUnitsTable itemUnitsTable = db.ItemUnitsTables.Find(id);
            if (itemUnitsTable == null)
            {
                return HttpNotFound();
            }
            return View(itemUnitsTable);
        }

        // GET: ItemUnitsTables/Create
        public ActionResult Create()
        {
            ViewBag.Item_ID = new SelectList(db.ItemsTables, "ID", "Name");
            return View();
        }

        // POST: ItemUnitsTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Unit_Name,Quantity,Item_ID")] ItemUnitsTable itemUnitsTable)
        {
            if (ModelState.IsValid)
            {
                db.ItemUnitsTables.Add(itemUnitsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Item_ID = new SelectList(db.ItemsTables, "ID", "Name", itemUnitsTable.Item_ID);
            return View(itemUnitsTable);
        }

        // GET: ItemUnitsTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemUnitsTable itemUnitsTable = db.ItemUnitsTables.Find(id);
            if (itemUnitsTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Item_ID = new SelectList(db.ItemsTables, "ID", "Name", itemUnitsTable.Item_ID);
            return View(itemUnitsTable);
        }

        // POST: ItemUnitsTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Unit_Name,Quantity,Item_ID")] ItemUnitsTable itemUnitsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemUnitsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Item_ID = new SelectList(db.ItemsTables, "ID", "Name", itemUnitsTable.Item_ID);
            return View(itemUnitsTable);
        }

        // GET: ItemUnitsTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemUnitsTable itemUnitsTable = db.ItemUnitsTables.Find(id);
            if (itemUnitsTable == null)
            {
                return HttpNotFound();
            }
            return View(itemUnitsTable);
        }

        // POST: ItemUnitsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemUnitsTable itemUnitsTable = db.ItemUnitsTables.Find(id);
            db.ItemUnitsTables.Remove(itemUnitsTable);
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
