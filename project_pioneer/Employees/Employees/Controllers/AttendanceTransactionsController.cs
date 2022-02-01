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
    public class AttendanceTransactionsController : Controller
    {
        private EmployeesDbEntities2 db = new EmployeesDbEntities2();

        // GET: AttendanceTransactions
        public ActionResult Index()
        {
            var attendanceTransactions = db.AttendanceTransactions.Include(a => a.Employee);
            return View(attendanceTransactions.ToList());
        }


        public ActionResult Report()
        {
            //ViewBag.EmpId = new SelectList(db.Employees, "EmpID", "EmpName");
            ReportEmp reportEmp = new ReportEmp();
            reportEmp.Employees = db.Employees.ToList();
            reportEmp.Years = GetYears();
            reportEmp.Months = GetMonths();
            return View(reportEmp);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Report(ReportEmp reportData)
        {
            ReportEmp Re = new ReportEmp();
            Re.Years = GetYears();
            Re.Months = GetMonths();
            Re.Employees = db.Employees.ToList();
            int id= (Convert.ToInt32(reportData.EmpIDVal));
            Employee Emp = db.Employees.Find(Convert.ToInt32(reportData.EmpIDVal));
            Re.month = Convert.ToInt32(reportData.MonthId); ;
            Re.year = Convert.ToInt32(reportData.YearId);  
            Re.nameEmp = Emp.EmpName;
            Re.salaryEmp = Emp.EmpSallary;
            DateTime dtFrom = new DateTime(Re.year, Re.month, 1);
            DateTime dtTo = new DateTime(Re.year, Re.month, 30);
            ViewBag.EmpId = new SelectList(db.Employees, "EmpID", "EmpName");
            Re.dayAttend = db.AttendanceTransactions.Where
            (d => d.Attend == "Yes" && d.TodayDateTrans >= dtFrom && d.TodayDateTrans <= dtTo &&d.EmpId==id ).Count();
            Re.dayAbsence = db.AttendanceTransactions.Where
            (d => d.Attend == "No" && d.TodayDateTrans >= dtFrom && d.TodayDateTrans <= dtTo && d.EmpId == id).Count();

            Re.hoursbonus = Convert.ToInt32(db.AttendanceTransactions.Where
            (d => d.Attend == "Yes" && d.TodayDateTrans >= dtFrom && d.TodayDateTrans <= dtTo && d.EmpId == id).Sum(d => d.bonus));

            Re.hoursminus = Convert.ToInt32(db.AttendanceTransactions.Where
            (d => d.Attend == "Yes" && d.TodayDateTrans >= dtFrom && d.TodayDateTrans <= dtTo && d.EmpId == id).Sum(d => d.minus));
            
            Re.bonus  = Convert.ToInt32(db.AppConfigurations.Where
           (d => d.EmpId == id && d.DateConfig >= dtFrom && d.DateConfig <= dtTo).Sum(d => d.BonusMoney));


            Re.minus = Convert.ToInt32(db.AppConfigurations.Where
           (d => d.EmpId == id && d.DateConfig >= dtFrom && d.DateConfig <= dtTo).Sum(d => d.MinusMoney));

            Re.netsalary = Convert.ToDouble(Re.salaryEmp) + Re.bonus - (Re.minus);
            return View(Re);
        }



        // GET: AttendanceTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceTransaction attendanceTransaction = db.AttendanceTransactions.Find(id);
            if (attendanceTransaction == null)
            {
                return HttpNotFound();
            }
            return View(attendanceTransaction);
        }

        // GET: AttendanceTransactions/Create
        public ActionResult Create()
        {
           
            AttendanceTransaction attendanceTransaction = new AttendanceTransaction();
            attendanceTransaction.Attends = GetAttend();
            ViewBag.EmpId = new SelectList(db.Employees, "EmpID", "EmpName");
            return View(attendanceTransaction);
        }

        // POST: AttendanceTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id,EmpId,Attend,TodayDateTrans,AttendTime,LeaveTime")] AttendanceTransaction attendanceTransaction)
        {
            if (ModelState.IsValid)
            {
                //Get Employee hours
                DateTime hours = db.Employees.Where(e => e.EmpID == attendanceTransaction.EmpId).FirstOrDefault().EmpLeave;
                
                int diff = attendanceTransaction.LeaveTime.Value.Hour - hours.Hour;
                attendanceTransaction.bonus = Convert.ToInt32(diff);
                if (attendanceTransaction.bonus <= 0) attendanceTransaction.bonus = 0;
                DateTime minus = db.Employees.Where(e => e.EmpID == attendanceTransaction.EmpId).FirstOrDefault().EmpAttend;
                int late = attendanceTransaction.AttendTime.Value.Hour - minus.Hour;
                attendanceTransaction.minus = Convert.ToInt32(late);
                if (attendanceTransaction.minus <= 0) attendanceTransaction.minus = 0;
                late = hours.Hour - attendanceTransaction.LeaveTime.Value.Hour;
                int a = Convert.ToInt32(late);
                if (a <= 0) a = 0;
                attendanceTransaction.minus += a;
                attendanceTransaction.Attends = GetAttend();
                if (attendanceTransaction.Attend == "1")
                    attendanceTransaction.Attend = "Yes";
                else if(attendanceTransaction.Attend == "2") attendanceTransaction.Attend = "No";
                db.AttendanceTransactions.Add(attendanceTransaction);             
                db.SaveChanges();
                if (attendanceTransaction.minus >= 1 || attendanceTransaction.bonus >= 1 || attendanceTransaction.Attend == "No")
                {
                    AddMinusHours addMinusHour = new AddMinusHours {
                        Id = attendanceTransaction.Id,
                        EmpId= attendanceTransaction.EmpId,
                        Absence = attendanceTransaction.Attend,
                        BonusMoney = Convert.ToInt32(attendanceTransaction.bonus),
                        MinusMoney = Convert.ToInt32(attendanceTransaction.minus),
                        DateConfig = Convert.ToDateTime( attendanceTransaction.TodayDateTrans),
                        salary = db.Employees.Where(e => e.EmpID == attendanceTransaction.EmpId).FirstOrDefault().EmpSallary,
                        salaryAbsence= db.Employees.Where(e => e.EmpID == attendanceTransaction.EmpId).FirstOrDefault().EmpSallary
                    };
                    if (attendanceTransaction.Attend == "No")
                    {
                        addMinusHour.MinusMoney = 0;
                        addMinusHour.BonusMoney = 0;
                        addMinusHour.AbsnceMoney = 1;
                        addMinusHour.salaryAbsence = addMinusHour.salary;
                        addMinusHour.salary = 0;
                    }
                    else addMinusHour.salaryAbsence = 0;
                    return RedirectToAction("Create", "AppConfigurations", addMinusHour);
                }
                return RedirectToAction("Index");
            }

            ViewBag.EmpId = new SelectList(db.Employees, "EmpID", "EmpName", attendanceTransaction.EmpId);
            return View(attendanceTransaction);
        }

        // GET: AttendanceTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceTransaction attendanceTransaction = db.AttendanceTransactions.Find(id);
            if (attendanceTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpId = new SelectList(db.Employees, "EmpID", "EmpName", attendanceTransaction.EmpId);
            return View(attendanceTransaction);
        }

        // POST: AttendanceTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmpId,TodayDateTrans,AttendTime,LeaveTime,minus,bonus,Attend")] AttendanceTransaction attendanceTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendanceTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpId = new SelectList(db.Employees, "EmpID", "EmpName", attendanceTransaction.EmpId);
            return View(attendanceTransaction);
        }

        // GET: AttendanceTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceTransaction attendanceTransaction = db.AttendanceTransactions.Find(id);
            if (attendanceTransaction == null)
            {
                return HttpNotFound();
            }
            return View(attendanceTransaction);
        }

        // POST: AttendanceTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttendanceTransaction attendanceTransaction = db.AttendanceTransactions.Find(id);
            db.AttendanceTransactions.Remove(attendanceTransaction);
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


        private List<Year> GetYears()
        {
            List<Year> years = new List<Year>();
            for (int i = DateTime.Now.Year; i >=2000 ; i--)
            {
                Year y = new Year();
                y.Id = i;
                y.YearName = Convert.ToString(i);
                years.Add(y);
            }
            return years;
        }

        private List<Month> GetMonths()
        {
            List<Month> Months = new List<Month>
            {
            new Month {Id=1 ,MonthName="january" },
            new Month {Id=2 ,MonthName="february" },
            new Month {Id=3 ,MonthName="march" },
            new Month {Id=4 ,MonthName="april" },
            new Month {Id=5 ,MonthName="may" },
            new Month {Id=6 ,MonthName="june" },
            new Month {Id=7 ,MonthName="july" },
            new Month {Id=8 ,MonthName="august" },
            new Month {Id=9 ,MonthName="september" },
            new Month {Id=10 ,MonthName="october" },
            new Month {Id=11 ,MonthName="november" },
            new Month {Id=12 ,MonthName="december" }
            };
            return Months;
        }
        private List<Attend> GetAttend()
        {
            List<Attend> p = new List<Attend>
            {
                new Attend { ID = 1, attend = "Yes" },
                new Attend { ID = 2, attend = "No" }
            };
            return p;
        }

    }
}
