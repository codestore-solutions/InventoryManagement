using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBillRepository BillRepository { get; }
        IBillTypeRepository BillTypeRepository { get; }
        IBranchRepository BranchRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IGRNRepository GRNRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IPurchaseRepository PurchaseRepository { get; }
        ISalesOrderLineRepository SalesOrderLineRepository { get; }
        ISalesOrderRepository SalesOrderRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IWarehouseRepository WarehouseRepository { get; }

        void Save();
        void SaveAsync();
    }
}
