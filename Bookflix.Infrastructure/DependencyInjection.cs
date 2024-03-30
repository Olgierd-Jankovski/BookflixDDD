using Bookflix.Application.Common.Interfaces.Authentication;
using Bookflix.Application.Common.Interfaces.Services;
using Bookflix.Infrastructure.Authentication;
using Bookflix.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Bookflix.Application.Common.Interfaces.Persistence;
using Bookflix.Infrastructure.Persistence.userRepository;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Bookflix.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Bookflix.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {   
        services.AddAuth(configuration).AddPersistence();
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IIDentityService, IdentityService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }

    public static IServiceCollection AddPersistence(
        this IServiceCollection services)
    {

        services.AddDbContext<AppDbContext>(options =>
        {
        options.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=BookflixDB;Trusted_Connection=True");
        });

        return services;
    }

public static IServiceCollection AddAuth(
 this IServiceCollection services,
    ConfigurationManager configuration)
{
    var jwtSettings = new JwtSettings();
    configuration.Bind(JwtSettings.SectionName, jwtSettings);

    services.AddSingleton(Options.Create(jwtSettings));
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

    services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
        });

    return services;
}
}