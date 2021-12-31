using Model;
using Model.Model;
using Service.Base;
using Service.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IInventoryService : IBaseService<Inventory>
    {
        PageModel<ModelInventory.ViewIndex> PagingAbc(PageParameter pagePara, Expression<Func<Inventory, bool>> expression);
        string CaulatorExit(string CountExit, string newCount,string Exchange);
        int GetMax(string ExChange, string Count);
        string ConverMintoMax(string ExChange, int count);
    }
    public class InventoryService : BaseService<Inventory>, IInventoryService
    {
        public InventoryService(MyContext myContext) : base(myContext)
        {

        }


        public PageModel<ModelInventory.ViewIndex> PagingAbc(PageParameter pagePara, Expression<Func<Inventory, bool>> expression)
        {
            var result = new PageModel<ModelInventory.ViewIndex>();
            var AllMedicine = base.context.Inventorys.Where(expression).ToList();
            var lstMedice = base.context.Medicines.ToList();
            var lstSup = base.context.Suppliers.ToList();
            var Medicine = AllMedicine.Select(x => new { CodeMedicine = x.CodeMedicine, NameMedicene = x.NameMedice }).Distinct().ToList();
            
            List<ModelInventory.ViewIndex> lstView = new List<ModelInventory.ViewIndex>();
            for (int i = 0; i < Medicine.Count; i++)
            {
                List<ModelInventory.DetailMedicine> lst = new List<ModelInventory.DetailMedicine>();
                var lstDetail = AllMedicine.Where(x => x.CodeMedicine == Medicine[i].CodeMedicine)
                    .Select(x => new
                    {
                        InvoiceCode = x.InvoiceRefid,
                        TotalCount = x.Count,
                        Expire = x.DateExpire.ToString("dd/MM/yyyy") + "-" + x.DateMade.ToString("dd/MM/yyyy"),
                        NameSupplier = lstSup.FirstOrDefault(y => y.SupCode == x.SupCode).SupName,
                        Price = x.Price,
                        PriceSell = x.PriceSell,
                        ExChange = lstMedice.FirstOrDefault(x => x.CodeMedicine == Medicine[i].CodeMedicine).ExChange
                    })
                    .ToList();
                for (int j = 0; j < lstDetail.Count; j++)
                {
                    ModelInventory.DetailMedicine itemDetail = new ModelInventory.DetailMedicine()
                    {
                        InvoiceCode = lstDetail[j].InvoiceCode,
                        Count = lstDetail[j].TotalCount,
                        Expire = lstDetail[j].Expire,
                        Supplier = lstDetail[j].NameSupplier,
                        Price = lstDetail[j].Price,
                        PriceSell = lstDetail[j].PriceSell,
                        ExChange = lstDetail[j].ExChange
                    };
                    lst.Add(itemDetail);
                }
                ModelInventory.ViewIndex newItem = new ModelInventory.ViewIndex()
                {
                    MedicineCode = Medicine[i].CodeMedicine,
                    MedicineName = Medicine[i].NameMedicene,
                    TotalCount = CaculatorTotalCount(lst.Select(x => x.Count).ToList(), base.context.Medicines.FirstOrDefault(x => x.CodeMedicine == Medicine[i].CodeMedicine).ExChange),
                    lstDetail = lst
                };
                lstView.Add(newItem);
            }
            result.data = lstView.Skip(pagePara.PageSize * pagePara.Page - pagePara.PageSize).Take(pagePara.PageSize).ToList();
            result.cout = lstView.Count();
            result.TotalPage = result.cout % pagePara.PageSize == 0 ? result.cout / pagePara.PageSize : result.cout / pagePara.PageSize + 1;
            return result;
        }

        public string CaculatorTotalCount(List<string> lst,string ExChange)
        {
            var totalCount = "";
            IDictionary<string, int> lstUnit  = new Dictionary<string, int>();
            var lstExchange = ExChange.Split(",");
            for (int i = 0; i < lstExchange.Length;i++)
            {
                var unit = lstExchange[i].Split(" ");
                if(unit.Length == 1)
                {
                    lstUnit.Add(unit[0], 0);
                }
                else
                {
                    lstUnit.Add(unit[1], 0);
                }
            }    
            for(int i = 0; i < lst.Count;i++)
            {
                var lstitem = lst[i].Split(",");
                for(int j = 0; j < lstitem.Length; j++)
                {
                    var item = lstitem[j].Split(" ");
                    if (lstUnit.ContainsKey(item[1]))
                    {
                        lstUnit[item[1]] = lstUnit[item[1]] + Int32.Parse(item[0]);
                    }
                }
            }
            foreach (var item in lstUnit)
            {
                if (item.Value > 0)
                {
                    totalCount = totalCount + item.Value + " " + item.Key + ",";
                }
            }    
            return totalCount.Substring(0,totalCount.Length -1);
        }

        public string CaulatorExit (string CountExit, string newCount, string ExChange)
        {
            var totalCount = "";
            IDictionary<string, int> lstUnit = new Dictionary<string, int>();
            var lstExchange = ExChange.Split(",");
            for (int i = 0; i < lstExchange.Length; i++)
            {
                var unit = lstExchange[i].Split(" ");
                if (unit.Length == 1)
                {
                    lstUnit.Add(unit[0], 0);
                }
                else
                {
                    lstUnit.Add(unit[1], 0);
                }
            }
            var lstCountExit = CountExit.Split(",").ToList();
            for (int i = 0; i < lstCountExit.Count; i++)
            {
                var Exit = lstCountExit[i].Split(" ");
                if (lstUnit.ContainsKey(Exit[1]))
                {
                    lstUnit[Exit[1]] = lstUnit[Exit[1]] + Int32.Parse(Exit[0]);
                }
            }
            var lstNewCount = newCount.Split(",").ToList();
            for (int i = 0; i < lstNewCount.Count; i++)
            {
                var New = lstNewCount[i].Split(" ");
                if (lstUnit.ContainsKey(New[1]))
                {
                    lstUnit[New[1]] = lstUnit[New[1]] + Int32.Parse(New[0]);
                }
            }
            foreach (var item in lstUnit)
            {
                if(item.Value > 0)
                {
                    totalCount = totalCount + item.Value + " " + item.Key + ",";
                }
                
            }
            return totalCount.Substring(0, totalCount.Length - 1);
        }

        public class ItemExChange
        {
            public string Unit { get; set; }
            public int Value { get; set; }
        }

        public int GetMax(string ExChange,string Count)
        {
            int Max = 0;
            List<ItemExChange> lstUnit = new List<ItemExChange>();
            var lstExChange = ExChange.Split(",");
            for (int i = 0; i < lstExChange.Length;i++)
            {
                var Unit = lstExChange[i].Split(" ");
                if(Unit.Length == 1) {
                    ItemExChange item = new ItemExChange()
                    {
                        Unit = Unit[0],
                        Value = 1
                    };
                    lstUnit.Add(item);
                }
                else
                {
                    ItemExChange item = new ItemExChange()
                    {
                        Unit = Unit[1],
                        Value = int.Parse(Unit[0]),
                    };
                    lstUnit.Add(item);
                }
            }
            var lstCount = Count.Split(",");
            for(int i = 0; i < lstCount.Length;i++)
            {
                var item = lstCount[i].Split(" ");
                if(int.Parse(item[0]) > 0)
                {
                    Max = Max + ConverMaxToMin(lstUnit, item[0], item[1]);
                }    
            }
            return Max;
        }

        public int ConverMaxToMin(List<ItemExChange> lstUnit, string Count,string Name)
        {
            int Min = int.Parse(Count);
            for (int i = 0; i < lstUnit.Count;i++)
            {
                if(Name == lstUnit[i].Unit)
                {
                    for(int j = i + 1; j < lstUnit.Count; j++)
                    {
                        Min = Min * lstUnit[j].Value;
                    }
                }
            }
            return Min;
        }

        public string ConverMintoMax(string ExChange, int count)
        {
            string Max = "";
            List<ItemExChange> lstUnit = new List<ItemExChange>();
            var lstExChange = ExChange.Split(",");
            for (int i = 0; i < lstExChange.Length; i++)
            {
                var Unit = lstExChange[i].Split(" ");
                if (Unit.Length == 1)
                {
                    ItemExChange item = new ItemExChange()
                    {
                        Unit = Unit[0],
                        Value = 1
                    };
                    lstUnit.Add(item);
                }
                else
                {
                    ItemExChange item = new ItemExChange()
                    {
                        Unit = Unit[1],
                        Value = int.Parse(Unit[0]),
                    };
                    lstUnit.Add(item);
                }
            }
            List<ItemExChange> lstCount = new List<ItemExChange>();
            for(int i = lstUnit.Count - 1; i >= 0; i--)
            {
                int nguyen = count / lstUnit[i].Value;
                int du = count % lstUnit[i].Value;
                if(du > 0 && i > 0)
                {
                    ItemExChange newItem = new ItemExChange()
                    {
                        Unit = lstUnit[i].Unit,
                        Value = du
                    };
                    lstCount.Add(newItem);  
                }
                if(i == 0)
                {
                    ItemExChange newItem = new ItemExChange()
                    {
                        Unit = lstUnit[i].Unit,
                        Value = nguyen
                    };
                    lstCount.Add(newItem);
                }    
                count = nguyen;
            }    
            for(int i = lstCount.Count - 1; i >= 0; i--)
            {
                Max = Max + lstCount[i].Value + " " + lstCount[i].Unit + ",";
            }
            return Max.Substring(0,Max.Length - 1);
        }
    }
}
