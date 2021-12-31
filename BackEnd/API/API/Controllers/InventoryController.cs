using API.Helper;
using API.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Service.Base;
using Service.DataModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API.View.ViewInventory;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        public InventoryController(IRepositoryWrapper _repositoryWrapper)
        {
            repositoryWrapper = _repositoryWrapper;
        }

        [HttpPost("Paging")]
        public async Task<IActionResult> Paging(PageParameter pagePara)
        {
            Response<PageModel<ModelInventory.ViewIndex>> result = new Response<PageModel<ModelInventory.ViewIndex>>();
            try
            {
                var user = (Permisssion)HttpContext.Items["UserAndPPermisssion"];
                result.data = repositoryWrapper.Inventory.PagingAbc(pagePara, x => x.AgentCode == user.User.AgentCode && (x.CodeMedicine.Contains(pagePara.filter) || x.NameMedice.Contains(pagePara.filter)));
                result.message = "Lấy dũ liệu thành công";
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }
        [HttpPut("UpdatePriceSell")]
        public async Task<IActionResult> UpdatePriceSell(ViewInventory.UpdatePriceSell model)
        {
            Response<string> result = new Response<string>();
            if (model == null)
            {
                return BadRequest();
            }
            try
            {
                var user = (Permisssion)HttpContext.Items["UserAndPPermisssion"];
                Inventory inventory = repositoryWrapper.Inventory.FinbyId(x => x.CodeMedicine == model.MedicineCode && x.InvoiceRefid == model.InvoiceCode && x.AgentCode == user.User.AgentCode);
                inventory.PriceSell = model.PriceSell;
                repositoryWrapper.Inventory.Update(inventory);
                repositoryWrapper.save();
                result.message = "Update dũ liệu thành công";
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpGet("GetMedicine")]
        public async Task<IActionResult> GetMedicine()
        {
            Response<List<MedicineInventory>> result = new Response<List<MedicineInventory>>();
            try
            {
                var user = (Permisssion)HttpContext.Items["UserAndPPermisssion"];
                List<Inventory> lstInventory = repositoryWrapper.Inventory.FindByCondition(x => x.AgentCode == user.User.AgentCode).ToList();
                var lstMedicine = lstInventory.Select(x => new { CodeMedicine = x.CodeMedicine, NameMedicine = x.NameMedice }).Distinct().ToList();
                List<MedicineInventory> lst = new List<MedicineInventory>();
                for(int i = 0; i < lstMedicine.Count;i++)
                {
                    MedicineInventory item = new MedicineInventory()
                    {
                        CodeMedicine = lstMedicine[i].CodeMedicine,
                        NameMedicine = lstMedicine[i].NameMedicine,
                        ExChange = repositoryWrapper.Medicine.FinbyId(x => x.CodeMedicine == lstMedicine[i].CodeMedicine).ExChange
                    };
                    lst.Add(item);
                }
                result.data = lst;
                result.status = "Lấy dữ liệu thành công";
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpGet("GetLstInventory/{CodeMedicine}")]
        public async Task<IActionResult> GetLstInventory(string CodeMedicine)
        {
            Response<List<InvoiceSell>> result = new Response<List<InvoiceSell>>();
            try
            {
                var user = (Permisssion)HttpContext.Items["UserAndPPermisssion"];
                List<Inventory> lstInventory = repositoryWrapper.Inventory.FindByCondition(x => x.CodeMedicine == CodeMedicine && x.AgentCode == user.User.AgentCode).ToList();
                List<Supplier> suppliers = repositoryWrapper.Supplier.FindByCondition(x => lstInventory.Select(y => y.SupCode).Contains(x.SupCode)).ToList();
                List<InvoiceSell> lst = new List<InvoiceSell>();
                for (int i = 0;i < lstInventory.Count;i++)
                {
                    InvoiceSell newItem = new InvoiceSell()
                    {
                        Supplier = suppliers.FirstOrDefault(x => x.SupCode == lstInventory[i].SupCode).SupName,
                        SeriNumber = lstInventory[i].SeriNumber + "-(" + lstInventory[i].DateMade.ToString("dd/MM/yyyy") + "-" + lstInventory[i].DateExpire.ToString("dd/MM/yyyy") + ")",
                        PriceSell = lstInventory[i].PriceSell,
                        Count = lstInventory[i].Count,
                        SupCode = lstInventory[i].SupCode,
                        DateMade = lstInventory[i].DateMade,
                        DateExpire = lstInventory[i].DateExpire,
                    };
                    lst.Add(newItem);
                }
                result.data = lst;
                result.status = "Lấy dữ liệu thành công";
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

    }
}
