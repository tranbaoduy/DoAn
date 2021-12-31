using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Model
{
    public class groupFunctions
    {
        [Column("Key")]
        public int Id { get; set; }
        [Column("role")]
        [StringLength(10)]
        public string role { get; set; }
        [Column("groups")]
        [StringLength(200)]
        public string groups { get; set; }
    }
}
