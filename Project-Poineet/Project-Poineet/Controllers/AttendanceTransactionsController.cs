using Project_Poineet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Project_Poineet.Controllers
{
    public class AttendanceTransactionsController : Controller
    {
        private PioneerEmployeeDbEntities db = new PioneerEmployeeDbEntities();

        public ActionResult Report()
        {
            ReportEmployee reportEmp = new ReportEmployee();
            reportEmp.AllEmployees = GetAllEmployeess();
            reportEmp.Employees = db.Employees.ToList();
            reportEmp.Years = GetYears();
            reportEmp.Months = GetMonths();
            return View(reportEmp);
        }
        [HttpPost]
        public ActionResult Report(ReportEmployee reportData)
        {
            ReportEmployee reportEmp = new ReportEmployee
            {
                NameEmployees = new List<string>(),
                salaryEmployees = new List<decimal>(),
                hoursbonusEmployees = new List<int>(),
                hoursminusEmployees = new List<int>(),
                minusEmployees = new List<double>(),
                bonusEmployees = new List<double>(),
                dayAbsenceEmployees = new List<int>(),
                dayAttendEmployees = new List<int>(),
                netsalaryEmployees = new List<double>()
            };
            reportEmp.AllEmployees = GetAllEmployeess();
            reportEmp.Years = GetYears();
            reportEmp.Months = GetMonths();
            int id = (Convert.ToInt32(reportData.Employeeid));
            if (id == 0)
            {
                List<int> cnt1 = db.Employees.Select(e => e.Empolyee_ID).ToList();
                reportEmp.cnt = cnt1.Count();
                for (int i = 0; i < reportEmp.cnt; i++)
                {
                    int iD = cnt1[i];
                    Employee Emp = db.Employees.Find(iD);
                    reportEmp.month = Convert.ToInt32(reportData.MonthId); ;
                    reportEmp.year = Convert.ToInt32(reportData.YearId);

                    reportEmp.NameEmployees.Add(Emp.Employee_Name);
                 
                    reportEmp.salaryEmployees.Add(Emp.Employee_Salary);

                    DateTime dtFrom = new DateTime(reportEmp.year, reportEmp.month, 1);
                    int DaysInMonth = DateTime.DaysInMonth(reportEmp.year, reportEmp.month);
                    DateTime dtTo = new DateTime(reportEmp.year, reportEmp.month, DaysInMonth);

                   

                    reportEmp.dayAttendEmployees.Add(db.AttendanceTransactions.Where
                   (d => d.TodayDateTrans >= dtFrom && d.TodayDateTrans <= dtTo && d.Employeeid == iD && d.minus >= 0).Count());


                    reportEmp.dayAbsenceEmployees.Add(22 - reportEmp.dayAttendEmployees[i]);

                    reportEmp.hoursbonusEmployees.Add(Convert.ToInt32(db.AttendanceTransactions.Where
                    (d => d.TodayDateTrans >= dtFrom && d.TodayDateTrans <= dtTo && d.Employeeid == iD).Sum(d => d.bonus)));
                   

                    reportEmp.hoursminusEmployees.Add(Convert.ToInt32(db.AttendanceTransactions.Where
                    (d => d.TodayDateTrans >= dtFrom && d.TodayDateTrans <= dtTo && d.Employeeid == iD && d.minus >= 0).Sum(d => d.minus)));


                    reportEmp.netsalaryEmployees.Add(Convert.ToInt32(db.AttendanceTransactions.Where
                     (d => d.TodayDateTrans >= dtFrom && d.TodayDateTrans <= dtTo && d.Employeeid == iD).Sum(d => d.netsalary)));


                    decimal daymoney = reportEmp.salaryEmployees[i] / 30;
                    decimal todaymoney = daymoney / 7;
                    decimal money = Convert.ToDecimal(Convert.ToDecimal(reportEmp.hoursbonusEmployees[i]) * Convert.ToDecimal(db.Settings.Sum(e => e.Bonus_count))) * todaymoney;
                    double Money = Convert.ToDouble(money);
                    reportEmp.bonusEmployees.Add(Money);


                    double Minus = reportEmp.hoursminusEmployees[i] * db.Settings.Sum(e => e.Minus_count) *Convert.ToDouble(todaymoney);   
                    reportEmp.minusEmployees.Add(Minus);

                    double AA = Convert.ToDouble(reportEmp.salaryEmployees[i]) + Convert.ToDouble(money) - (Minus + reportEmp.netsalaryEmployees[i]);
                    reportEmp.netsalaryEmployees[i]=(AA);
                }
            }
            else
            {
                Employee Emp = db.Employees.Find(id);
                reportEmp.month = Convert.ToInt32(reportData.MonthId); ;
                reportEmp.year = Convert.ToInt32(reportData.YearId);
                reportEmp.nameEmp = Emp.Employee_Name;
                reportEmp.salaryEmp = Emp.Employee_Salary;
                DateTime dtFrom = new DateTime(reportEmp.year, reportEmp.month, 1);
                DateTime dtTo = new DateTime(reportEmp.year, reportEmp.month, 30);
                reportEmp.dayAttend = db.AttendanceTransactions.Where
                 (d => d.TodayDateTrans >= dtFrom && d.TodayDateTrans <= dtTo && d.Employeeid == id && d.minus >= 0).Count();
                reportEmp.dayAbsence = 22 - reportEmp.dayAttend;

                reportEmp.hoursbonus = Convert.ToInt32(db.AttendanceTransactions.Where
                 (d => d.TodayDateTrans >= dtFrom && d.TodayDateTrans <= dtTo && d.Employeeid == id).Sum(d => d.bonus));

                reportEmp.hoursminus = Convert.ToInt32(db.AttendanceTransactions.Where
                (d => d.TodayDateTrans >= dtFrom && d.TodayDateTrans <= dtTo && d.Employeeid == id && d.minus >= 0).Sum(d => d.minus));

                reportEmp.netsalary = Convert.ToInt32(db.AttendanceTransactions.Where
                (d => d.TodayDateTrans >= dtFrom && d.TodayDateTrans <= dtTo && d.Employeeid == id).Sum(d => d.netsalary));

                decimal daymoney = reportEmp.salaryEmp / 30;
                decimal todaymoney = daymoney / 7;
                decimal money = Convert.ToDecimal(Convert.ToDecimal(reportEmp.hoursbonus) * Convert.ToDecimal(db.Settings.Sum(e => e.Bonus_count))) * todaymoney;
                reportEmp.bonus = Convert.ToDouble(money);

                decimal minus = Convert.ToDecimal(Convert.ToDecimal(reportEmp.hoursminus) * Convert.ToDecimal(db.Settings.Find(1).Minus_count)) * todaymoney;
                reportEmp.minus = Convert.ToDouble(minus);
                reportEmp.netsalary = Convert.ToDouble(Convert.ToDouble(reportEmp.salaryEmp) + Convert.ToDouble(money) - (Convert.ToDouble(minus) + reportEmp.netsalary));
            }
            return View(reportEmp);
        }

        // GET: AttendanceTransactions
        public ActionResult Index()
        {
            var attendanceTransactions = db.AttendanceTransactions.Include(a => a.Employee);
            return View(attendanceTransactions.ToList());
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

            ViewBag.Employeeid = new SelectList(db.Employees, "Empolyee_ID", "Employee_Name");
            return View();
        }

        // POST: AttendanceTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employeeid,TodayDateTrans,AttendTime,leaveTime,minus,bonus")] AttendanceTransaction attendanceTransaction)
        {
            if (ModelState.IsValid)
            {
                var day = db.Settings.Find(1).Days;
                List<string> Days = new List<string>();
                string st = Convert.ToString(day);
                string st2 = "";
                for (int i = 0; i < st.Length; i++)
                {
                    if (st[i] != ';')
                        st2 += st[i];
                    else
                    {
                        Days.Add(st2);
                        st2 = "";
                    }
                }
                Days.Add(st2);
                bool TOrF = true;
                for (int i = 0; i < Days.Count; i++)
                {
                    if (attendanceTransaction.TodayDateTrans.Value.DayOfWeek.ToString() == Days[i])
                    {
                        attendanceTransaction.bonus = (attendanceTransaction.leaveTime - attendanceTransaction.AttendTime).Value.Hours;
                        attendanceTransaction.minus = -1;
                        TOrF = false;
                    }

                }
                if (TOrF)
                {
                    DateTime hours = db.Employees.Where(e => e.Empolyee_ID == attendanceTransaction.Employeeid).FirstOrDefault().Leave_Time;
                    int diff = attendanceTransaction.leaveTime.Value.Hour - hours.Hour;
                    attendanceTransaction.bonus = Convert.ToInt32(diff);
                    if (attendanceTransaction.bonus <= 0) attendanceTransaction.bonus = 0;
                    DateTime minus = db.Employees.Where(e => e.Empolyee_ID == attendanceTransaction.Employeeid).FirstOrDefault().Attend_Time;
                    int late = attendanceTransaction.AttendTime.Value.Hour - minus.Hour;
                    attendanceTransaction.minus = Convert.ToInt32(late);
                    if (attendanceTransaction.minus <= 0) attendanceTransaction.minus = 0;
                    late = hours.Hour - attendanceTransaction.leaveTime.Value.Hour;
                    int a = Convert.ToInt32(late);
                    if (a <= 0) a = 0;
                    attendanceTransaction.minus += a;
                }
                db.AttendanceTransactions.Add(attendanceTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //   ViewBag.Employeeid = new SelectList(db.Employees, "Empolyee_ID", "Employee_Name", attendanceTransaction.Employeeid);
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
            ViewBag.Employeeid = new SelectList(db.Employees, "Empolyee_ID", "Employee_Name", attendanceTransaction.Employeeid);
            return View(attendanceTransaction);
        }

        // POST: AttendanceTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employeeid,TodayDateTrans,AttendTime,leaveTime,minus,bonus")] AttendanceTransaction attendanceTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendanceTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employeeid = new SelectList(db.Employees, "Empolyee_ID", "Employee_Name", attendanceTransaction.Employeeid);
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
        private List<AllEmployees> GetAllEmployeess()
        {
            //PriorityQueue<string, int> queue = new PriorityQueue<string, int>();
            List<AllEmployees> allEmployees = new List<AllEmployees>();
            AllEmployees all = new AllEmployees();
            all.EmployeeName = "All Employees";
            all.ID = 0;
            allEmployees.Add(all);
            var attendanceTransactions = db.Employees;
            foreach (var item in attendanceTransactions)
            {
                AllEmployees allEmp = new AllEmployees();
                allEmp.EmployeeName = item.Employee_Name;
                allEmp.ID = item.Empolyee_ID;
                allEmployees.Add(allEmp);
            }
            return allEmployees;
        }
        private List<Year> GetYears()
        {
            List<Year> years = new List<Year>();
            for (int i = DateTime.Now.Year; i >= 2000; i--)
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
    }
}
