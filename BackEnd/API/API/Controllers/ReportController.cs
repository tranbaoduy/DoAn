using API.Helper;
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
using static API.View.BaoCao;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        public ReportController(IRepositoryWrapper _repositoryWrapper)
        {
            repositoryWrapper = _repositoryWrapper;
        }

        [HttpPost("BCCongNo")]
        public async Task<IActionResult> BCCongNo(BaoCaoParameter pagePara)
        {
            Response<BaoCaoResponseCongNo> result = new Response<BaoCaoResponseCongNo>();
            if(pagePara == null)
            {
                return BadRequest();
            }    
            try
            {
                var user = (Permisssion)HttpContext.Items["UserAndPPermisssion"];
                List<BaoCaoResponseCongNoDetail> data = new List<BaoCaoResponseCongNoDetail>();
                if (user.User.AgentCode != 1)
                {
                    pagePara.FromDate = FunctionCommon.ResetTimeToStartOfDay(pagePara.FromDate);
                    pagePara.ToDate = FunctionCommon.ResetTimeToStartOfDay(pagePara.ToDate);
                    List<Invoice> lstInvoice = repositoryWrapper.Invoice.FindByCondition(x => x.TypeInvoice == pagePara.TypeReport && x.DateCreate >= pagePara.FromDate && x.DateCreate <= pagePara.ToDate && x.AgentCode == user.User.AgentCode).ToList();
                    List<Supplier> lstSup = repositoryWrapper.Supplier.FindByCondition(x => lstInvoice.Select(y => y.SupCode).Contains(x.SupCode)).ToList();
                    var dataInvoice = (from Invoice in lstInvoice
                                      group Invoice by Invoice.SupCode into InvoiceTotal
                                      select new
                                      {
                                          SupCode = InvoiceTotal.Key,
                                          TotalInvoice = InvoiceTotal.Sum(x => int.Parse(x.TotalInvoice)),
                                          TotalPaid = InvoiceTotal.Sum(x => int.Parse(x.Paid)),
                                      }).ToList();
                    for (int i = 0; i < dataInvoice.Count; i++)
                    {
                        BaoCaoResponseCongNoDetail item = new BaoCaoResponseCongNoDetail
                        {
                            NameSup = lstSup.FirstOrDefault(x => x.SupCode == dataInvoice[i].SupCode).SupName,
                            TotalInvoice = dataInvoice[i].TotalInvoice.ToString(),
                            Paid = dataInvoice[i].TotalPaid.ToString(),
                            Dept = (dataInvoice[i].TotalInvoice - dataInvoice[i].TotalPaid).ToString()
                        };
                        data.Add(item);
                    }
                    BaoCaoResponseCongNo resultData = new BaoCaoResponseCongNo
                    {
                        Total = dataInvoice.Sum(x => x.TotalInvoice).ToString(),
                        TotalPaid = dataInvoice.Sum(x => x.TotalPaid).ToString(),
                        TotalDept = dataInvoice.Sum(x => (x.TotalInvoice - x.TotalPaid)).ToString(),
                        lst = data
                    };
                    result.data = resultData;
                    result.message = "Lấy dữ liệu thành công";
                }
            }
            catch(Exception ex)
            {
                result.message = ex.Message;
            }
            return Ok(result);
        }

        [HttpPost("BCTHUCHI")]
        public async Task<IActionResult> BCTHUCHI(BaoCaoParameter pagePara)
        {
            Response<BaocaoThuChiResponse> result = new Response<BaocaoThuChiResponse>();
            if (pagePara == null)
            {
                return BadRequest();
            }
            try
            {
                var user = (Permisssion)HttpContext.Items["UserAndPPermisssion"];
                List<BaocaoThuChiResponseDetail> data = new List<BaocaoThuChiResponseDetail>();
                if (user.User.AgentCode != 1)
                {
                    pagePara.FromDate = FunctionCommon.ResetTimeToStartOfDay(pagePara.FromDate);
                    pagePara.ToDate = FunctionCommon.ResetTimeToStartOfDay(pagePara.ToDate);
                    List<Invoice> lstInvoice = repositoryWrapper.Invoice.FindByCondition(x => x.TypeInvoice == pagePara.TypeReport && x.DateCreate >= pagePara.FromDate && x.DateCreate <= pagePara.ToDate && x.AgentCode == user.User.AgentCode).ToList();
                    for (int i = 0; i < lstInvoice.Count; i++)
                    {
                        BaocaoThuChiResponseDetail item = new BaocaoThuChiResponseDetail
                        {
                            NameCus = lstInvoice[i].NameCus,
                            DateCreate = lstInvoice[i].DateCreate.ToShortDateString(),
                            TotalInvoice = lstInvoice[i].TotalInvoice,
                        };
                        data.Add(item);
                    }
                    BaocaoThuChiResponse resultData = new BaocaoThuChiResponse
                    {
                        Total = lstInvoice.Sum(x => int.Parse(x.TotalInvoice)).ToString(),
                        lst = data
                    };
                    result.data = resultData;
                    result.message = "Lấy dữ liệu thành công";
                }
            }
            catch(Exception ex)
            {
                result.message = ex.Message;
            }
            return Ok(result);
        }

        [HttpGet("Dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            Response<Dashboard> result = new Response<Dashboard>();
            try
            {
                string Now = DateTime.Now.ToShortDateString();
                var user = (Permisssion)HttpContext.Items["UserAndPPermisssion"];
                List<Invoice> invoices = repositoryWrapper.Invoice.FindByCondition(x => x.AgentCode == user.User.AgentCode && x.DateCreate.Date == DateTime.Now.Date).ToList();
                List<Inventory> inventories = repositoryWrapper.Inventory.FindByCondition(x => x.AgentCode == user.User.AgentCode).ToList();
                Dashboard resultDashboard = new Dashboard()
                {
                    HDN = invoices.Where(x => x.TypeInvoice == 1).Count().ToString(),
                    TotalHDN = invoices.Where(x => x.TypeInvoice == 1).Sum(x => int.Parse(x.TotalInvoice)).ToString(),
                    HDX = invoices.Where(x => x.TypeInvoice == 2).Count().ToString(),
                    TotalHDX = invoices.Where(x => x.TypeInvoice == 2).Sum(x => int.Parse(x.TotalInvoice)).ToString(),
                    DoanhThu = (invoices.Where(x => x.TypeInvoice == 1).Sum(x => int.Parse(x.TotalInvoice)) - invoices.Where(x => x.TypeInvoice == 2).Sum(x => int.Parse(x.TotalInvoice))).ToString(),
                    TongSoThuoc = inventories.Count().ToString(),
                    ThuocHetHan = inventories.Where(x => x.DateExpire.Year == DateTime.Now.Year && (DateTime.Now.Month - x.DateExpire.Month) <= 1).Count().ToString(),
                    ThuocSapHetHang = "0"
                };
                result.data = resultDashboard;
                result.message = "Lấy dữ liệu thành công";
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Ok(result);
        }

    }
}
