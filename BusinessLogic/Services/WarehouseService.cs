using BusinessLogic.DTOs;
using BusinessLogic.Services.Interfaces;
using Core.InventoryModels;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto> Add(Warehouse warehouse)
        {
            _unitOfWork.WarehouseRepository.Add(warehouse);
            await _unitOfWork.SaveAsync();
            var response = ResponseDto<Created>.CreateSuccessResponse(StatusCodes.Status201Created, true, new Created(warehouse.Id));
            return response;
        }

        public async Task<bool> Delete(long id)
        {
            var warehouse = await _unitOfWork.WarehouseRepository.GetAsync(id);
            if (warehouse == null) { return false; }
            _unitOfWork.WarehouseRepository.Delete(warehouse);
            _unitOfWork.SaveAsync().Wait();
            return true;
        }

        public async Task<ResponseDto> Get(long id)
        {
            var warehouse = await _unitOfWork.WarehouseRepository.GetAsync(id);
            if (warehouse == null)
            {
                return ResponseDto.CreateErrorResponse(404, "No Shipper found for id " + id);
            }
            return ResponseDto<Warehouse>.CreateSuccessResponse(warehouse);
        }

        public async Task<ResponseDto> GetAll()
        {
            var warehouses = await _unitOfWork.WarehouseRepository.GetAllAsync();
            if (!warehouses.Any())
            {
                return ResponseDto.CreateErrorResponse(404, "No Shipper found");
            }
            return ResponseDto<IEnumerable<Warehouse>>.CreateSuccessResponse(warehouses);
        }

        public async Task<bool> Update(long id, Warehouse warehouse)
        {
            var existingWarehouse = await _unitOfWork.WarehouseRepository.GetAsync(id);
            if (existingWarehouse == null) { return false; }
            _unitOfWork.WarehouseRepository.Update(warehouse);
            _unitOfWork.Save();
            return true;
        }
    }
}
