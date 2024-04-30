using Contracts.Vehicles;
using Domain.Vehicles;
using Riok.Mapperly.Abstractions;

namespace Api.Vehicles;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
public partial class VehicleMapper
{
    [MapperIgnoreTarget(nameof(Vehicle.Id))]
    public partial Vehicle ToVehicle(VehicleCreateReq vehicleReq);
    public partial VehicleResponse ToVehicleResponse(Vehicle vehicle);
    public partial List<VehicleResponse> ToVehicleResponseList(List<Vehicle> vehicles);
}
