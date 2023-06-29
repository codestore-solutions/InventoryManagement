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
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperService;

        public ShipperController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<ResponseDto>> GetAll()
        {
            var response = await _shipperService.GetAll();
            if(!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("get/{id:long}")]
        public async Task<ActionResult<ResponseDto>> Get(long id)
        {
            var response = await _shipperService.Get(id);
            if(!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ResponseDto>> Add(Shipper shipper)
        {
            var response = await _shipperService.Add(shipper);
            return Created("Shipper Created Success", response);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(long id, Shipper shipper)
        {
            if(id != shipper.Id)
            {
                return BadRequest("Param and Shipper id does not match");
            }
            var res = await _shipperService.Update(id, shipper);
            if (!res)
            {
                return NotFound("No shipper available with the id " + id);
            }
            return Ok("Updated Successfully");
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var res = await _shipperService.Delete(id);
            if (!res)
            {
                return NotFound("No Shipper exist with id " + id);
            }
            return Ok("Shipper Deleted Successfully");
        }
    }
}
