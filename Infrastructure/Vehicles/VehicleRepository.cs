using Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using DomainVehicle = Domain.Vehicles.Vehicle;

namespace Infrastructure.Vehicles;

public class VehicleRepository(CarRentalContext carRentalContext, VehicleMapper mapper) : IVehicleRepository
{
    public async Task<DomainVehicle?> CreateAsync(DomainVehicle vehicle)
    {
        var vehicleToSave = mapper.DomainVehicleToVehicle(vehicle);
        if (vehicleToSave is null) return null;
        await carRentalContext.Vehicles.AddAsync(vehicleToSave);
        var result = await carRentalContext.SaveChangesAsync();
        return result < 1 ? null : vehicle;
    }

    public async Task DeleteByIdAsync(Guid vehicleId)
    {
        carRentalContext.Vehicles.Remove((await carRentalContext.Vehicles.FindAsync(vehicleId))!);
        await carRentalContext.SaveChangesAsync();
    }

    public async Task<List<DomainVehicle>> GetAllAsync(int pageSize, int pageNumber)
    {
        return mapper.VehicleListToDomainVehicleList(await carRentalContext.Vehicles.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync());
    }

    public async Task<DomainVehicle?> GetByIdAsync(Guid vehicleId)
    {
        var obtainedVehicle = await carRentalContext.Vehicles.Where(vehicle => vehicle.Id.Equals(vehicleId)).FirstOrDefaultAsync();
        return mapper.VehicleToDomainVehicle(obtainedVehicle);
    }

    public async Task<DomainVehicle?> UpdateAsync(DomainVehicle vehicle)
    {
        var vehicleToUpdate = (await carRentalContext.Vehicles.FindAsync(vehicle.Id))!;
        mapper.MapFromDomainVehicle(vehicle, vehicleToUpdate);
        var updatedVehicle = carRentalContext.Vehicles.Update(vehicleToUpdate).Entity;
        var result = await carRentalContext.SaveChangesAsync();
        return result < 1 ? null : mapper.VehicleToDomainVehicle(updatedVehicle);
    }
}
