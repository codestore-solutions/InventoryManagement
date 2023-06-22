using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        private IBillRepository? _billRepository;
        private IBillTypeRepository? _billTypeRepository;
        private IBranchRepository? _branchRepository;
        private ICategoryRepository? _categoryRepository;
        private IGRNRepository? _grnRepository;
        private IOrderRepository? _orderRepository;
        private IProductRepository? _productRepository;
        private IPurchaseRepository? _purchaseRepository;
        private ISalesOrderLineRepository? _salesOrderLineRepository;
        private ISalesOrderRepository? _salesOrderRepository;
        private ISupplierRepository? _supplierRepository;
        private IWarehouseRepository? _warehouseRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IBillRepository BillRepository => _billRepository ??= new BillRepositoy(_appDbContext);
        public IBillTypeRepository BillTypeRepository => _billTypeRepository ??= new BillTypeRepository(_appDbContext);
        public IBranchRepository BranchRepository => _branchRepository ??= new BranchRepository(_appDbContext);
        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_appDbContext);
        public IGRNRepository GRNRepository => _grnRepository ??= new GRNRepository(_appDbContext);
        public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository(_appDbContext);
        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_appDbContext);
        public IPurchaseRepository PurchaseRepository => _purchaseRepository ??= new PurchaseRepository(_appDbContext);
        public ISalesOrderLineRepository SalesOrderLineRepository => _salesOrderLineRepository ??= new SalesOrderLineRepository(_appDbContext);
        public ISalesOrderRepository SalesOrderRepository => _salesOrderRepository ??= new SalesOrderRepository(_appDbContext);
        public ISupplierRepository SupplierRepository => _supplierRepository ??= new SupplierRepository(_appDbContext);
        public IWarehouseRepository WarehouseRepository => _warehouseRepository ??= new WarehouseRepository(_appDbContext);

        public void Dispose()
        {
            _appDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public async void SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}