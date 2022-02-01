using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hr.Models
{
    public class ReportEmployee
    {
        public int EmpID { get; set; }
        public List<Employee> Employees { get; set; }
        public int Employeeid { get; set; }
       // public List<Year> Years { get; set; }
        public string YearId { get; set; }
     //   public List<Month> Months { get; set; }
        public string MonthId { get; set; }

        public string nameEmp { get; set; }

        public decimal salaryEmp { get; set; }

        public int dayAttend { get; set; }

        public int dayAbsence { get; set; }

        public decimal hoursbonus { get; set; }

        public decimal hoursminus { get; set; }

        public int bonus { get; set; }

        public int minus { get; set; }

        public decimal netsalary { get; set; }

        public decimal AbsencePenalty { get; set; }

        public int month { get; set; }
        public int year { get; set; }
        public int holidays { get; set; }


        public int Attendholiday { get; set; }
    }
}