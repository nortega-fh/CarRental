namespace Domain.Vehicles;

public class Vehicle
{
    public Guid Id { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Capacity { get; set; }
    public double Mileage { get; set; }
    public decimal DailyPrice { get; set; }
    public VehicleType Type { get; set; }
}
