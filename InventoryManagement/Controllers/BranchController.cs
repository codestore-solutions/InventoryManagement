using BusinessLogic.DTOs;
using BusinessLogic.Services.Interfaces;
using Core.InventoryModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<ResponseDto>> GetAll()
        {
            var response = await _branchService.GetAll();
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("get/{id:long}")]
        public async Task<ActionResult<ResponseDto>> Get(long id)
        {
            var response = await _branchService.Get(id);
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("addShipper")]
        public async Task<ActionResult<ResponseDto>> Add(Branch branch)
        {
            var response = await _branchService.Add(branch);
            return Created("Branch Created Successfully", response);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(long id, Branch branch)
        {
            if (id != branch.Id)
            {
                return BadRequest("Param and Branch id does not match");
            }
            var res = await _branchService.Update(id, branch);
            if (!res)
            {
                return NotFound("No Branch available with the id " + id);
            }
            return Ok("Updated Successfully");
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var res = await _branchService.Delete(id);
            if (!res)
            {
                return NotFound("No Branch exist with id " + id);
            }
            return Ok("Branch Deleted Successfully");
        }
    }
}
