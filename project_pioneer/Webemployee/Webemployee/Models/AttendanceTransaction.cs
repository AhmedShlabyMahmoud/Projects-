//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webemployee.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AttendanceTransaction
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public Nullable<System.DateTime> TodayDateTrans { get; set; }
        public Nullable<System.DateTime> AttendTime { get; set; }
        public Nullable<System.DateTime> LeaveTime { get; set; }
        public Nullable<int> minus { get; set; }
        public Nullable<int> bonus { get; set; }
        public string Attend { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
