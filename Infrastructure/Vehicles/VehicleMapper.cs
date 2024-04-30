using Riok.Mapperly.Abstractions;
using DomainVehicle = Domain.Vehicles.Vehicle;

namespace Infrastructure.Vehicles;

[Mapper]
public partial class VehicleMapper
{
    public partial Vehicle? ToDomainVehicle(DomainVehicle? domainVehicle);
    public partial DomainVehicle? ToEntityVehicle(Vehicle? vehicle);
    public partial List<DomainVehicle> ToDomainVehicleList(List<Vehicle> vehicle);
    public partial void ToEntityVehicle(DomainVehicle domainVehicle, Vehicle vehicle);
}
