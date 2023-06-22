using DataAccess.Data;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class WarehouseRepository : GenericRepository<WarehouseRepository>, IWarehouseRepository
    {
        private readonly AppDbContext _appDbContext;
        public WarehouseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
