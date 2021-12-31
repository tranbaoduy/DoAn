using Model.Model;
using Model.Model.Login;
using System.Collections.Generic;

namespace Service.DataModel
{
    public class Permisssion
    {
        public NguoiDung User { get; set; }
        public List<Permissions> lst { get; set; }
    }
}
