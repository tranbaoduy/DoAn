using Microsoft.Extensions.Options;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IRepositoryWrapper
    {
        IUserService User { get; }
        IFunctionService Function { get; }
        IPermissionService Permission { get; }
        IAgentService Agent { get; }
        IMedicineService Medicine { get; }
        ISupplierService Supplier { get; }
        IInvoiceService Invoice { get; }
        IInvoiceDetailService InvoiceDetail { get; }
        IInventoryService Inventory { get; }
        void save();
    }
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private MyContext _Context;
        private IUserService _User;
        private IFunctionService _Function;
        private IPermissionService _Permission;
        private IAgentService _Agent;
        private IMedicineService _Medicine;
        private ISupplierService _Supplier;
        private IInvoiceService _Invoice;
        private IInvoiceDetailService _InvoiceDetail;
        private IInventoryService _Inventory;
        private readonly IOptions<AppSettings> _appSettings;
        public RepositoryWrapper(MyContext context, IOptions<AppSettings> appSettings)
        {
            _Context = context;
            _appSettings = appSettings;
        }

        public IInventoryService Inventory
        {
            get
            {
                if (_Inventory == null)
                {
                    _Inventory = new InventoryService(_Context);
                }
                return _Inventory;
            }
        }

        public IInvoiceDetailService InvoiceDetail
        {
            get
            {
                if (_InvoiceDetail == null)
                {
                    _InvoiceDetail = new InvoiceDetailService(_Context);
                }
                return _InvoiceDetail;
            }
        }

        public IInvoiceService Invoice
        {
            get
            {
                if (_Invoice == null)
                {
                    _Invoice = new InvoiceService(_Context);
                }
                return _Invoice;
            }
        }

        public ISupplierService Supplier
        {
            get
            {
                if (_Supplier == null)
                {
                    _Supplier = new SupplierService( _Context);
                }
                return _Supplier;
            }
        }

        public IUserService User
        {
            get
            {
                if (_User == null)
                {
                    _User = new UserService(_appSettings, _Context);
                }
                return _User;
            }
        }

        public IFunctionService Function
        {
            get
            {
                if (_Function == null)
                {
                    _Function = new FunctionService(_Context);
                }
                return _Function;
            }
        }

        public IPermissionService Permission
        {
            get
            {
                if (_Permission == null)
                {
                    _Permission = new PermissionService( _Context);
                }
                return _Permission;
            }
        }

        public IAgentService Agent
        {
            get
            {
                if (_Agent == null)
                {
                    _Agent = new AgentService(_Context);
                }
                return _Agent;
            }
        }

        public IMedicineService Medicine
        {
            get
            {
                if (_Medicine == null)
                {
                    _Medicine = new MedicineService(_Context);
                }
                return _Medicine;
            }
        }

        public void save()
        {
            _Context.SaveChanges();
        }

    }
}
