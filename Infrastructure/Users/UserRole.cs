using DomainUserRole = Domain.Users.UserRole;
namespace Infrastructure.Users;

public record UserRole(Guid Id, DomainUserRole Role);
