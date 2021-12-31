using Model.Model;
using Model.Model.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.View
{
    public class ViewUser
    {
        public class Index
        {
            public string userName { get; set; }
            public string fullName { get; set; }
            public int AgentCode { get; set; }
            public string AgentName { get; set; }
        }
        public class FunctionUser
        {
            public string codeFunction { get; set; }
            public string nameFunction { get; set; }
            public bool Insert { get; set; }
            public bool Edit { get; set; }
            public bool Delete { get; set; }
        }
        public class Insert
        {
            public NguoiDung NguoiDung { get; set; }
            public List<Permissions> Permissions { get; set; }
            
        }

        public class Edit
        {
            public NguoiDung NguoiDung { get; set; }
            public List<FunctionUser> FunctionUser { get; set; }
            public List<Functions> Functions { get; set; }

        }

    }
}
