using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.Model;
using Model.Model.Login;
using Service.Base;
using Service.DataModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IUserService : IBaseService<NguoiDung>
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        NguoiDung GetById(int id);
        Permisssion GetUserAndPPermisssion(int userId);
    }
    public class UserService : BaseService<NguoiDung>, IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, MyContext _dbcontext) : base(_dbcontext)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = base.context.NguoiDungs.SingleOrDefault(x => x.userName == model.Username && x.passWord == model.Password);
            // return null if user not found
            if (user == null) return null;
            // authentication successful so generate jwt token
            var token = generateJwtToken(user);
            var AgentName = "";
            if (user.userName != "Admin")
            {
                AgentName = base.context.Agents.SingleOrDefault(x => x.AgentCode == user.AgentCode).NameAgent;
            }
            return new AuthenticateResponse(user, token, AgentName);
        }

        public NguoiDung GetById(int id)
        {
            
            return context.NguoiDungs.FirstOrDefault(x => x.Id == id);
        }

        private string generateJwtToken(NguoiDung user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Permisssion GetUserAndPPermisssion(int userId)
        {
            
            NguoiDung user = context.NguoiDungs.FirstOrDefault(x => x.Id == userId);
            List<Permissions> lst = context.Permissions.Where(x => x.userName == user.userName).ToList();
            Permisssion result = new Permisssion()
            {
                User = user,
                lst = lst,
            };
            return result;
        }
    }
}
