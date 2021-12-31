using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Base
{
    public class PageModel<T>
    {
        public int TotalPage { get; set; }
        public List<T> data { get; set; }
        public int cout { get; set; }
    }
}
