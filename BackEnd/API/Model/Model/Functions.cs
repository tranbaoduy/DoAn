using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Functions 
    {
        [Column("Key")]
        public int Id { get; set; }
        [Column("codeFunction")]
        [StringLength(10)]
        public string code { get; set; }

        [Column("nameFunction")]
        [StringLength(100)]
        public string name { get; set; }

        [Column("url")]
        [StringLength(200)]
        public string url { get; set; }
        [Column("component")]
        [StringLength(200)]
        public string component { get; set; }
    }
}
