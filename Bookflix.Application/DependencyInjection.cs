using Bookflix.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Bookflix.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}