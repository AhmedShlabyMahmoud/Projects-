using FristProjectIti.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FristProjectIti.Controllers
{
    public class DoctorsController :Controller
    {
        private readonly Context context;
        public DoctorsController(Context cont)
        {
            context = cont;
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var emp = context.Doctors.Include(e => e.patients).FirstOrDefault(e => e.ID == id);
            if (emp == null) return NotFound();
            return View(emp);
        }
        public ActionResult Index()
        {
            return View(context.Doctors);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Doctor doc)
        {
            if (ModelState.IsValid)
            {
                context.Doctors.Add(doc);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            Doctor doc = context.Doctors.FirstOrDefault(e => e.ID == id);
            if (doc == null) return NotFound();
            return View(doc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Doctor doc)
        {
            if (id != doc.ID)
                return BadRequest();
            if (ModelState.IsValid)
            {
                context.Doctors.Update(doc);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            Doctor doc = context.Doctors.FirstOrDefault(e => e.ID == id);
            if (doc == null) return NotFound();
            return View(doc);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult CorfirmDelete(int id)
        {
            Doctor doc = context.Doctors.FirstOrDefault(e => e.ID == id);
            if (doc == null) return NotFound();
            context.Doctors.Remove(doc);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
