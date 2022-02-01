using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace stores.Controllers
{
    public class SalseInvoice
    {
        public int ID { get; set; }
        public decimal Total { get; set; }
        public int Qnt { get; set; }
        public int cnt { get; set; }
        public int Num { get; set; }
        public string numbers { get; set; }
        public int count { get; set; }
        public decimal price { get; set; }
        public int client_Id { get; set; }
        public string  unit { get; set; }
        public int Safe_ID { get; set; }
        public int Itemsid { get; set; }
        public List<int> Items  { get; set; }
        public int Storesid { get; set; }
        public decimal Discount { get; set; }

        [DataType(DataType.Time)]
        public System.DateTime Operate_Time { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime Operate_Date { get; set; }


        public decimal paid { get; set; }

        public decimal TotalDis { get; set; }
        public virtual ICollection<Bill_Details> Bill_Details { get; set; }
        public virtual ItemUnitsTable ItemUnitsTables { get; set; }

        public virtual ICollection<Stocke> Stockes { get; set; }

        public virtual ItemsTable ItemsTable { get; set; }
        public virtual StoresTable StoresTable { get; set; }
        public virtual Client Client { get; set; }
        public virtual Safe Safe { get; set; }
    }
}