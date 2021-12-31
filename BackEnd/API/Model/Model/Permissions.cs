using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Permissions
    {
        [Column("Key")]
        public int Id { get; set; }
        [Column("codeFunction")]
        [StringLength(10)]
        public string codeFunction { get; set; }
        [Column("Controller")]
        [StringLength(30)]
        public string Controller { get; set; }

        [Column("userName")]
        [StringLength(100)]
        public string userName { get; set; }

        [Column("Insert")]
        public int Insert { get; set; }

        [Column("Edit")]
        public int Edit { get; set; }

        [Column("Delete")]
        public int Delete { get; set; }
    }
}
