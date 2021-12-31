using Model;
using Model.Model;
using Service.Base;
using Service.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IPermissionService : IBaseService<Permissions>
    {
        List<SideBar> getSideBarWithUserName(string UserName);
    }
    public class PermissionService : BaseService<Permissions>, IPermissionService
    {
        public PermissionService(MyContext myContext) : base(myContext)
        {

        }

        public List<SideBar> getSideBarWithUserName(string UserName)
        {
            List<Functions> functions = base.context.functions.ToList();
            List<Permissions> permissions = base.context.Permissions.Where(x => x.userName == UserName).ToList();
            List<SideBar>  sidebars = new List<SideBar>();
            for(int i = 0; i < permissions.Count; i++)
            {
                for(int j = 0; j < functions.Count; j++)
                {
                    if(functions[j].code == permissions[i].codeFunction)
                    {
                        var newItem = new SideBar
                        {
                            codeFunction = functions[j].code,
                            link = "/" + functions[j].url,
                            title = functions[j].name,
                            compoment = functions[j].component
                        };
                        sidebars.Add(newItem);
                    }
                }
            }
            return sidebars;
        }
    }
}
