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
    public class ShipperService : IShipperService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShipperService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto> Add(Shipper shipper)
        {
            _unitOfWork.ShipperRepository.Add(shipper);
            await _unitOfWork.SaveAsync();
            var response = ResponseDto<Created>.CreateSuccessResponse(StatusCodes.Status201Created, true, new Created(shipper.Id));
            return response;
        }

        public async Task<bool> Delete(long id)
        {
            var shipper = await _unitOfWork.SupplierRepository.GetAsync(id);
            if(shipper == null) { return false; }
            _unitOfWork.SupplierRepository.Delete(shipper);
            _unitOfWork.SaveAsync().Wait();
            return true;
        }

        public async Task<ResponseDto> Get(long id)
        {
            var shipper = await _unitOfWork.ShipperRepository.GetAsync(id);
            if(shipper == null)
            {
                return ResponseDto.CreateErrorResponse(404, "No Shipper found for id " + id);
            }
            return ResponseDto<Shipper>.CreateSuccessResponse(shipper);
        }

        public async Task<ResponseDto> GetAll()
        {
            var shippers = await _unitOfWork.ShipperRepository.GetAllAsync();
            if(!shippers.Any())
            {
                return ResponseDto.CreateErrorResponse(404, "No Shipper found");
            }
            return ResponseDto<IEnumerable<Shipper>>.CreateSuccessResponse(shippers);
        }

        public async Task<bool> Update(long id, Shipper shipper)
        {
            var existingShipper = await _unitOfWork.ShipperRepository.GetAsync(id);
            if(existingShipper == null) { return false; }
            _unitOfWork.ShipperRepository.Update(shipper);
            _unitOfWork.Save();
            return true;
        }
    }
}
