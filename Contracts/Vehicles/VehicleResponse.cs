namespace Contracts.Vehicles;

public record VehicleResponse(Guid Id, string Make, string Model, int Year, int Capacity, double Mileage, decimal DailyPrice, string Type);
