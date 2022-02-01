using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employees.Models
{
    public class AddMinusHours
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int MinusMoney { get; set; }
        public int BonusMoney { get; set; }
        public int AbsnceMoney { get; set; }
        public string  Absence { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateConfig { get; set; }
        public decimal salary { get; set; }
        public decimal salaryAbsence { get; set; }
    }
}