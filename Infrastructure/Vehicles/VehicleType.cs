using DomainVehicleType = Domain.Vehicles.VehicleType;

namespace Infrastructure.Vehicles;

public record VehicleType(Guid Id, DomainVehicleType Type);
