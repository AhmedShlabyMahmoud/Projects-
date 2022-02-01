using FristProjectIti.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace FristProjectIti.Controllers
{
    public class PatientsController : Controller
    {
        private Context context;
        private readonly IWebHostEnvironment webhostEnvironment;
        public PatientsController(Context ctr , IWebHostEnvironment WebHostEnv)
        {
            context = ctr;
            webhostEnvironment = WebHostEnv;

        }
        public ActionResult Index(string searchText,int pagesize ,int pagenumber, string orderType )
        {
            if(orderType=="asc")
            {
                ViewBag.ascorder = true;
                return View(context.patients.OrderBy(e=>e.Fullname));

            }
            else if (orderType == "desc")
            {
                ViewBag.descorder = true;
                return View(context.patients.OrderByDescending(e => e.Fullname));

            }
            if (pagesize>0 && pagenumber>0)
            {
                  ViewBag.CurrentPageSize = pagesize;
                ViewBag.CurrentPageNumber = pagenumber;
                return View(context.patients.Skip(pagesize*(pagenumber--)).Take(pagesize));
            }
            if (string.IsNullOrEmpty(searchText))
                return View(context.patients.Take(5));
            else
            {

                ViewBag.CurrenSearch = searchText.Trim();
                return View(context.patients.Where(x=>x.Fullname.Contains(searchText.Trim())|| x.Diagnesis.Contains(searchText.Trim())));
            }
        }

       
        public ActionResult Details(int id)
        {
            var emp = context.patients.Include(e=>e.Doctors).FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return View(emp);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllDoctors = new SelectList(context.Doctors, "ID", "Description");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Patient pat)
        {
            if (ModelState.IsValid)
            {
            string wwwrootpath = webhostEnvironment.WebRootPath;
            Guid ImageGuid = Guid.NewGuid();
            string extension = Path.GetExtension(pat.PersonalImageFile.FileName);
            string ImageFullName = ImageGuid + extension;
            pat.PersonalImageName = ImageFullName;
            string Imagepath= wwwrootpath+"/images/"+ImageFullName;
            using (FileStream fileStream = new FileStream(Imagepath , FileMode.Create))
            {

                pat.PersonalImageFile.CopyTo(fileStream);

            }
            long filelenght = pat.NationalNumberCardFile.Length;
            var NationalNumberstream = pat.NationalNumberCardFile.OpenReadStream();
            byte[] NationalNumberCardBytes = new byte[filelenght];
            NationalNumberstream.Read(NationalNumberCardBytes, 0, Convert.ToInt32(pat.NationalNumberCardFile.Length));
            pat.NationalNumberCard = Convert.ToBase64String(NationalNumberCardBytes); 
            pat.CreationDate = DateTime.Now;
            context.patients.Add(pat);
            context.SaveChanges();
            return RedirectToAction("Index");
            }
            ViewBag.AllDoctors = new SelectList(context.Doctors, "ID", "Description");
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.AllDoctors = new SelectList(context.Doctors, "ID", "Description");
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
                pat.LastUpdateDate = DateTime.Now;
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
            string wwwrootpath = webhostEnvironment.WebRootPath;
            string Imagepath = wwwrootpath + "/images/" + pat.PersonalImageName;
            if(System.IO.File.Exists(Imagepath))
            {
                System.IO.File.Delete(Imagepath);
            }


            return RedirectToAction("Index");
           
        }



    }
}
 