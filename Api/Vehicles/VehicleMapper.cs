using Contracts.Vehicles;
using Domain.Vehicles;
using Riok.Mapperly.Abstractions;

namespace Api.Vehicles;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
public partial class VehicleMapper
{
    public partial Vehicle MapRequestToVehicle(VehicleCreateReq vehicleReq);
}
