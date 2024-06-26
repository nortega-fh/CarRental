﻿using Infrastructure.Bookings;
using Infrastructure.RentalBranches;
using Infrastructure.RentalCompanies;
using Infrastructure.Users;
using Infrastructure.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class CarRentalContext(DbContextOptions<CarRentalContext> options) : DbContext(options)
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<RentalBranch> RentalBranches { get; set; }
    public DbSet<Fee> Fees { get; set; }
    public DbSet<Tax> Taxes { get; set; }
    public DbSet<RentalCompany> RentalCompanies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.DefineCarRentalTables();
    }
}
