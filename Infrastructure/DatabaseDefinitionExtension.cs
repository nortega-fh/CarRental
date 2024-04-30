using Infrastructure.Bookings;
using Infrastructure.RentalBranches;
using Infrastructure.Vehicles;
using Microsoft.EntityFrameworkCore;
using VehicleType = Domain.Vehicles.VehicleType;

namespace Infrastructure;

public static class DatabaseDefinitionExtension
{
    private const string Decimal = "decimal";
    private const int DefaultPrecision = 18;
    private const int DefaultScale = 2;

    public static void DefineCarRentalTables(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fee>()
            .Property(fee => fee.Amount)
            .HasColumnType(Decimal)
            .HasPrecision(DefaultPrecision, DefaultScale);

        modelBuilder.Entity<Tax>()
            .Property(tax => tax.Amount)
            .HasColumnType(Decimal)
            .HasPrecision(DefaultPrecision, DefaultScale);

        modelBuilder.Entity<Vehicle>()
            .Property(vehicle => vehicle.DailyPrice)
            .HasColumnType(Decimal)
            .HasPrecision(DefaultPrecision, DefaultScale);

        modelBuilder.Entity<Vehicle>()
            .Property(vehicle => vehicle.Type)
            .HasConversion(
                enumValue => enumValue.ToString(),
                stringValue => Enum.Parse<VehicleType>(stringValue)
            );

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.DropOffBranch)
            .WithMany()
            .HasForeignKey(b => b.DropOffBranchId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.PickUpBranch)
            .WithMany()
            .HasForeignKey(b => b.PickupBranchId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Company)
            .WithMany(company => company.Bookings)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany(user => user.Bookings)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Vehicle)
            .WithMany(vehicle => vehicle.Bookings)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
