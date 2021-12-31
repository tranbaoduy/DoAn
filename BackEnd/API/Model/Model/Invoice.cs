using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Model
{

    public class Invoice
    {
        [Key]
        [Column("InvoiceCode")]
        [StringLength(100)]
        public string InvoiceCode { get; set; }

        [Column("TypeInvoice")]
        public int TypeInvoice { get; set; }

        [Column("TotalInvoice")]
        [StringLength(500)]
        public string TotalInvoice { get; set; }

        [Column("Status")]
        public int Status { get; set; }

        [Column("Paid")]
        [StringLength(500)]
        public string Paid { get; set; }

        [Column("oldDept")]
        [StringLength(500)]
        public string oldDept { get; set; }

        [Column("newDept")]
        [StringLength(500)]
        public string newDept { get; set; }

        [Column("UserCreate")]
        [StringLength(100)]
        public string UserCreate { get; set; }

        [Column("DateCreate")]
        public DateTime DateCreate { get; set; }

        [Column("AgentCode")]
        public int AgentCode { get; set; }

        [Column("NameCus")]
        [StringLength(500)]
        public string NameCus { get; set; }

        [Column("PhoneNumber")]
        [StringLength(500)]
        public string PhoneNumber { get; set; }

        [Column("SupCode")]
        public int SupCode { get; set; }
    }
}
