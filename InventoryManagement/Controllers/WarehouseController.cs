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
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<ResponseDto>> GetAll()
        {
            var response = await _warehouseService.GetAll();
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("get/{id:long}")]
        public async Task<ActionResult<ResponseDto>> Get(long id)
        {
            var response = await _warehouseService.Get(id);
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ResponseDto>> Add(Warehouse warehouse)
        {
            var response = await _warehouseService.Add(warehouse);
            return Created("Warehouse Created Success", response);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(long id, Warehouse warehouse)
        {
            if (id != warehouse.Id)
            {
                return BadRequest("Param and Warehouse id does not match");
            }
            var res = await _warehouseService.Update(id, warehouse);
            if (!res)
            {
                return NotFound("No Warehouse available with the id " + id);
            }
            return Ok("Updated Successfully");
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var res = await _warehouseService.Delete(id);
            if (!res)
            {
                return NotFound("No Warehouse exist with id " + id);
            }
            return Ok("Warehouse Deleted Successfully");
        }
    }
}
