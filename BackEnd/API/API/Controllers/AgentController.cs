using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Service.Base;
using Service.Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgentController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        public AgentController(IRepositoryWrapper _repositoryWrapper)
        {
            repositoryWrapper = _repositoryWrapper;
        }

        [HttpPost("Paging")]
        public async Task<IActionResult> Paging(PageParameter pagePara)
        {
            Response<PageModel<Agent>> result = new Response<PageModel<Agent>>();
            try
            {
                result.data = repositoryWrapper.Agent.Paging(pagePara, x => x.NameAgent.Contains(pagePara.filter));
                result.message = "Lấy dữ liệu thành công";

            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Agent model)
        {
            Response<string> result = new Response<string>();
            try
            {
                if(model == null)
                {
                    return BadRequest();
                }

                repositoryWrapper.Agent.Create(model);
                repositoryWrapper.Agent.Save();

                result.message = "Thêm mới thành công";

            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> update(Agent model)
        {
            Response<Agent> result = new Response<Agent>();

            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                Agent OldAgent = repositoryWrapper.Agent.FinbyId(x => x.AgentCode == model.AgentCode);
                if (OldAgent == null)
                {
                    return NotFound();
                }

                repositoryWrapper.Agent.Update(model);
                repositoryWrapper.Agent.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Response<string> result = new Response<string>();
            if (id < 0)
            {
                return BadRequest();
            }

            try
            {
                Agent Agent = repositoryWrapper.Agent.FinbyId(x => x.AgentCode == id);
                if (Agent == null)
                {
                    return NotFound();
                }
                repositoryWrapper.Agent.Delete(Agent);
                repositoryWrapper.Agent.Save();
                result.status = "200";
                result.message = "Xóa dữ liệu thành công";
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            Response<List<Agent>> result = new Response<List<Agent>>();
            try
            {
                result.data = repositoryWrapper.Agent.getAll().ToList();
                result.message = "Lấy dữ liệu thành công";
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }
    }
}