using Infrastructure.RentalBranches;

namespace Infrastructure.RentalCompanies;

public record RentalCompany(Guid Id, string Name)
{
    public virtual List<RentalBranch> Branches { get; set; } = null!;
}
