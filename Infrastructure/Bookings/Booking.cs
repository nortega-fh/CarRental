using Infrastructure.RentalBranches;
using Infrastructure.RentalCompanies;
using Infrastructure.Users;
using Infrastructure.Vehicles;

namespace Infrastructure.Bookings;

public record Booking(Guid Id, DateTime StartDate, DateTime EndDate, Vehicle Vehicle, User User, RentalCompany Company, RentalBranch PickUpBranch, RentalBranch DropOffBranch);
