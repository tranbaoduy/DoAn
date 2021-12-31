using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Base
{
    public class PageParameter
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public string filter { get; set; }
    }
}
