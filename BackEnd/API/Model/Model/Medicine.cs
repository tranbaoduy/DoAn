using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Medicine
    {

        [Key]
        [Column("CodeMedicine")]
        [StringLength(100)]
        public string CodeMedicine { get; set; }

        [Column("NameMedice")]
        [StringLength(200)]
        public string NameMedice { get; set; }

        [Column("DosageForm")]
        [StringLength(200)]
        public string DosageForm { get; set; }


        [Column("ExChange")]
        [StringLength(200)]
        public string ExChange { get; set; }

        [Column("UnitLast")]
        [StringLength(20)]
        public string UnitLast { get; set; }
    }
}
