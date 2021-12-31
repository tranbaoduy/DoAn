using Model;
using Model.Model;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IAgentService : IBaseService<Agent>
    {

    }
    public class AgentService : BaseService<Agent> , IAgentService
    {
        public AgentService(MyContext myContext):base(myContext)
        {

        }
    }
}
