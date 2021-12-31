using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helper;
using API.View;
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
    [Authorize]
    public class InvoiceController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        public InvoiceController(IRepositoryWrapper _repositoryWrapper)
        {
            repositoryWrapper = _repositoryWrapper;
        }


        [HttpGet("getNumberInvoice/{typeInvoice}")]
        public async Task<IActionResult> getNumberInvoice(int typeInvoice)
        {
            Response<string> result = new Response<string>();
            try
            {
                var user = (Permisssion)HttpContext.Items["UserAndPPermisssion"];
                List<Invoice> lst = repositoryWrapper.Invoice.FindByCondition(x => x.AgentCode == user.User.AgentCode && x.DateCreate.Day == DateTime.Now.Day && x.DateCreate.Month == DateTime.Now.Month && x.DateCreate.Year == DateTime.Now.Year && x.TypeInvoice == typeInvoice).ToList();
                result.data = (lst.Count + 1).ToString();
                result.message = "Lấy giữ liệu thành công";
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpPost("Paging")]
        public async Task<IActionResult> Paging(PageParameter pagePara)
        {
            Response<PageModel<ViewInvoice.index>> result = new Response<PageModel<ViewInvoice.index>>();
            try
            {
                var user = (Permisssion)HttpContext.Items["UserAndPPermisssion"];
                PageModel<Invoice> data = repositoryWrapper.Invoice.Paging(pagePara, x => (x.AgentCode == user.User.AgentCode && x.TypeInvoice == 1) && (x.UserCreate.Contains(pagePara.filter)));
                var lstSupCode = data.data.Select(x => x.SupCode).ToList();
                List<Supplier> lstSup = repositoryWrapper.Supplier.FindByCondition(x => lstSupCode.Contains(x.SupCode)).ToList();
                if(data != null)
                {
                    List<ViewInvoice.index> lst = new List<ViewInvoice.index>();
                    for (int i = 0; i < data.data.Count; i++)
                    {
                        ViewInvoice.index item = new ViewInvoice.index
                        {
                            codeInvoice = data.data[i].InvoiceCode,
                            userCreate = data.data[i].UserCreate,
                            dateCreate = data.data[i].DateCreate,
                            Suppllier = lstSup.FirstOrDefault(y => y.SupCode == data.data[i].SupCode).SupName,
                            Status = data.data[i].Status
                        };
                        lst.Add(item);
                    }
                    PageModel<ViewInvoice.index> tempResult = new PageModel<ViewInvoice.index>
                    {
                        TotalPage = data.TotalPage,
                        cout = data.cout,
                        data = lst.OrderByDescending(x => x.dateCreate).ToList()
                    };
                    result.data = tempResult;
                    result.message = "Lấy dữ liệu thành công";
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpPost("PagingSell")]
        public async Task<IActionResult> PagingSell(PageParameter pagePara)
        {
            Response<PageModel<ViewInvoice.index>> result = new Response<PageModel<ViewInvoice.index>>();
            try
            {
                var user = (Permisssion)HttpContext.Items["UserAndPPermisssion"];
                PageModel<Invoice> data = repositoryWrapper.Invoice.Paging(pagePara, x => (x.AgentCode == user.User.AgentCode && x.TypeInvoice == 2) && (x.UserCreate.Contains(pagePara.filter)));
                if (data != null)
                {
                    List<ViewInvoice.index> lst = new List<ViewInvoice.index>();
                    for (int i = 0; i < data.data.Count; i++)
                    {
                        ViewInvoice.index item = new ViewInvoice.index
                        {
                            codeInvoice = data.data[i].InvoiceCode,
                            userCreate = data.data[i].UserCreate,
                            dateCreate = data.data[i].DateCreate,
                            Suppllier = data.data[i].NameCus,
                            Status = data.data[i].Status
                        };
                        lst.Add(item);
                    }
                    PageModel<ViewInvoice.index> tempResult = new PageModel<ViewInvoice.index>
                    {
                        TotalPage = data.TotalPage,
                        cout = data.cout,
                        data = lst.OrderByDescending(x => x.dateCreate).ToList()
                    };
                    result.data = tempResult;
                    result.message = "Lấy dữ liệu thành công";
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(ViewInvoice.Insert model)
        {
            Response<string> result = new Response<string>();
            try
            {
                if (model.Invoice == null || model.InvoiceDetails.Count <= 0)
                {
                    return BadRequest();
                }

                if(model.Invoice.TypeInvoice == 1 && model.Invoice.Status == 1)
                {
                    model.Invoice.Paid = model.Invoice.Paid.Replace(",", "");
                    model.Invoice.oldDept = model.Invoice.oldDept.Replace(",", "");
                    model.Invoice.newDept = model.Invoice.newDept.Replace(",", "");
                    model.Invoice.TotalInvoice = model.Invoice.TotalInvoice.Replace(",", "");
                    for (int i = 0; i < model.InvoiceDetails.Count;i++)
                    {
                        model.InvoiceDetails[i].AgentCode = model.Invoice.AgentCode;
                        model.InvoiceDetails[i].SupCode = model.Invoice.SupCode;
                    }

                   
                    repositoryWrapper.Invoice.Create(model.Invoice);
                    repositoryWrapper.InvoiceDetail.CreateMany(model.InvoiceDetails);
                   
                    //repositoryWrapper.Supplier.Update(sup);
                }
                
                repositoryWrapper.save();

                result.message = "Thêm mới thành công";

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpPost("InsertSell")]
        public async Task<IActionResult> InsertSell(ViewInvoice.Insert model)
        {
            Response<string> result = new Response<string>();
            try
            {
                if (model.Invoice == null || model.InvoiceDetails.Count <= 0)
                {
                    return BadRequest();
                }

                if (model.Invoice.TypeInvoice == 2 && model.Invoice.Status == 1)
                {
                    model.Invoice.Paid = model.Invoice.Paid.Replace(",", "");
                    model.Invoice.oldDept = model.Invoice.oldDept.Replace(",", "");
                    model.Invoice.newDept = model.Invoice.newDept.Replace(",", "");
                    model.Invoice.TotalInvoice = model.Invoice.TotalInvoice.Replace(",", "");
                    for (int i = 0; i < model.InvoiceDetails.Count; i++)
                    {
                        model.InvoiceDetails[i].AgentCode = model.Invoice.AgentCode;
                    }
                    repositoryWrapper.Invoice.Create(model.Invoice);
                    repositoryWrapper.InvoiceDetail.CreateMany(model.InvoiceDetails);
                }

                repositoryWrapper.save();
                result.message = "Thêm mới thành công";
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpGet("GetInvoice/{id}")]
        public async Task<IActionResult> GetInvoice(string id)
        {
            Response<ViewInvoice.Insert> result = new Response<ViewInvoice.Insert>();
            try
            {
                if (String.IsNullOrEmpty(id))
                {
                    return BadRequest();
                }
                Invoice invoice = repositoryWrapper.Invoice.FinbyId(x => x.InvoiceCode == id);
                List <InvoiceDetail> lstDetail = repositoryWrapper.InvoiceDetail.FindByCondition(x => x.InvoiceRefid == id).ToList();
                ViewInvoice.Insert data = new ViewInvoice.Insert
                {
                    Invoice = invoice,
                    InvoiceDetails = lstDetail
                };
                if (data != null)
                {
                    result.data = data;
                    result.message = "Lấy dữ liệu thành công";
                }
                
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpGet("GetInvoicePrintf/{id}")]
        public async Task<IActionResult> GetInvoicePrintf(string id)
        {
            Response<ViewInvoice.Printf> result = new Response<ViewInvoice.Printf>();
            try
            {
                if (String.IsNullOrEmpty(id))
                {
                    return BadRequest();
                }
                Invoice invoice = repositoryWrapper.Invoice.FinbyId(x => x.InvoiceCode == id);
                List<InvoiceDetail> lstDetail = repositoryWrapper.InvoiceDetail.FindByCondition(x => x.InvoiceRefid == id).ToList();
                Supplier supplier = repositoryWrapper.Supplier.FinbyId( x=> x.SupCode == invoice.SupCode);
                ViewInvoice.Printf data = new ViewInvoice.Printf
                {
                    Invoice = invoice,
                    InvoiceDetails = lstDetail,
                    Supplier = supplier
                };
                if (data != null)
                {
                    result.data = data;
                    result.message = "Lấy dữ liệu thành công";
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> update(ViewInvoice.Edit model)
        {
            Response<string> result = new Response<string>();

            if (model.Invoice == null || model.InvoiceDetails.Count < 0)
            {
                return BadRequest();
            }

            try
            {
                Invoice oldInvoice = repositoryWrapper.Invoice.FinbyId(x => x.InvoiceCode == model.Invoice.InvoiceCode);
                List<InvoiceDetail> invoiceDetails = repositoryWrapper.InvoiceDetail.FindByCondition(x => x.InvoiceRefid == model.Invoice.InvoiceCode).ToList();
                if(oldInvoice == null && invoiceDetails.Count < 0)
                {
                    return NotFound();
                }
                if(invoiceDetails.Count > 0)
                {
                    repositoryWrapper.InvoiceDetail.DeleteMany(invoiceDetails);
                }
                model.Invoice.Paid = model.Invoice.Paid.Replace(",", "");
                model.Invoice.oldDept = model.Invoice.oldDept.Replace(",", "");
                model.Invoice.newDept = model.Invoice.newDept.Replace(",", "");
                model.Invoice.TotalInvoice = model.Invoice.TotalInvoice.Replace(",", "");
                for (int i = 0; i < model.InvoiceDetails.Count; i++)
                {
                   model.InvoiceDetails[i].Total = model.InvoiceDetails[i].Total.Replace(",", "");
                   model.InvoiceDetails[i].SupCode = model.Invoice.SupCode;
                }
                repositoryWrapper.Invoice.Update(model.Invoice);
                repositoryWrapper.InvoiceDetail.CreateMany(model.InvoiceDetails);
                repositoryWrapper.save();
                result.message = "Sửa dữ liệu thành công.";
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
                Invoice Invoice = repositoryWrapper.Invoice.FinbyId(x => x.InvoiceCode == id);
                List<InvoiceDetail> InvoiceDetail = repositoryWrapper.InvoiceDetail.FindByCondition(x => x.InvoiceRefid == id).ToList();
                if (Invoice == null || InvoiceDetail.Count < 0)
                {
                    return NotFound();
                }
                repositoryWrapper.InvoiceDetail.DeleteMany(InvoiceDetail);
                repositoryWrapper.Invoice.Delete(Invoice);
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

        [HttpGet("ConfirmInvoice/{id}")]
        public async Task<IActionResult> ConfirmInvoice(string id)
        {
            Response<string> result = new Response<string>();
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            try
            {
                Invoice Invoice = repositoryWrapper.Invoice.FinbyId(x => x.InvoiceCode == id);
                List<InvoiceDetail> InvoiceDetail = repositoryWrapper.InvoiceDetail.FindByCondition(x => x.InvoiceRefid == id).ToList();
               
                if (Invoice == null || InvoiceDetail.Count < 0)
                {
                    return NotFound();
                }
                //Update invoice
                Invoice.Status = 2;
                repositoryWrapper.Invoice.Update(Invoice);
                // Thêm mới bảng inventory
                var lstMedicine = InvoiceDetail.Select(x => x.CodeMedicine).ToList();
                List<Inventory> lstExit = repositoryWrapper.Inventory.FindByCondition(x => lstMedicine.Contains(x.CodeMedicine)).ToList();
                List<Inventory> lstInventory = new List<Inventory>();
                for (int i = 0; i < InvoiceDetail.Count; i++)
                {
                    Inventory ItemExit = lstExit.FirstOrDefault(x => x.CodeMedicine == InvoiceDetail[i].CodeMedicine
                                                                    && x.SeriNumber == InvoiceDetail[i].SeriNumber
                                                                    && x.SupCode == Invoice.SupCode
                                                                    && x.DateExpire.ToShortDateString() == InvoiceDetail[i].DateExpire.ToShortDateString()
                                                                    && x.DateMade.ToShortDateString() == InvoiceDetail[i].DateMade.ToShortDateString() 
                                                                    && x.AgentCode == InvoiceDetail[i].AgentCode); 
                                                                   
                    if (ItemExit == null)
                    {
                        InvoiceDetail[i].AgentCode = Invoice.AgentCode;
                        InvoiceDetail[i].Total = InvoiceDetail[i].Total;
                        Inventory item = new Inventory
                        {
                            status = 1,
                            InvoiceRefid = InvoiceDetail[i].InvoiceRefid,
                            CodeMedicine = InvoiceDetail[i].CodeMedicine,
                            NameMedice = InvoiceDetail[i].NameMedice,
                            Count = InvoiceDetail[i].Count,
                            Price = InvoiceDetail[i].Price,
                            SeriNumber = InvoiceDetail[i].SeriNumber,
                            DateMade = InvoiceDetail[i].DateMade,
                            DateExpire = InvoiceDetail[i].DateExpire,
                            DateBuy = DateTime.Now,
                            SupCode = Invoice.SupCode,
                            AgentCode = Invoice.AgentCode,
                        };
                        lstInventory.Add(item);
                    }
                    else
                    {
                        ItemExit.InvoiceRefid = ItemExit.InvoiceRefid + ";" + InvoiceDetail[i].InvoiceRefid;
                        ItemExit.Count = repositoryWrapper.Inventory.CaulatorExit(ItemExit.Count, InvoiceDetail[i].Count,repositoryWrapper.Medicine.FinbyId(x => x.CodeMedicine == ItemExit.CodeMedicine).ExChange);
                        repositoryWrapper.Inventory.Update(ItemExit);
                    }
                }
                repositoryWrapper.Inventory.CreateMany(lstInventory);
                //Update Suplier
                Supplier supplier = repositoryWrapper.Supplier.FinbyId(x => x.SupCode == Invoice.SupCode);
                supplier.Paid = (Int32.Parse(supplier.Paid.Replace(",", "")) + Int32.Parse(Invoice.Paid.Replace(",", ""))).ToString();
                supplier.Dept = Invoice.newDept.Replace(",", "");
                repositoryWrapper.Supplier.Update(supplier);
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
        [HttpGet("ConfirmInvoiceSell/{id}")]
        public async Task<IActionResult> ConfirmInvoiceSell(string id)
        {
            Response<string> result = new Response<string>();
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            try
            {
                Invoice Invoice = repositoryWrapper.Invoice.FinbyId(x => x.InvoiceCode == id);
                List<InvoiceDetail> InvoiceDetail = repositoryWrapper.InvoiceDetail.FindByCondition(x => x.InvoiceRefid == id).ToList();

                if (Invoice == null || InvoiceDetail.Count < 0)
                {
                    return NotFound();
                }
                //Update invoice
                Invoice.Status = 2;
                repositoryWrapper.Invoice.Update(Invoice);
                //Trừ trong Inventory   
                var user = (Permisssion)HttpContext.Items["UserAndPPermisssion"];
                var lstInventory = repositoryWrapper.Inventory.FindByCondition(x => InvoiceDetail.Select(y => y.CodeMedicine).Contains(x.CodeMedicine) && x.AgentCode == user.User.AgentCode).ToList();
                for (int i = 0; i < InvoiceDetail.Count; i++)
                {
                    Inventory inventory = lstInventory.FirstOrDefault(x => x.SeriNumber == InvoiceDetail[i].SeriNumber);
                    string ExChange = repositoryWrapper.Medicine.FinbyId(x => x.CodeMedicine == inventory.CodeMedicine).ExChange;
                    int CountInventory = repositoryWrapper.Inventory.GetMax(ExChange,inventory.Count);
                    int CountDetail = repositoryWrapper.Inventory.GetMax(ExChange, InvoiceDetail[i].Count);
                    int RemainInvory = CountInventory - CountDetail;
                    if(RemainInvory > 0)
                    {
                        inventory.Count = repositoryWrapper.Inventory.ConverMintoMax(ExChange, RemainInvory);
                        repositoryWrapper.Inventory.Update(inventory);
                    }
                }
                repositoryWrapper.save();
                result.message = "Cập nhật dữ liệu thành công";
            }
            catch (Exception exx)
            {
                result.message = exx.Message;
            }
            return Ok(result);
        }
    }
}