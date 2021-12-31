using Model.Model.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Model
{
    public class Agent 
    {
        //[Column("Key")]
        //public int Id { get; set; }

        [Key]
        [Column("AgentCode")]
        public int AgentCode { get; set; }

        [Column("NameAgent")]
        [StringLength(100)]
        public string NameAgent { get; set; }

        [Column("AddressAgent")]
        [StringLength(100)]
        public string AddressAgent { get; set; }

        [Column("PhoneAgent")]
        [StringLength(100)]
        public string PhoneAgent { get; set; }
    }
}
