namespace Infrastructure.Users;

using Bookings;

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
        string City,
        UserRole Role,
        List<Booking> Bookings
    );
