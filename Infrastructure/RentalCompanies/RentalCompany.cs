using Infrastructure.RentalBranches;

namespace Infrastructure.RentalCompanies;

public record RentalCompany(Guid Id, string Name, List<RentalBranch> Branches);
