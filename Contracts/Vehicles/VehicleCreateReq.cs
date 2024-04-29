namespace Contracts.Vehicles;

public record VehicleCreateReq(string Make, string Model, int Year, int Capacity, double Mileage, decimal DailyPrice, string Type);
