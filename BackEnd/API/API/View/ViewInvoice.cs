using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.View
{
    public class ViewInvoice
    {
        public class Insert
        {
            public Invoice Invoice { get; set; }
            public List<InvoiceDetail> InvoiceDetails { get; set; }
        }

        public class index
        {
            public string codeInvoice { get; set; }
            public string userCreate { get; set; }
            public DateTime dateCreate { get; set; }
            public string Suppllier { get; set; }
            public int Status { get; set; }
        }    

        public class Edit
        {
            public Invoice Invoice { get; set; }
            public List<InvoiceDetail> InvoiceDetails { get; set; }
        }

        public class Printf
        {
            public Invoice Invoice { get; set; }
            public List<InvoiceDetail> InvoiceDetails { get; set; }
            public Supplier Supplier { get; set; }
        }

    }
}
