using Domain.Vehicles;
using Infrastructure.Vehicles;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Api;

public static class RepositoryServicesExtension
{
    public static void AddInfrastructureRepositories(this IServiceCollection services)
    {
        services.TryAddScoped<IVehicleRepository, VehicleRepository>();
    }
}
