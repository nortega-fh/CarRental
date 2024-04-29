namespace Infrastructure.Vehicles;

public record Vehicle(
    Guid Id,
    string Make,
    string Model,
    int Year,
    int Capacity,
    double Mileage,
    decimal DailyPrice)
{

    public virtual VehicleType Type { get; set; } = null!;
}
