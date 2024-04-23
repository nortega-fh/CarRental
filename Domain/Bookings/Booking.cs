using Domain.RentalCompanies;
using Domain.Users;
using Domain.Vehicles;

namespace Domain.Bookings;

public class Booking
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
    public User User { get; set; } = null!;
    public RentalCompany Company { get; set; } = null!;
    public RentalBranch PickUpBranch { get; set; } = null!;
    public RentalBranch DropOffBranch { get; set; } = null!;

    public decimal BasePrice() => (EndDate - StartDate).Days * Vehicle.DailyPrice;

    public decimal TotalPrice() => BasePrice() + PickUpBranch.TotalTaxes() + PickUpBranch.TotalFees();
}
