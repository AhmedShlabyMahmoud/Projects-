using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_Poineet.Models
{
    public class ReportEmployee
    {
        public int EmpID { get; set; }
        public List<Employee> Employees { get; set; }
        public List<AllEmployees> AllEmployees { get; set; }
        public int Employeeid { get; set; }
        public List<Year> Years { get; set; }
        public string YearId { get; set; }
        public List<Month> Months { get; set; }
        public string MonthId { get; set; }

        public string nameEmp { get; set; }
        public List<string> NameEmployees { get; set; }

        public decimal salaryEmp { get; set; }
        public List<decimal> salaryEmployees { get; set; }

        public int dayAttend { get; set; }
        public List<int> dayAttendEmployees { get; set; }

        public int dayAbsence { get; set; }
        public List<int > dayAbsenceEmployees { get; set; }

        public int hoursbonus { get; set; }
        public List<int > hoursbonusEmployees { get; set; }

        public int hoursminus { get; set; }
        public List<int > hoursminusEmployees { get; set; }

        public double bonus { get; set; }
        public List<double> bonusEmployees { get; set; }

        public double minus { get; set; }
        public List<double> minusEmployees { get; set; }

        public double netsalary { get; set; }
        public List<double> netsalaryEmployees { get; set; }

        public int cnt { get; set; }
        
        public int month { get; set; }
        public int year { get; set; }
    }
}