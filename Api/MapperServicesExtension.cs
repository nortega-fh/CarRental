using Api.Vehicles;
using Microsoft.Extensions.DependencyInjection.Extensions;
using InfVehicleMapper = Infrastructure.Vehicles.VehicleMapper;

namespace Api;

public static class MapperServicesExtension
{
    public static void AddMappers(this IServiceCollection services)
    {
        services.TryAddScoped<VehicleMapper>();
        services.TryAddScoped<InfVehicleMapper>();
    }
}
