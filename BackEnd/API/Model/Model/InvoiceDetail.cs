using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Model
{
    public class InvoiceDetail
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("InvoiceRefid")]
        [StringLength(100)]
        public string InvoiceRefid { get; set; }


        [Column("CodeMedicine")]
        [StringLength(100)]
        public string CodeMedicine { get; set; }

        [Column("NameMedice")]
        [StringLength(100)]
        public string NameMedice { get; set; }

        [Column("Count")]
        [StringLength(100)]
        public string Count { get; set; }

        [Column("Price")]
        [StringLength(500)]
        public string Price { get; set; }

        [Column("SeriNumber")]
        [StringLength(200)]
        public string SeriNumber { get; set; }

        [Column("DateExpire")]
        public DateTime DateExpire { get; set; }
        [Column("DateMade")]
        public DateTime DateMade { get; set; }
        [Column("Total")]
        [StringLength(500)]
        public string Total { get; set; }

        [Column("AgentCode")]
        public int AgentCode { get; set; }
        [Column("SupCode")]
        public int SupCode { get; set; }
    }
}
