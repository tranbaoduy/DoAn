using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Supplier
    {
        [Key]
        [Column("SupCode")]
        public int SupCode { get; set; }

        [Column("SupName")]
        [StringLength(200)]
        public string SupName { get; set; }

        [Column("SupAddress")]
        [StringLength(200)]
        public string SupAddress { get; set; }

        [Column("SupPhone")]
        [StringLength(200)]
        public string SupPhone { get; set; }

        [Column("Paid")]
        [StringLength(200)]
        public string Paid { get; set; }

        [Column("Dept")]
        [StringLength(200)]
        public string Dept { get; set; }
    }
}
