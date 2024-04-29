using Infrastructure.Bookings;
using Infrastructure.RentalBranches;
using Infrastructure.RentalCompanies;
using Infrastructure.Users;
using Infrastructure.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class CarRentalContext : DbContext
{
    public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
    {

    }

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<RentalBranch> RentalBranches { get; set; }
    public DbSet<Fee> Fees { get; set; }
    public DbSet<Tax> Taxes { get; set; }
    public DbSet<RentalCompany> RentalCompanies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }
}
