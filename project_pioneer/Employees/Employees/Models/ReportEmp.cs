using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.Models
{
    public class ReportEmp
    {
        public int EmpID { get; set; }

        public List<Employee> Employees { get; set; }
        public string EmpIDVal { get; set; }

        public List<Year> Years { get; set; }
        public string YearId { get; set; }
        public List<Month> Months { get; set; }
        public string MonthId { get; set; }
        public string nameEmp { get; set; }
        public decimal salaryEmp { get; set; }
        public int dayAttend { get; set; }
        public int dayAbsence { get; set; }
        public int hoursbonus { get; set; }
        public int hoursminus { get; set; }
        public double bonus { get; set; }
        public double minus { get; set; }
        public double netsalary { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }
}