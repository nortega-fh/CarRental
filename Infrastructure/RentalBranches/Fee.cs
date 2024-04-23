namespace Infrastructure.RentalBranches;

public record Fee(Guid Id, string Description, decimal Amount, RentalBranch RentalBranch);