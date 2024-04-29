using Riok.Mapperly.Abstractions;
using DomainVehicle = Domain.Vehicles.Vehicle;
using DomainVehicleType = Domain.Vehicles.VehicleType;

namespace Infrastructure.Vehicles;

[Mapper]
public partial class VehicleMapper
{
    public partial Vehicle? DomainVehicleToVehicle(DomainVehicle? domainVehicle);
    public partial DomainVehicle? VehicleToDomainVehicle(Vehicle? vehicle);
    public partial void MapFromDomainVehicle(DomainVehicle domainVehicle, Vehicle vehicle);

    private DomainVehicleType MapVehicleTypeToDomainVehicleType(VehicleType vehicleType) => vehicleType.Type;
    private VehicleType MapDomainVehicleTypeToVehicleType(DomainVehicleType domainVehicleType) => new(default, domainVehicleType);
}
