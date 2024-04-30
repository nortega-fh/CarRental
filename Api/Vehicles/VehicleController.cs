using Contracts.Vehicles;
using Domain.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Api.Vehicles;

[ApiController]
[Route("api/vehicles")]
public class VehicleController(IVehicleService vehicleService, VehicleMapper mapper, VehicleValidator validator) : ControllerBase
{
    private const int DefaultPageSize = 10;
    private const int DefaultPageNumber = 1;

    [HttpGet]
    public async Task<IActionResult> GetAllVehicles([FromQuery] int pageSize = DefaultPageSize, [FromQuery] int pageNumber = DefaultPageNumber)
    {
        return Ok(mapper.ToVehicleResponseList(await vehicleService.GetAllAsync(pageSize, pageNumber)));
    }

    [HttpGet("{vehicleId}")]
    public async Task<IActionResult> GetVehicleById([FromRoute] Guid vehicleId)
    {
        var vehicle = await vehicleService.GetByIdAsync(vehicleId);
        return vehicle is null ? NotFound() : Ok(mapper.ToVehicleResponse(vehicle));
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] VehicleCreateReq vehicleCreateReq)
    {
        var isValidResult = validator.Validate(vehicleCreateReq);
        if (!isValidResult.IsValid)
            return BadRequest(isValidResult.Errors);
        var createdVehicle = await vehicleService.CreateAsync(mapper.ToVehicle(vehicleCreateReq));
        return createdVehicle is null ? UnprocessableEntity() : Created(Request.Path, mapper.ToVehicleResponse(createdVehicle));
    }

    [HttpPut("{vehicleId}")]
    public async Task<IActionResult> UpdateVehicle([FromRoute] Guid vehicleId, [FromBody] VehicleCreateReq vehicleCreateReq)
    {
        var updatedVehicle = mapper.ToVehicle(vehicleCreateReq);
        updatedVehicle.Id = vehicleId;
        var vehicleUpdated = await vehicleService.UpdateAsync(updatedVehicle);
        return vehicleUpdated is null ? UnprocessableEntity() : Ok(mapper.ToVehicleResponse(vehicleUpdated));
    }

    [HttpDelete("{vehicleId}")]
    public async Task<IActionResult> DeleteVehicle([FromRoute] Guid vehicleId)
    {
        await vehicleService.DeleteAsync(vehicleId);
        return NoContent();
    }
}
