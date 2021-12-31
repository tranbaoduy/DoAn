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
    public class MedicineController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        public MedicineController(IRepositoryWrapper _repositoryWrapper)
        {
            repositoryWrapper = _repositoryWrapper;
        }


        [HttpPost("Paging")]
        public async Task<IActionResult> Paging(PageParameter pagePara)
        {
            Response<PageModel<Medicine>> result = new Response<PageModel<Medicine>>();
            try
            {
                result.data = repositoryWrapper.Medicine.Paging(pagePara, x => x.CodeMedicine.Contains(pagePara.filter) || x.NameMedice.Contains(pagePara.filter));
                result.message = "Lấy dữ liệu thành công";

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Medicine model)
        {
            Response<string> result = new Response<string>();
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                repositoryWrapper.Medicine.Create(model);
                repositoryWrapper.Medicine.Save();

                result.message = "Thêm mới thành công";

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> update(Medicine model)
        {
            Response<Medicine> result = new Response<Medicine>();

            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                Medicine OldMedicine = repositoryWrapper.Medicine.FinbyId(x => x.CodeMedicine == model.CodeMedicine);
                if (OldMedicine == null)
                {
                    return NotFound();
                }

                repositoryWrapper.Medicine.Update(model);
                repositoryWrapper.Medicine.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            Response<string> result = new Response<string>();
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            try
            {
                Medicine Medicine = repositoryWrapper.Medicine.FinbyId(x => x.CodeMedicine == id);
                if (Medicine == null)
                {
                    return NotFound();
                }
                repositoryWrapper.Medicine.Delete(Medicine);
                repositoryWrapper.Medicine.Save();
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
            Response<List<Medicine>> result = new Response<List<Medicine>>();
            try
            {
                result.data = repositoryWrapper.Medicine.getAll().ToList();
                result.message = "Lấy dữ liệu thành công";
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }
    }
}