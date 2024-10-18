using FoodTrip.Api.Errors;
using FoodTrip.Api.Filters;
using FoodTrip.Application;
using FoodTrip.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, FoodTripProblemDetailsFactory>();
}


var app = builder.Build();
{   
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

