using Model;
using Model.Model;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IInvoiceDetailService : IBaseService<InvoiceDetail>
    {

    }
    public class InvoiceDetailService : BaseService<InvoiceDetail>, IInvoiceDetailService
    {
        public InvoiceDetailService(MyContext myContext) : base(myContext)
        {

        }
    }
   
}
