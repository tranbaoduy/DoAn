using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Model.Model
    {
        public class baseEntity
        {
            [Column("Key")]
            public int Id { get; set; }
            [Column("DateCreate")]
            public string DateCreate { get; set; }
            [Column("CodeUnit")]
            public string CodeUnit { get; set; }
        }
    }

}
