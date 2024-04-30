using Infrastructure.Bookings;
using Infrastructure.RentalCompanies;
using Infrastructure.Vehicles;

namespace Infrastructure.RentalBranches;

public record RentalBranch(Guid Id, string Name, string State, string City, bool IsMain)
{
    public virtual RentalCompany RentalCompany { get; set; } = null!;
    public virtual List<Tax> Taxes { get; set; } = null!;
    public virtual List<Fee> Fees { get; set; } = null!;
    public virtual List<Vehicle> Vehicles { get; set; } = null!;
    public virtual List<Booking> Bookings { get; set; } = [];
}