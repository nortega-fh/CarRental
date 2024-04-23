using Infrastructure.RentalCompanies;
using Infrastructure.Vehicles;

namespace Infrastructure.RentalBranches;

public record RentalBranch(Guid Id, string Name, string State, string City, bool IsMain, RentalCompany RentalCompany, List<Tax> Taxes, List<Fee> Fees, List<Vehicle> Vehicles);