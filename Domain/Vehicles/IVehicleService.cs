namespace Domain.Vehicles;

public interface IVehicleService
{
    Task<IEnumerable<Vehicle>> GetAllAsync(int pageSize, int pageNumber);
    Task<Vehicle?> GetByIdAsync(Guid vehicleId);
    Task<Vehicle?> CreateAsync(Vehicle vehicle);
    Task<Vehicle?> UpdateAsync(Vehicle vehicle);
    Task DeleteAsync(Guid vehicleId);
}
