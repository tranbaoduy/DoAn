using Model;
using Model.Model;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IInvoiceService : IBaseService<Invoice>
    {

    }
    public class InvoiceService : BaseService<Invoice>, IInvoiceService
    {
        public InvoiceService(MyContext myContext) : base(myContext)
        {

        }
    }
}
