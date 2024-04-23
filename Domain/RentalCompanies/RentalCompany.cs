namespace Domain.RentalCompanies;

public class RentalCompany
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<RentalBranch> Branches { get; set; } = [];
}
