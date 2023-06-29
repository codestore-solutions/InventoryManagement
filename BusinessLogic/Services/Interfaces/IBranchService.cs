using BusinessLogic.DTOs;
using Core.InventoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IBranchService
    {
        Task<ResponseDto> GetAll();
        Task<ResponseDto> Get(long id);
        Task<bool> Update(long id, Branch shipper);
        Task<ResponseDto> Add(Branch shipper);
        Task<bool> Delete(long id);
    }
}
