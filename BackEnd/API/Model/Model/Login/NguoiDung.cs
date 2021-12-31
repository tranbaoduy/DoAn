using Model.Model.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Model.Login
{
    public class NguoiDung
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("userName")]
        [StringLength(200)]
        public string userName { get; set; }
        [Column("passWord")]
        [StringLength(200)]
        public string passWord { get; set; }
        [Column("role")]
        [StringLength(10)]
        public string role { get; set; }
        [Column("fullName")]
        [StringLength(200)]
        public string fullName { get; set; }
        [Column("AgentCode")]
        public int AgentCode { get; set; }
    }
}
