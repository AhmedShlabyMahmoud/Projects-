using FristProjectIti.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FristProjectIti.Controllers
{
    public class PatientsController : Controller
    {
        private Context context;
        public PatientsController(Context ctr)
        {
            context = ctr;
        }
        public ActionResult Index()
        {
            return View(context.patients);
        }

       
        public ActionResult Details(int id)
        {
            var emp = context.patients.SingleOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return View(emp);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Patient pat)
        {
            if(ModelState.IsValid)
            {
            context.patients.Add(pat);
            context.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Patient pat = context.patients.FirstOrDefault(e => e.Id == id);
                if (pat == null) return NotFound();
            return View(pat);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Patient pat = context.patients.FirstOrDefault(e => e.Id == id);
            if (pat == null) return NotFound();
            return View(pat);
        }
        [HttpPost]

        public ActionResult Edit(int id, Patient pat)
        {
            if (id != pat.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                context.patients.Update(pat);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult CorfirmDelete(int id)
        {
            Patient pat = context.patients.FirstOrDefault(e => e.Id == id);
            if (pat == null) return NotFound();

            context.patients.Remove(pat);
            context.SaveChanges();
            return RedirectToAction("Index");
            

        }

    }
}
 