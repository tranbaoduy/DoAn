using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helper;
using API.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Model.Model.Login;
using Service.Base;
using Service.DataModel;
using Service.Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRepositoryWrapper repositoryWrapper;
        public UserController(IUserService userService, IRepositoryWrapper _repositoryWrapper)
        {
            _userService = userService;
            repositoryWrapper = _repositoryWrapper;
        }
        [Authorize]
        [HttpPost("Paging")]
        public async Task<IActionResult> Paging(PageParameter pagePara)
        {
            Response<PageModel<ViewUser.Index>> result = new Response<PageModel<ViewUser.Index>>();
            try
            {
                var user = (Permisssion)HttpContext.Items["UserAndPPermisssion"];
                PageModel<NguoiDung> User = new PageModel<NguoiDung>();
                var lstAgent = repositoryWrapper.Agent.getAll().ToList();
                if (user.User.AgentCode == 1) 
                {
                   User = repositoryWrapper.User.Paging(pagePara, x => (x.userName.Contains(pagePara.filter) || x.fullName.Contains(pagePara.filter)));
                }
                else
                {
                    User = repositoryWrapper.User.Paging(pagePara, x =>x.AgentCode == user.User.AgentCode && (x.userName.Contains(pagePara.filter) || x.fullName.Contains(pagePara.filter)));
                }
                if(User != null)
                {
                    List<ViewUser.Index> lst = new List<ViewUser.Index>();
                    for (int i = 0; i < User.data.Count; i++)
                    {
                        ViewUser.Index item = new ViewUser.Index
                        {
                            userName = User.data[i].userName,
                            fullName = User.data[i].fullName,
                            AgentCode = User.data[i].AgentCode,
                            AgentName = User.data[i].AgentCode == 1 ? "" : lstAgent.FirstOrDefault(y => y.AgentCode == User.data[i].AgentCode).NameAgent,
                        };
                        lst.Add(item);
                    }
                    PageModel<ViewUser.Index> tempResult = new PageModel<ViewUser.Index>
                    {
                        TotalPage = User.TotalPage,
                        cout = User.cout,
                        data = lst
                    };
                    result.data = tempResult;
                    result.message = "Lấy dữ liệu thành công";
                }

                
                result.message = "Lấy dữ liệu thành công";

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpPost("Login")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        [Authorize]
        [HttpGet("GetLstUser")]
        public IActionResult GetLstUser()
        {
            Response<List<string>> result = new Response<List<string>>();
            try
            {
                result.data  = repositoryWrapper.User.getAll().Select(x => x.userName).ToList();
                result.message = "Lấy giữ liệu thành công";
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }
        [Authorize]
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(ViewUser.Insert model)
        {
            Response<string> result = new Response<string>();
            try
            {
                if (model.NguoiDung == null || model.Permissions.Count <= 0)
                {
                    return BadRequest();
                }
                repositoryWrapper.User.Create(model.NguoiDung);
                repositoryWrapper.Permission.CreateMany(model.Permissions);
                repositoryWrapper.save();
                result.message = "Lấy giữ liệu thành công";
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }
        [Authorize]
        [HttpGet("getUserEdit/{username}")]
        public async Task<IActionResult> getUserEdit(string username)
        {
            Response<ViewUser.Edit> result = new Response<ViewUser.Edit>();
            try
            {
                if (String.IsNullOrEmpty(username))
                {
                    return BadRequest();
                }
                List<ViewUser.FunctionUser> lstFunctionUser = new List<ViewUser.FunctionUser>();
                List<Permissions> lstPermission = repositoryWrapper.Permission.FindByCondition(x => x.userName == username).ToList();
                List<Functions> lstFunctions = repositoryWrapper.Function.getAll().ToList();
                var Code = lstFunctions.Select(x => x.code).Except(lstPermission.Select(y => y.codeFunction));
                for (int i  = 0; i < lstPermission.Count;i++)
                {
                    ViewUser.FunctionUser functionUser = new ViewUser.FunctionUser()
                    {
                        codeFunction = lstPermission[i].codeFunction,
                        nameFunction = lstFunctions.FirstOrDefault(x => x.code == lstPermission[i].codeFunction).name,
                        Insert = lstPermission[i].Insert == 1 ? true : false,
                        Edit = lstPermission[i].Edit == 1 ? true : false,
                        Delete = lstPermission[i].Delete == 1 ? true : false
                    };
                    lstFunctionUser.Add(functionUser);
                }

                ViewUser.Edit item = new ViewUser.Edit()
                {
                    NguoiDung = repositoryWrapper.User.FindByCondition(x => x.userName == username).FirstOrDefault(),
                    FunctionUser = lstFunctionUser,
                    Functions = lstFunctions.Where(x => Code.Contains(x.code)).ToList()
                };
                result.data = item;
                result.message = "Lấy giữ liệu thành công";
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> update(ViewUser.Insert model)
        {
            Response<string> result = new Response<string>();

            if (model.NguoiDung == null || model.Permissions.Count < 0)
            {
                return BadRequest();
            }

            try
            {
                NguoiDung OldUser = repositoryWrapper.User.FinbyId(x => x.Id == model.NguoiDung.Id);
                if (OldUser == null)
                {
                    return NotFound();
                }
                List<Permissions> lstOld = repositoryWrapper.Permission.FindByCondition(x => x.userName == model.NguoiDung.userName).ToList();
                if (lstOld.Count > 0)
                {
                    repositoryWrapper.Permission.DeleteMany(lstOld);
                }
                repositoryWrapper.User.Update(model.NguoiDung);
                repositoryWrapper.Permission.CreateMany(model.Permissions);
                repositoryWrapper.save();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }
        [Authorize]
        [HttpDelete("Delete/{userName}")]
        public async Task<IActionResult> Delete(string userName)
        {
            Response<string> result = new Response<string>();
            if (String.IsNullOrEmpty(userName))
            {
                return BadRequest();
            }

            try
            {
                NguoiDung User = repositoryWrapper.User.FinbyId(x => x.userName == userName);
                List<Permissions> lst = repositoryWrapper.Permission.FindByCondition(x => x.userName == userName).ToList();
                repositoryWrapper.User.Delete(User);
                repositoryWrapper.Permission.DeleteMany(lst);
                repositoryWrapper.save();
                result.status = "200";
                result.message = "Xóa dữ liệu thành công";
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }
    }   
}