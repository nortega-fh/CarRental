using Infrastructure.Bookings;

namespace Infrastructure.Users;
public record User(
        Guid Id,
        string Email,
        string Password,
        string FirstName,
        string LastName,
        string PhoneNumber,
        DateOnly DateOfBirth,
        string DriversLicenseNumber,
        string AddressLine1,
        string? AddressLine2,
        string City)
{
    public virtual UserRole Role { get; set; } = null!;
    public virtual List<Booking> Bookings { get; set; } = [];
}
