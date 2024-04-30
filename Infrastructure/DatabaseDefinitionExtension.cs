using Infrastructure.Bookings;
using Infrastructure.RentalBranches;
using Infrastructure.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class DatabaseDefinitionExtension
{
    private const string Decimal = "decimal";

    public static void DefineCarRentalTables(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fee>()
            .Property(fee => fee.Amount)
            .HasColumnType(Decimal)
            .HasPrecision(2);

        modelBuilder.Entity<Tax>()
            .Property(tax => tax.Amount)
            .HasColumnType(Decimal)
            .HasPrecision(2);

        modelBuilder.Entity<Vehicle>()
            .Property(vehicle => vehicle.DailyPrice)
            .HasColumnType(Decimal);

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
