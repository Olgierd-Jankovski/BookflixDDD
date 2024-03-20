using Bookflix.Api.Common.Errors;
using Bookflix.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Bookflix.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>(); // Override ProblemDetailsFactory
        services.AddMapping();
        
        return services;
    }
}