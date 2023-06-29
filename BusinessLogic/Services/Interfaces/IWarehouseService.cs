using BusinessLogic.DTOs;
using Core.InventoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IWarehouseService
    {
        Task<ResponseDto> GetAll();
        Task<ResponseDto> Get(long id);
        Task<bool> Update(long id, Warehouse shipper);
        Task<ResponseDto> Add(Warehouse shipper);
        Task<bool> Delete(long id);
    }
}
