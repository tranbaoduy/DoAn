using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Service.Base;
using Service.DataModel;
using Service.Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissonController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;

        public PermissonController(IRepositoryWrapper _respository)
        {
            repository = _respository;
        }

        [HttpGet("getSideBar/{Username}")]
        public IActionResult getSideBar(string Username)
        {
            var response = new Response<List<SideBar>>();
            if (String.IsNullOrEmpty(Username))
            {
                return BadRequest();
            }
            try
            {
                response.data =  repository.Permission.getSideBarWithUserName(Username);
                response.message = "Lấy dữ liệu thành công";
            }
            catch(Exception ex)
            {
                response.message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("getAllFunction")]
        public IActionResult getAllFunction()
        {
            var response = new Response<List<Functions>>();
          
            try
            {
                response.data = repository.Function.getAll().ToList();
                response.message = "Lấy dữ liệu thành công";
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("getFunctionByUserName/{Username}")]
        public async Task<IActionResult> getFunctionByUserName(string Username)
        {
            Response<List<Permissions>> result = new Response<List<Permissions>>();
            try
            {
                if (String.IsNullOrEmpty(Username))
                {
                    return BadRequest();
                }
                result.data = repository.Permission.FindByCondition(x => x.userName == Username).ToList();
                result.message = "Lấy giữ liệu thành công";
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }
    }
}