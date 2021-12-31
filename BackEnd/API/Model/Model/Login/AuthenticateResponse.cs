using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Model.Login
{
    public class AuthenticateResponse
    {
         public int id { get; set; }
        public string HoVaTen { get; set; }
        public string Username { get; set; }
        public string role { get; set; }
        public string Token { get; set; }
        public string AgentCode { get; set; }
        public string AgentName { get; set; }



        public AuthenticateResponse(NguoiDung user, string token, string AgentName)
        {
            id = user.Id;
            Username = user.userName;
            HoVaTen = user.fullName;
            Token = token;
            role = user.role;
            AgentCode = user.AgentCode.ToString();
            AgentName = AgentName;
        }
    }
}
