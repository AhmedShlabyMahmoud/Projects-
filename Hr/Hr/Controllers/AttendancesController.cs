using Hr.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Hr.Controllers
{
    public class AttendancesController : Controller
    {
        private HrSystemEntities db = new HrSystemEntities();

        // GET: Attendances
        public ActionResult Index()
        {
            var attendances = db.Attendances.Include(a => a.Employee);
            return View(attendances.ToList());
        }

        // GET: Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }
        public ActionResult ReportEmployee()
        {
            ViewBag.Employeeid = new SelectList(db.Employees, "EmployeeID", "EmployeeName");
            return View();
        }
        [HttpPost]
        public ActionResult ReportEmployee(ReportEmployee report)
        {
            string day = db.Settings.Select(d => d.Holidaystring).FirstOrDefault();
            List<string> Days = new List<string>();
            string st2 = "";
            for (int y = 0; y < day.Length; y++)
            {
                if (day[y] != ';')
                    st2 += day[y];
                else
                {
                    Days.Add(st2);
                    st2 = "";
                }
            }
            Days.Add(st2);
            Employee Emp = db.Employees.Find(report.Employeeid);
            report.nameEmp = Emp.EmployeeName;
            report.salaryEmp = Emp.EmployeeSalary;
            report.year = Convert.ToInt32(report.YearId);
            report.month = Convert.ToInt32(report.MonthId);
            int DaysInMonth = DateTime.DaysInMonth(report.year, report.month);
            for (int i = 1; i <= DaysInMonth; i++)
            {
                DateTime date = new DateTime(report.year, report.month, i);
                int holicount = db.Holidays.Where(d => d.HolidayDate == date).Count();
                var AttendOrNot = db.Attendances.Where(d => d.Todaydate == date && d.Employeeid == report.Employeeid).ToList();
                var today = db.Attendances.Where(d => d.Todaydate == date && d.Employeeid == report.Employeeid).FirstOrDefault();
                bool TOrF = true;
                for (int y = 0; y < Days.Count; y++)
                {
                    if (date.DayOfWeek.ToString() == Days[y] && TOrF == true)
                    {
                        report.holidays++;
                        if (AttendOrNot.Count() >= 1)
                            report.bonus += (today.LeavingTime.Hour - today.AttendingTime.Hour);
                        TOrF = false;
                    }
                }
                if (AttendOrNot.Count() >= 1)
                {
                    if (TOrF == false) report.Attendholiday++;

                    else if (holicount >= 1)//attend 24/11
                    {
                        report.holidays++;
                        report.Attendholiday++;
                        report.bonus += (today.LeavingTime.Hour - today.AttendingTime.Hour);
                        TOrF = false;
                    }

                    else
                    {
                        report.dayAttend++;
                        int hours = (today.LeavingTime.Hour - Emp.TimeLeave.Hour);
                        if (hours >= 0)
                            report.bonus += hours;
                        hours = (Emp.TimeLeave.Hour - today.LeavingTime.Hour);
                        if (hours >= 0)
                            report.minus += hours;
                        hours = (today.AttendingTime.Hour - Emp.TimeAttend.Hour);
                        if (hours >= 0)
                            report.minus += hours;
                    }
                }
                else if (TOrF == true && holicount == 0)
                {
                    report.dayAbsence++;
                }
                else if(holicount == 1) report.holidays++;

            }
            decimal daily = report.salaryEmp / 30;

            report.AbsencePenalty = report.dayAbsence * daily * Convert.ToDecimal(db.Settings.Sum(e => e.HolidayCount));
            report.hoursbonus = report.bonus * Convert.ToDecimal((daily / 24)) * Convert.ToDecimal(db.Settings.Sum(e => e.HolidayCount));
            report.hoursminus = report.minus * Convert.ToDecimal((daily / 24)) * Convert.ToDecimal(db.Settings.Sum(e => e.HolidayCount));
            if (Emp.DateHiring.Month == report.month)
                report.netsalary = ((Emp.DateHiring.Day) - 1) * daily;
            else report.netsalary = 0;
            report.netsalary = report.salaryEmp + report.hoursbonus - (report.hoursminus + report.netsalary + report.AbsencePenalty);
            ViewBag.Employeeid = new SelectList(db.Employees, "EmployeeID", "EmployeeName");
            return View(report);
        }

        public ActionResult Reports()
        {
            ReportsClass report = new ReportsClass();
            report.cnt = 0;
            return View(report);
        }
        [HttpPost]
        public ActionResult Reports(ReportsClass report)
        {
            report.dayAbsenceEmployees = new List<int>();
            report.dayAttendEmployees = new List<int>();
            report.EmployeeHolidays = new List<int>();
            report.bonusEmployees = new List<int>();
            report.minusEmployees = new List<int>();
            report.hoursbonusEmployees = new List<decimal>();
            report.hoursminusEmployees = new List<decimal>();
            report.EmployeeAttendHoliday = new List<int>();
            report.NameEmployees = new List<string>();
            report.salaryEmployees = new List<decimal>();
            report.netsalaryEmployees = new List<decimal>();
            report.EmployeesAbsencePenalty = new List<decimal>();


            


            string day = db.Settings.Select(d => d.Holidaystring).FirstOrDefault();
            List<string> Days = new List<string>();
            string st2 = "";
            for (int y = 0; y < day.Length; y++)
            {
                if (day[y] != ';')
                    st2 += day[y];
                else
                {
                    Days.Add(st2);
                    st2 = "";
                }
            }
            Days.Add(st2);
            List<int> cnt1 = db.Employees.Select(e => e.EmployeeID).ToList();
            report.cnt = cnt1.Count();
            bool aa = true;
            for (int i = 0; i < report.cnt; i++)
            {
                if (report.dayAbsenceEmployees.Count() == i)
                    report.dayAbsenceEmployees.Add(0);

                if (report.NameEmployees.Count() == i)
                    report.NameEmployees.Add("");

                if (report.salaryEmployees.Count() == i)
                    report.salaryEmployees.Add(0);

                if (report.dayAttendEmployees.Count() == i)
                    report.dayAttendEmployees.Add(0);

                if (report.EmployeeHolidays.Count() == i)
                    report.EmployeeHolidays.Add(0);

                if (report.bonusEmployees.Count() == i)
                    report.bonusEmployees.Add(0);

                if (report.minusEmployees.Count() == i)
                    report.minusEmployees.Add(0);


                if (report.hoursbonusEmployees.Count() == i)
                    report.hoursbonusEmployees.Add(0);

                if (report.hoursminusEmployees.Count() == i)
                    report.hoursminusEmployees.Add(0);

                if (report.EmployeeAttendHoliday.Count() == i)
                    report.EmployeeAttendHoliday.Add(0);

              
                if (report.netsalaryEmployees.Count() == i)
                    report.netsalaryEmployees.Add(0);

                if (report.EmployeesAbsencePenalty.Count() == i)
                    report.EmployeesAbsencePenalty.Add(0);
                int iD = cnt1[i];
                Employee Emp = db.Employees.Find(iD);
                report.month = Convert.ToInt32(report.MonthId); 
                report.year = Convert.ToInt32(report.YearId);
              ///  if (report.NameEmployees.Count() == (i + 1))
                    report.NameEmployees.Add(Emp.EmployeeName);
             ///   else report.NameEmployees[i] = Emp.EmployeeName;

            ///    if (report.salaryEmployees.Count() == (i + 1))
                    report.salaryEmployees.Add(Emp.EmployeeSalary);
              ///  else report.salaryEmployees[i] = Emp.EmployeeSalary;
                ///    report.salaryEmployees.Add(Emp.EmployeeSalary);

                int DaysInMonth = DateTime.DaysInMonth(report.year, report.month);
                decimal daily = report.salaryEmployees[i+1] / 30;

                if (Emp.DateHiring.Month == report.month && aa)
                    if (report.netsalaryEmployees.Count() == (i + 1))
                    {
                        report.netsalaryEmployees.Add(((Emp.DateHiring.Day) - 1) * daily); aa = false;
                    }
                       
                for (int y = 1; y <= DaysInMonth; y++)
                {
                    DateTime date = new DateTime(report.year, report.month, y);
                    int holicount = db.Holidays.Where(d => d.HolidayDate == date).Count();
                    var AttendOrNot = db.Attendances.Where(d => d.Todaydate == date&&d.Employeeid==Emp.EmployeeID).ToList();
                    var today = db.Attendances.Where(d => d.Todaydate == date && d.Employeeid == Emp.EmployeeID).FirstOrDefault();
                    bool TOrF = true;
                    for (int z = 0; z < Days.Count; z++)
                    {
                        if (date.DayOfWeek.ToString() == Days[z] && TOrF == true)
                        {
                            if (report.EmployeeHolidays.Count() == (i+1))
                                report.EmployeeHolidays.Add(1);
                            else
                                report.EmployeeHolidays[i+1]++;

                            if (AttendOrNot.Count() >= 1)
                            {
                                if (report.bonusEmployees.Count() == (i+1 ))
                                    report.bonusEmployees.Add((today.LeavingTime.Hour - today.AttendingTime.Hour));
                                else
                                    report.bonusEmployees[i+1] += (today.LeavingTime.Hour - today.AttendingTime.Hour);
                            }
                            TOrF = false;
                        }
                    }
                    if (AttendOrNot.Count() >= 1)
                    {
                        if (TOrF == false)

                        {
                            if (report.EmployeeAttendHoliday.Count() == (i+1 ))
                                report.EmployeeAttendHoliday.Add((today.LeavingTime.Hour - today.AttendingTime.Hour));
                            else
                                report.EmployeeAttendHoliday[i+1] += (today.LeavingTime.Hour - today.AttendingTime.Hour);

                            //     report.EmployeeAttendHoliday[i]++;
                        }

                        else if (holicount >= 1)//attend 24/11
                        {
                            ///   report.EmployeeHolidays[i]++;
                            ///   
                            if (report.EmployeeHolidays.Count() == (i+1 ))
                                report.EmployeeHolidays.Add(1);
                            else
                                report.EmployeeHolidays[i+1]++;


                            //  report.EmployeeAttendHoliday[i]++;
                            if (report.EmployeeAttendHoliday.Count() == (i+1 ))
                                report.EmployeeAttendHoliday.Add(1);
                            else
                                report.EmployeeAttendHoliday[i+1]++;



                            ///  report.bonusEmployees[i] += (today.LeavingTime.Hour - today.AttendingTime.Hour);
                            if (report.bonusEmployees.Count() == (i+1 ))
                                report.bonusEmployees.Add((today.LeavingTime.Hour - today.AttendingTime.Hour));
                            else
                                report.bonusEmployees[i+1] += (today.LeavingTime.Hour - today.AttendingTime.Hour);


                            TOrF = false;
                        }

                        else
                        {
                            ///  report.dayAttendEmployees[i]++;

                            if (report.dayAttendEmployees.Count() == (i+1 ))
                                report.dayAttendEmployees.Add(1);
                            else
                                report.dayAttendEmployees[i+1]++;

                            int hours = (today.LeavingTime.Hour - Emp.TimeLeave.Hour);
                            if (hours >= 0)
                            {
                                if (report.bonusEmployees.Count() == (i+1 ))
                                    report.bonusEmployees.Add(hours);
                                else
                                    report.bonusEmployees[i+1] += hours;
                               // report.bonusEmployees[i] += hours;

                            }
                           
                            hours = (Emp.TimeLeave.Hour - today.LeavingTime.Hour);
                            if (hours >= 0)
                            {

                                if (report.minusEmployees.Count() == (i+1 ))
                                    report.minusEmployees.Add(hours);
                                else
                                    report.minusEmployees[i+1] += hours;
                              ///  report.minusEmployees[i] += hours;
                                //hours
                            }
                              
                            hours = (today.AttendingTime.Hour - Emp.TimeAttend.Hour);
                            if (hours >= 0)
                                report.minusEmployees[i+1] += hours;
                        }
                    }
                    else if (TOrF == true && holicount == 0)
                    {
                      ///  report.dayAbsenceEmployees[i]++;

                        if (report.dayAbsenceEmployees.Count() == (i+1))
                            report.dayAbsenceEmployees.Add(1);
                        else
                            report.dayAbsenceEmployees[i+1]++;
                    }
                }


                if (report.netsalaryEmployees.Count() == i+1)

                     report.netsalaryEmployees.Add(0);

                if (report.dayAbsenceEmployees.Count() == i + 1)

                    report.dayAbsenceEmployees.Add(0);

                report.EmployeesAbsencePenalty.Add(report.dayAbsenceEmployees[i+1] * daily * Convert.ToDecimal(db.Settings.Sum(e => e.HolidayCount)));
                report.hoursbonusEmployees.Add( ((report.bonusEmployees.Count()==i+2)? report.bonusEmployees[i+1]:0 )* Convert.ToDecimal((daily / 24)) * Convert.ToDecimal(db.Settings.Sum(e => e.HolidayCount)));
                report.hoursminusEmployees.Add( ((report.minusEmployees.Count()==i+2) ? report.minusEmployees[i+1] : 0 )* Convert.ToDecimal((daily / 24)) * Convert.ToDecimal(db.Settings.Sum(e => e.HolidayCount)));
                if (report.dayAttendEmployees.Count() == i + 1)
                    report.dayAttendEmployees.Add(0);

                        report.netsalaryEmployees[1+i] = report.salaryEmployees[i+1] + report.hoursbonusEmployees[i+1] - (report.hoursminusEmployees[i+1] + report.netsalaryEmployees[i+1] + report.EmployeesAbsencePenalty[i+1]);
            }
            if (report.dayAbsenceEmployees.Count() == report.cnt)
                report.dayAbsenceEmployees.Add(0);

            if (report.NameEmployees.Count() == report.cnt)
                report.NameEmployees.Add("");

            if (report.salaryEmployees.Count() == report.cnt)
                report.salaryEmployees.Add(0);

            if (report.dayAttendEmployees.Count() == report.cnt)
                report.dayAttendEmployees.Add(0);

            if (report.EmployeeHolidays.Count() == report.cnt)
                report.EmployeeHolidays.Add(0);

            if (report.bonusEmployees.Count() == report.cnt)
                report.bonusEmployees.Add(0);

            if (report.minusEmployees.Count() == report.cnt)
                report.minusEmployees.Add(0);


            if (report.hoursbonusEmployees.Count() == report.cnt)
                report.hoursbonusEmployees.Add(0);

            if (report.hoursminusEmployees.Count() == report.cnt)
                report.hoursminusEmployees.Add(0);

            if (report.EmployeeAttendHoliday.Count() == report.cnt)
                report.EmployeeAttendHoliday.Add(0);


            if (report.netsalaryEmployees.Count() == report.cnt)
                report.netsalaryEmployees.Add(0);

            if (report.EmployeesAbsencePenalty.Count() == report.cnt)
                report.EmployeesAbsencePenalty.Add(0);
            return View(report);
        }

        // GET: Attendances/Create
        public ActionResult Create()
        {
            ViewBag.Employeeid = new SelectList(db.Employees, "EmployeeID", "EmployeeName");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employeeid,Todaydate,LeavingTime,AttendingTime")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employeeid = new SelectList(db.Employees, "EmployeeID", "EmployeeName", attendance.Employeeid);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employeeid = new SelectList(db.Employees, "EmployeeID", "EmployeeName", attendance.Employeeid);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employeeid,Todaydate,LeavingTime,AttendingTime")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employeeid = new SelectList(db.Employees, "EmployeeID", "EmployeeName", attendance.Employeeid);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendances.Find(id);
            db.Attendances.Remove(attendance);
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
