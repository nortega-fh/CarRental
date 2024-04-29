using Contracts.Vehicles;
using Domain.Vehicles;
using FluentValidation;

namespace Api.Vehicles;

public class VehicleValidator : AbstractValidator<VehicleCreateReq>
{
    public VehicleValidator()
    {
        RuleFor(vehicle => vehicle.Make).NotEmpty().MaximumLength(30);
        RuleFor(vehicle => vehicle.Model).NotEmpty().MaximumLength(30);
        RuleFor(vehicle => vehicle.Year).GreaterThan(0);
        RuleFor(vehicle => vehicle.Capacity).GreaterThan(0);
        RuleFor(vehicle => vehicle.Mileage).GreaterThanOrEqualTo(0);
        RuleFor(vehicle => vehicle.DailyPrice).GreaterThanOrEqualTo(0);
        RuleFor(vehicle => vehicle.Type).NotEmpty().IsEnumName(typeof(VehicleType), false);
    }
}
