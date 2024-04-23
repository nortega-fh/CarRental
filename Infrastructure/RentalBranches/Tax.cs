namespace Infrastructure.RentalBranches;

public record Tax(Guid Id, string Description, decimal Amount, RentalBranch RentalBranch);