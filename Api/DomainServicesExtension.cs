using Domain.Vehicles;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Api;

public static class DomainServicesExtension
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.TryAddScoped<IVehicleService, VehicleService>();
    }
}
