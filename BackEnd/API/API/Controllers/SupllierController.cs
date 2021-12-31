using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Service.Base;
using Service.Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupllierController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        public SupllierController(IRepositoryWrapper _repositoryWrapper)
        {
            repositoryWrapper = _repositoryWrapper;
        }

        [HttpPost("Paging")]
        public async Task<IActionResult> Paging(PageParameter pagePara)
        {
            Response<PageModel<Supplier>> result = new Response<PageModel<Supplier>>();
            try
            {
                result.data = repositoryWrapper.Supplier.Paging(pagePara, x => x.SupName.Contains(pagePara.filter));
                result.message = "Lấy dữ liệu thành công";

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Supplier model)
        {
            Response<string> result = new Response<string>();
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                repositoryWrapper.Supplier.Create(model);
                repositoryWrapper.Supplier.Save();

                result.message = "Thêm mới thành công";

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> update(Supplier model)
        {
            Response<Supplier> result = new Response<Supplier>();

            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                Supplier OldSupplier = repositoryWrapper.Supplier.FinbyId(x => x.SupCode == model.SupCode);
                if (OldSupplier == null)
                {
                    return NotFound();
                }

                repositoryWrapper.Supplier.Update(model);
                repositoryWrapper.Supplier.Save();
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
                Supplier Supplier = repositoryWrapper.Supplier.FinbyId(x => x.SupCode == id);
                if (Supplier == null)
                {
                    return NotFound();
                }
                repositoryWrapper.Supplier.Delete(Supplier);
                repositoryWrapper.Supplier.Save();
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
            Response<List<Supplier>> result = new Response<List<Supplier>>();
            try
            {
                result.data = repositoryWrapper.Supplier.getAll().ToList();
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