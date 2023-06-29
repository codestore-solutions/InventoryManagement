using BusinessLogic.DTOs;
using Core.InventoryModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IShipperService
    {
        Task<ResponseDto> GetAll();
        Task<ResponseDto> Get(long id);
        Task<bool> Update(long id,Shipper shipper);
        Task<ResponseDto> Add(Shipper shipper);
        Task<bool> Delete(long id);
    }
}
