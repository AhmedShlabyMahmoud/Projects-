using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hr.Models
{
    public class ReportsClass
    {
        public int EmpID { get; set; }
        public List<Employee> Employees { get; set; }
       
        public int Employeeid { get; set; }

        public int holidays { get; set; }
        public string YearId { get; set; }
        //   public List<Month> Months { get; set; }
        public string MonthId { get; set; }

        public List<int> EmployeeHolidays { get; set; }


        public int Attendholiday { get; set; }
        public List<int> EmployeeAttendHoliday { get; set; }


        public string nameEmp { get; set; }
        public List<string> NameEmployees { get; set; }

        public decimal salaryEmp { get; set; }
        public List<decimal> salaryEmployees { get; set; }

        public int dayAttend { get; set; }
        public List<int> dayAttendEmployees { get; set; }

        public int dayAbsence { get; set; }
        public List<int> dayAbsenceEmployees { get; set; }

        public int hoursbonus { get; set; }
        public List<decimal> hoursbonusEmployees { get; set; }

        public int hoursminus { get; set; }
        public List<decimal> hoursminusEmployees { get; set; }

        public double bonus { get; set; }
        public List<int> bonusEmployees { get; set; }

        public double minus { get; set; }
        public List<int> minusEmployees { get; set; }

        public double netsalary { get; set; }
        public List<decimal> netsalaryEmployees { get; set; }

        public decimal AbsencePenalty { get; set; }

        public List<decimal> EmployeesAbsencePenalty { get; set; }


        public int cnt { get; set; }

        public int month { get; set; }
        public int year { get; set; }
        
    }
}