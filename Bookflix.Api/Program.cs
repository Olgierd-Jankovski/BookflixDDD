using Bookflix.Api.Common.Errors;
using Bookflix.Application;
using Bookflix.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
var builder = WebApplication.CreateBuilder(args);
{   
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>(); // Override ProblemDetailsFactory
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
