using Model;
using Model.Model;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IMedicineService : IBaseService<Medicine>
    {

    }
    public class MedicineService : BaseService<Medicine>, IMedicineService
    {
        public MedicineService(MyContext myContext) : base(myContext)
        {

        }
    }
}
