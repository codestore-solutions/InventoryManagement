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
    public class BranchService : IBranchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BranchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto> Add(Branch branch)
        {
            _unitOfWork.BranchRepository.Add(branch);
            await _unitOfWork.SaveAsync();
            var response = ResponseDto<Created>.CreateSuccessResponse(StatusCodes.Status201Created, true, new Created(branch.Id));
            return response;
        }

        public async Task<bool> Delete(long id)
        {
            var branch = await _unitOfWork.BranchRepository.GetAsync(id);
            if (branch == null) { return false; }
            _unitOfWork.BranchRepository.Delete(branch);
            _unitOfWork.SaveAsync().Wait();
            return true;
        }

        public async Task<ResponseDto> Get(long id)
        {
            var branch = await _unitOfWork.BranchRepository.GetAsync(id);
            if (branch == null)
            {
                return ResponseDto.CreateErrorResponse(404, "No branch found for id " + id);
            }
            return ResponseDto<Branch>.CreateSuccessResponse(branch);
        }

        public async Task<ResponseDto> GetAll()
        {
            var branches = await _unitOfWork.BranchRepository.GetAllAsync();
            if (!branches.Any())
            {
                return ResponseDto.CreateErrorResponse(404, "No branch found");
            }
            return ResponseDto<IEnumerable<Branch>>.CreateSuccessResponse(branches);
        }

        public async Task<bool> Update(long id, Branch branch)
        {
            var existingBranch = await _unitOfWork.BranchRepository.GetAsync(id);
            if (existingBranch == null) { return false; }
            _unitOfWork.BranchRepository.Update(branch);
            _unitOfWork.Save();
            return true;
        }
    }
}
