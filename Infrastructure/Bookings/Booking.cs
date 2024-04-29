using Infrastructure.RentalBranches;
using Infrastructure.RentalCompanies;
using Infrastructure.Users;
using Infrastructure.Vehicles;

namespace Infrastructure.Bookings;

public record Booking(Guid Id, DateTime StartDate, DateTime EndDate)
{
    public virtual Vehicle Vehicle { get; set; } = null!;
    public virtual User User { get; set; } = null!;
    public virtual RentalCompany Company { get; set; } = null!;
    public virtual RentalBranch PickUpBranch { get; set; } = null!;
    public virtual RentalBranch DropOffBranch { get; set; } = null!;
}
