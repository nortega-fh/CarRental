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
        return Ok(await vehicleService.GetAllAsync(pageSize, pageNumber));
    }

    [HttpGet("{vehicleId}")]
    public async Task<IActionResult> GetVehicleById([FromRoute] Guid vehicleId)
    {
        return Ok(await vehicleService.GetByIdAsync(vehicleId));
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] VehicleCreateReq vehicleCreateReq)
    {
        var isValidResult = validator.Validate(vehicleCreateReq);
        if (!isValidResult.IsValid)
            return BadRequest(isValidResult.Errors);
        var createdVehicle = await vehicleService.CreateAsync(mapper.MapRequestToVehicle(vehicleCreateReq));
        return createdVehicle is null ? UnprocessableEntity() : Created(Request.Path, createdVehicle);
    }

    [HttpPut("{vehicleId}")]
    public async Task<IActionResult> UpdateVehicle([FromRoute] Guid vehicleId, [FromBody] VehicleCreateReq vehicleCreateReq)
    {
        var updatedVehicle = mapper.MapRequestToVehicle(vehicleCreateReq);
        updatedVehicle.Id = vehicleId;
        var vehicleUpdated = await vehicleService.UpdateAsync(updatedVehicle);
        return vehicleUpdated is null ? UnprocessableEntity() : Ok(vehicleUpdated);
    }

    [HttpDelete("{vehicleId}")]
    public async Task<IActionResult> DeleteVehicle([FromRoute] Guid vehicleId)
    {
        await vehicleService.DeleteAsync(vehicleId);
        return NoContent();
    }
}
