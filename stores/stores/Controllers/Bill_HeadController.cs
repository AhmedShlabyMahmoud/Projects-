using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace stores.Controllers
{
    public class Bill_HeadController : Controller
    {
        private StoresEntities1 db = new StoresEntities1();

        // GET: Bill_Head
        public ActionResult Index()
        {
            var bill_Head = db.Bill_Head.Include(b => b.Client).Include(b => b.Safe);
            return View(bill_Head.ToList());
        }

        // GET: Bill_Head/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Head bill_Head = db.Bill_Head.Find(id);
            if (bill_Head == null)
            {
                return HttpNotFound();
            }
            DetailsInvoice detailsInvoice = new DetailsInvoice
            {
                Discount = bill_Head.Discount,
                Total = bill_Head.Total,
                Nameitem=new List<string>(),
                Totalitem=new List<decimal>(),
                price=new List<decimal>(),
                qtn=new List<int>()        
            };
            detailsInvoice.TotalDis = detailsInvoice.Discount + detailsInvoice.Total;
            int iD = bill_Head.Safe_ID;
            var s = db.Safes.Where(e => e.ID == iD).FirstOrDefault();
            detailsInvoice.safeId = s.Name_safe;
            iD = bill_Head.client_Id;
            var a = db.Clients.Where(e => e.ID == iD).FirstOrDefault();
            detailsInvoice.NameClient = a.Name_client;
            iD= bill_Head.ID;
            var bill_details = db.Bill_Details.Where(b => b.Head_ID==iD).ToList();
            detailsInvoice.bill_Details = bill_details;

            detailsInvoice.op = bill_Head.Operate_Date;

            return View(detailsInvoice);
        }

        // GET: Bill_Head/Create
        public ActionResult Create()
        {
            ViewBag.client_Id = new SelectList(db.Clients, "ID", "Name_client");
            ViewBag.Safe_ID = new SelectList(db.Safes, "ID", "Name_safe");
            return View();
        }
        public ActionResult Table()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Table(int a )
        {
            return View();
        }
        public ActionResult SalesInvoice()
        {
            ViewBag.client_Id = new SelectList(db.Clients, "ID", "Name_client");
            ViewBag.Safe_ID = new SelectList(db.Safes, "ID", "Name_safe");
            ViewBag.Storesid = new SelectList(db.StoresTables, "ID", "NameStores");
            ViewBag.Itemsid = new SelectList(db.ItemsTables, "ID", "Name");
            ViewBag.unit = new SelectList(db.ItemUnitsTables, "ID", "Unit_Name");
            

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SalesInvoice(SalseInvoice salseInvoice)
        {
            if (ModelState.IsValid)
            {
                Bill_Head bill_Head = new Bill_Head();
                bill_Head.paid = salseInvoice.paid;
                bill_Head.Safe_ID = salseInvoice.Safe_ID;
                bill_Head.Total = salseInvoice.TotalDis;
                bill_Head.Discount = salseInvoice.Discount;
                bill_Head.client_Id = salseInvoice.client_Id;
                bill_Head.Operate_Date = salseInvoice.Operate_Time;
                db.Bill_Head.Add(bill_Head);


                string st = salseInvoice.numbers;
                string num = "";
                int b = 0;
                for (int j = 0; j < st.Length; j++)
                {
                    //"100:1;10:3;"
                  
                    if (st[j] == ':')
                    {
                        b = Convert.ToInt32(num);
                        num = "";


                    }

                    else if (st[j] != ';')
                        num += st[j];
                    else
                    {

                        int a = Convert.ToInt32(num);
                        num = "";
                        Bill_Details bill_Details = new Bill_Details();
                        bill_Details.Bill_Head = bill_Head;
                        bill_Details.Qtn = b;
                        
                        var s = db.ItemsTables.Where(e => e.ID == a).FirstOrDefault();

                        bill_Details.Price = s.SellPrice;
                        bill_Details.Total= b* s.SellPrice;
                        bill_Details.Item_iD = a;
                        b = 0;
                        db.Bill_Details.Add(bill_Details);


                    }

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client_Id = new SelectList(db.Clients, "ID", "Name_client", salseInvoice.client_Id);
            ViewBag.Safe_ID = new SelectList(db.Safes, "ID", "Name_safe", salseInvoice.Safe_ID);
            ViewBag.Storesid = new SelectList(db.StoresTables, "ID", "NameStores", salseInvoice.Storesid);
            ViewBag.Itemsid = new SelectList(db.ItemsTables, "ID", "Name", salseInvoice.Itemsid);
            ViewBag.unit = new SelectList(db.ItemUnitsTables, "ID", "Unit_Name",salseInvoice.unit);

            return View(salseInvoice);
        }

        // POST: Bill_Head/Create
        // Samar nasser
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Total,client_Id,Safe_ID,Discount,Operate_Date")] Bill_Head bill_Head)
        {
            if (ModelState.IsValid)
            {
                db.Bill_Head.Add(bill_Head);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client_Id = new SelectList(db.Clients, "ID", "Name_client", bill_Head.client_Id);
            ViewBag.Safe_ID = new SelectList(db.Safes, "ID", "Name_safe", bill_Head.Safe_ID);
            return View(bill_Head);
        }

        // GET: Bill_Head/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Head bill_Head = db.Bill_Head.Find(id);
            if (bill_Head == null)
            {
                return HttpNotFound();
            }
            ViewBag.client_Id = new SelectList(db.Clients, "ID", "Name_client", bill_Head.client_Id);
            ViewBag.Safe_ID = new SelectList(db.Safes, "ID", "Name_safe", bill_Head.Safe_ID);
            return View(bill_Head);
        }

        // POST: Bill_Head/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Total,client_Id,Safe_ID,Discount,Operate_Date")] Bill_Head bill_Head)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill_Head).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.client_Id = new SelectList(db.Clients, "ID", "Name_client", bill_Head.client_Id);
            ViewBag.Safe_ID = new SelectList(db.Safes, "ID", "Name_safe", bill_Head.Safe_ID);
            return View(bill_Head);
        }

        // GET: Bill_Head/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Head bill_Head = db.Bill_Head.Find(id);
            if (bill_Head == null)
            {
                return HttpNotFound();
            }
            return View(bill_Head);
        }

        // POST: Bill_Head/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill_Head bill_Head = db.Bill_Head.Find(id);
            db.Bill_Head.Remove(bill_Head);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetStoreItems(int storeId)
        {
            List<StoreItem> nameitems = new List<StoreItem>();
            var Items = db.Stockes.Where(e => e.Store_ID == storeId).ToList();
            for (int i = 0; i < Items.Count(); i++)
            {
                int id = Items[i].Item_ID;
                var s = db.ItemsTables.Where(e => e.ID == id).FirstOrDefault();

                nameitems.Add(new StoreItem
                {
                    Id = s.ID,
                    Name = s.Name
                });
            }

            return Json(nameitems, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUnitItems(string NameItem)
        {
            List<UnitItem> nameitems = new List<UnitItem>();
            var Items = db.ItemUnitsTables.Where(e => e.ItemsTable.Name == NameItem).ToList();
            for (int i = 0; i < Items.Count(); i++)
            {
                nameitems.Add(new UnitItem
                {
                    Qunat = i,
                    NameUnit = Items[i].Unit_Name
                });
                   
            }
         return Json(nameitems, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetItemPrice(int itemId, int storeId)
        {
            var s = db.ItemsTables.Where(e => e.ID == itemId).FirstOrDefault();
            var x = db.Stockes.Where(e => e.Item_ID == itemId && e.Store_ID == storeId).FirstOrDefault();
            Itemprice itemprice = new Itemprice();
            itemprice.price = s.SellPrice;
            itemprice.qnt = x.Quantity;
            return Json(itemprice, JsonRequestBehavior.AllowGet);
        }

        //https://localhost:44344/Bill_Head/GetQnt?itemId=1&count=3
        public void GetQnt(int itemId, int storeId, int count)
        {
            var x = db.Stockes.Where(e => e.Item_ID == itemId && e.Store_ID == storeId).FirstOrDefault();
            x.Quantity -= count;
            db.SaveChanges();

        }

        public ActionResult GetItemtQn(int itemId, int storeId)
        {
            var s = db.Stockes.Where(e => e.Item_ID == itemId && e.Store_ID == storeId).FirstOrDefault();
            int Quan = s.Quantity;
            return Json(Quan, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetunittQn(string itemName, string UnitName)
        {
            var s = db.ItemUnitsTables.Where(e => e.Unit_Name == UnitName && e.ItemsTable.Name == itemName).FirstOrDefault();
            int Quan = s.Quantity;
            return Json(Quan, JsonRequestBehavior.AllowGet);

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
    class StoreItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Itemprice
    {
        public decimal price { get; set; }
        public int qnt { get; set; }
    }
    class UnitItem
    {
        public int Qunat { get; set; }
        public string NameUnit { get; set; }
    }

}
