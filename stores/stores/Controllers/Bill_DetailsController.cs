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
    public class Bill_DetailsController : Controller
    {
        private StoresEntities1 db = new StoresEntities1();

        // GET: Bill_Details
        public ActionResult Index()
        {
            var bill_Details = db.Bill_Details.Include(b => b.Bill_Head).Include(b => b.ItemsTable);
            return View(bill_Details.ToList());
        }

        // GET: Bill_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Details bill_Details = db.Bill_Details.Find(id);
            if (bill_Details == null)
            {
                return HttpNotFound();
            }
            return View(bill_Details);
        }

        // GET: Bill_Details/Create
        public ActionResult Create()
        {
            ViewBag.Head_ID = new SelectList(db.Bill_Head, "ID", "ID");
            ViewBag.Item_iD = new SelectList(db.ItemsTables, "ID", "Name");
            return View();
        }

        // POST: Bill_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Head_ID,Item_iD,Qtn,Price,Total,Unit")] Bill_Details bill_Details)
        {
            if (ModelState.IsValid)
            {
                db.Bill_Details.Add(bill_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Head_ID = new SelectList(db.Bill_Head, "ID", "ID", bill_Details.Head_ID);
            ViewBag.Item_iD = new SelectList(db.ItemsTables, "ID", "Name", bill_Details.Item_iD);
            return View(bill_Details);
        }

        // GET: Bill_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Details bill_Details = db.Bill_Details.Find(id);
            if (bill_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Head_ID = new SelectList(db.Bill_Head, "ID", "ID", bill_Details.Head_ID);
            ViewBag.Item_iD = new SelectList(db.ItemsTables, "ID", "Name", bill_Details.Item_iD);
            return View(bill_Details);
        }

        // POST: Bill_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Head_ID,Item_iD,Qtn,Price,Total,Unit")] Bill_Details bill_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Head_ID = new SelectList(db.Bill_Head, "ID", "ID", bill_Details.Head_ID);
            ViewBag.Item_iD = new SelectList(db.ItemsTables, "ID", "Name", bill_Details.Item_iD);
            return View(bill_Details);
        }

        // GET: Bill_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Details bill_Details = db.Bill_Details.Find(id);
            if (bill_Details == null)
            {
                return HttpNotFound();
            }
            return View(bill_Details);
        }

        // POST: Bill_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill_Details bill_Details = db.Bill_Details.Find(id);
            db.Bill_Details.Remove(bill_Details);
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
