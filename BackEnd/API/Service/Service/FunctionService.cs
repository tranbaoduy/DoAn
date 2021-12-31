using Model;
using Model.Model;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IFunctionService : IBaseService<Functions>
    {

    }
    public class FunctionService : BaseService<Functions>, IFunctionService
    {
        public FunctionService(MyContext myContext) : base(myContext)
        {

        }
    }
}
