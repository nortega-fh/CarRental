namespace Infrastructure.RentalBranches;

public record Tax(Guid Id, string Description, decimal Amount)
{
    public virtual RentalBranch RentalBranch { get; set; } = null!;
}