using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Model.Model;
using Service.Base;

namespace Service.Service
{
    public interface ISupplierService : IBaseService<Supplier>
    {

    }
    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        public SupplierService(MyContext myContext) : base(myContext)
        {

        }
    }
}
