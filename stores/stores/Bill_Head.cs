//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace stores
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill_Head
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill_Head()
        {
            this.Bill_Details = new HashSet<Bill_Details>();
        }
    
        public int ID { get; set; }
        public decimal Total { get; set; }
        public int client_Id { get; set; }
        public int Safe_ID { get; set; }
        public decimal Discount { get; set; }
        public System.DateTime Operate_Date { get; set; }
        public decimal paid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill_Details> Bill_Details { get; set; }
        public virtual Client Client { get; set; }
        public virtual Safe Safe { get; set; }
    }
}
