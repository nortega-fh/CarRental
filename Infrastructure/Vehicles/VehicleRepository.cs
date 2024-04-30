using Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using DomainVehicle = Domain.Vehicles.Vehicle;

namespace Infrastructure.Vehicles;

public class VehicleRepository(CarRentalContext carRentalContext, VehicleMapper mapper) : IVehicleRepository
{
    public async Task<DomainVehicle?> CreateAsync(DomainVehicle vehicle)
    {
        var vehicleToSave = mapper.ToDomainVehicle(vehicle);
        if (vehicleToSave is null) return null;
        var createdVehicle = (await carRentalContext.Vehicles.AddAsync(vehicleToSave)).Entity;
        var result = await carRentalContext.SaveChangesAsync();
        return result < 1 ? null : mapper.ToEntityVehicle(createdVehicle);
    }

    public async Task DeleteByIdAsync(Guid vehicleId)
    {
        carRentalContext.Vehicles.Remove((await carRentalContext.Vehicles.FindAsync(vehicleId))!);
        await carRentalContext.SaveChangesAsync();
    }

    public async Task<List<DomainVehicle>> GetAllAsync(int pageSize, int pageNumber)
    {
        return mapper.ToDomainVehicleList(await carRentalContext.Vehicles.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync());
    }

    public async Task<DomainVehicle?> GetByIdAsync(Guid vehicleId)
    {
        var obtainedVehicle = await carRentalContext.Vehicles.FindAsync(vehicleId);
        return mapper.ToEntityVehicle(obtainedVehicle);
    }

    public async Task<DomainVehicle?> UpdateAsync(DomainVehicle vehicle)
    {
        var vehicleToUpdate = (await carRentalContext.Vehicles.FindAsync(vehicle.Id))!;
        mapper.ToEntityVehicle(vehicle, vehicleToUpdate);
        var updatedVehicle = carRentalContext.Vehicles.Update(vehicleToUpdate).Entity;
        var result = await carRentalContext.SaveChangesAsync();
        return result < 1 ? null : mapper.ToEntityVehicle(updatedVehicle);
    }
}
