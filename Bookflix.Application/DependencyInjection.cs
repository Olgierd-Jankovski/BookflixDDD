using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bookflix.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Registerign the MediatR dependency
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        return services; 
    }
}