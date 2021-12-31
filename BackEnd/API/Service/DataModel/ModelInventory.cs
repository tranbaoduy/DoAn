using System.Collections.Generic;

namespace Service.DataModel
{
    public class ModelInventory
    {
        public class DetailMedicine
        {
            public string InvoiceCode { get; set; }
            public string Count { get; set; }
            public string Expire { get; set; }
            public string Supplier { get; set; }
            public string Price { get; set; }
            public string PriceSell { get; set; }
            public string ExChange { get; set; }
        }

        public class ViewIndex
        {
            public string MedicineCode { get; set; }
            public string MedicineName { get; set; }
            public string TotalCount { get; set; }
            public List<DetailMedicine> lstDetail { get; set; }

            public ViewIndex()
            {
                lstDetail = new List<DetailMedicine>();
            }

        }
    }
}
