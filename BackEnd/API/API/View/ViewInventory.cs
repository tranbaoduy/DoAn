using System;
using System.Collections.Generic;

namespace API.View
{
    public class ViewInventory
    {
        public class DetailMedicine
        {
            public string SeriNumber { get; set; }
            public string TotalCount { get; set; }
            public string Expire { get; set; }
            public string NameSupplier { get; set; }
        }

        public class ViewIndex
        {
            public string MedicineCode { get; set; }
            public string MedicineName { get; set; }
            public List<DetailMedicine> lstDetail { get; set; }

            public ViewIndex()
            {
                lstDetail = new List<DetailMedicine>();
            }
                
        }

        public class UpdatePriceSell
        {
            public string PriceSell { get; set; }
            public string InvoiceCode { get; set; }
            public string MedicineCode { get; set; }
        }

        public class MedicineInventory
        {
            public string CodeMedicine { get; set; }
            public string NameMedicine { get; set; }
            public string ExChange { get; set; }
        }

        public class InvoiceSell
        {
            public string PriceSell { get; set; }
            public string SeriNumber { get; set; }
            public string Supplier { get; set; }
            public int SupCode { get; set; }
            public string Count { get; set; }
            public DateTime DateMade { get; set; }
            public DateTime DateExpire { get; set; }
        }
    }
}
