//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HrSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attendance
    {
        public int ID { get; set; }
        public int Employeeid { get; set; }
        public System.DateTime Todaydate { get; set; }
        public System.DateTime LeavingTime { get; set; }
        public System.DateTime AttendingTime { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
