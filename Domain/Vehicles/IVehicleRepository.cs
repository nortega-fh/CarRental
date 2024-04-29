namespace Domain.Vehicles;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> GetAllAsync(int pageSize, int pageNumber);
    Task<Vehicle?> GetByIdAsync(Guid vehicleId);
    Task<Vehicle?> CreateAsync(Vehicle vehicle);
    Task<Vehicle?> UpdateAsync(Vehicle vehicle);
    Task DeleteByIdAsync(Guid vehicleId);
}
