using System.Reflection;
using Mapster;
using MapsterMapper;

namespace Bookflix.Api.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {   
        // scan assembly, find all IRegister interfaces and register them
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}