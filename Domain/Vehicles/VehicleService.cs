namespace Domain.Vehicles;

public class VehicleService(IVehicleRepository vehicleRepository) : IVehicleService
{
    public async Task<Vehicle?> CreateAsync(Vehicle vehicle)
    {
        return await vehicleRepository.CreateAsync(vehicle);
    }

    public async Task DeleteAsync(Guid vehicleId)
    {
        await vehicleRepository.DeleteByIdAsync(vehicleId);
    }

    public async Task<IEnumerable<Vehicle>> GetAllAsync(int pageSize, int pageNumber)
    {
        return await vehicleRepository.GetAllAsync(pageSize, pageNumber);
    }

    public async Task<Vehicle?> GetByIdAsync(Guid vehicleId)
    {
        return await vehicleRepository.GetByIdAsync(vehicleId);
    }

    public async Task<Vehicle?> UpdateAsync(Vehicle vehicle)
    {
        return await vehicleRepository.UpdateAsync(vehicle);
    }
}
