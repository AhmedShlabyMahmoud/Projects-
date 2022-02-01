using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employees.Models;

namespace Employees.Controllers
{
    public class AppConfigurationsController : Controller
    {
        private EmployeesDbEntities2 db = new EmployeesDbEntities2();
        
        // GET: AppConfigurations
        public ActionResult Index()
        {
            return View(db.AppConfigurations.ToList());
        }

        // GET: AppConfigurations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppConfiguration appConfiguration = db.AppConfigurations.Find(id);
            if (appConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(appConfiguration);
        }
        // GET: AppConfigurations/Create
        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateGet(AddMinusHours addMinusHour)
        {
            AddMinusHours AMH = new AddMinusHours();  
            AMH.MinusMoney = addMinusHour.MinusMoney;
            AMH.BonusMoney = addMinusHour.BonusMoney;
            AMH.DateConfig = addMinusHour.DateConfig;
            AMH.Absence = addMinusHour.Absence;
            AMH.salary= addMinusHour.salary;
            AMH.salaryAbsence = addMinusHour.salaryAbsence;
            AMH.Id = addMinusHour.Id;
            AMH.EmpId = addMinusHour.EmpId;
            if (addMinusHour.Absence == "No")
            {
                AMH.BonusMoney = 0;
                AMH.MinusMoney = 0;
                AMH.AbsnceMoney = 1;
            }

            
            return View(AMH);
        }
       
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult Create(AddMinusHours addMinusHours)
        {
            AppConfiguration appConfiguration=new AppConfiguration()
            { 
            AbsnceMoney= addMinusHours.AbsnceMoney,
            BonusMoney= addMinusHours.BonusMoney,
            DateConfig= addMinusHours.DateConfig,
            MinusMoney= addMinusHours.MinusMoney,
            EmpId= addMinusHours.EmpId,
            Id = addMinusHours.Id
            };         
            if (ModelState.IsValid)
            {
                db.AppConfigurations.Add(appConfiguration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appConfiguration);
        }

        // GET: AppConfigurations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppConfiguration appConfiguration = db.AppConfigurations.Find(id);
            if (appConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(appConfiguration);
        }

        // POST: AppConfigurations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( AppConfiguration appConfiguration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appConfiguration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appConfiguration);
        }

        // GET: AppConfigurations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppConfiguration appConfiguration = db.AppConfigurations.Find(id);
            if (appConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(appConfiguration);
        }

        // POST: AppConfigurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppConfiguration appConfiguration = db.AppConfigurations.Find(id);
            db.AppConfigurations.Remove(appConfiguration);
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
