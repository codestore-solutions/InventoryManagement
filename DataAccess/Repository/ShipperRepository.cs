﻿using Core.InventoryModels;
using DataAccess.Data;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ShipperRepository : GenericRepository<Shipper>, IShipperRepository
    {
        private readonly AppDbContext _appDbContext;
        public ShipperRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
