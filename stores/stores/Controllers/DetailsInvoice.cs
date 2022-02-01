using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stores.Controllers
{
    public class DetailsInvoice
    {
        public int ID  { get; set; }
        public decimal TotalDis { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public string NameClient { get; set; }
        public string safeId { get; set; }

        public DateTime op { get; set; }

        public List<int> qtn { get; set; }
        public virtual ICollection<Bill_Details> bill_Details { get; set; }

        public List<decimal> price { get; set; }
        public List<decimal> Totalitem { get; set; }
        public List<string> Nameitem { get; set; }


    }
}