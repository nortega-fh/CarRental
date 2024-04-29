using Contracts.Vehicles;
using Domain.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Api.Vehicles;

[ApiController]
[Route("/api/vehicles")]
public class VehicleController(IVehicleService vehicleService, VehicleMapper mapper) : ControllerBase
{
    private const int DefaultPageSize = 10;
    private const int DefaultPageNumber = 1;

    [HttpGet]
    public async Task<IActionResult> GetAllVehicles([FromQuery] int pageSize = DefaultPageSize, [FromQuery] int pageNumber = DefaultPageNumber)
    {
        return Ok(await vehicleService.GetAllAsync(pageSize, pageNumber));
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] VehicleCreateReq vehicleCreateReq)
    {
        var createdVehicle = await vehicleService.CreateAsync(mapper.MapRequestToVehicle(vehicleCreateReq));
        return createdVehicle is null ? UnprocessableEntity() : Created(Request.Path, createdVehicle);
    }
}
