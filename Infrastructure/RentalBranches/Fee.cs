namespace Infrastructure.RentalBranches;

public record Fee(Guid Id, string Description, decimal Amount)
{
    public virtual RentalBranch RentalBranch { get; set; } = null!;
}