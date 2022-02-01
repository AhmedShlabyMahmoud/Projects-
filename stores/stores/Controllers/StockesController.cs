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
    public class StockesController : Controller
    {
        private StoresEntities1 db = new StoresEntities1();

        // GET: Stockes
        public ActionResult Index()
        {
            var stockes = db.Stockes.Include(s => s.ItemsTable).Include(s => s.StoresTable);
            return View(stockes.ToList());
        }
        // GET: Stockes/Details/5
        public ActionResult Details(int? id)
        {
           
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stocke stocke = db.Stockes.Find(id);
            if (stocke == null)
            {
                return HttpNotFound();
            }
            return View(stocke);
        }

        // GET: Stockes/Create
        public ActionResult Create()
        {
            ViewBag.Item_ID = new SelectList(db.ItemsTables, "ID", "Name");
            ViewBag.Store_ID = new SelectList(db.StoresTables, "ID", "NameStores");
            return View();
        }

        // POST: Stockes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Store_ID,Item_ID,Quantity")] Stocke stocke)
        {
            if (ModelState.IsValid)
            {

                Stocke S = new Stocke();
                S = db.Stockes.FirstOrDefault(e => e.Store_ID == stocke.Store_ID && e.Item_ID == stocke.Item_ID);
                // S = db.Stockes.FirstOrDefault(e => e.Id == id);
                if (S == null)
                    db.Stockes.Add(stocke);
                else
                {
                    int a=0;
                    a = S.Quantity;
                    a += stocke.Quantity;
                    S.Quantity =a;
                }       
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Item_ID = new SelectList(db.ItemsTables, "ID", "Name", stocke.Item_ID);
            ViewBag.Store_ID = new SelectList(db.StoresTables, "ID", "NameStores", stocke.Store_ID);
            return View(stocke);
        }

        // GET: Stockes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stocke stocke = db.Stockes.Find(id);
            if (stocke == null)
            {
                return HttpNotFound();
            }
            ViewBag.Item_ID = new SelectList(db.ItemsTables, "ID", "Name", stocke.Item_ID);
            ViewBag.Store_ID = new SelectList(db.StoresTables, "ID", "NameStores", stocke.Store_ID);
            return View(stocke);
        }

        // POST: Stockes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Store_ID,Item_ID,Quantity")] Stocke stocke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stocke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Item_ID = new SelectList(db.ItemsTables, "ID", "Name", stocke.Item_ID);
            ViewBag.Store_ID = new SelectList(db.StoresTables, "ID", "NameStores", stocke.Store_ID);
            return View(stocke);
        }

        // GET: Stockes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stocke stocke = db.Stockes.Find(id);
            if (stocke == null)
            {
                return HttpNotFound();
            }
            return View(stocke);
        }

        // POST: Stockes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stocke stocke = db.Stockes.Find(id);
            db.Stockes.Remove(stocke);
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
