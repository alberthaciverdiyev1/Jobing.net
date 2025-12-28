using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Cities;
using Services.Cities;
using Services.Cities.Mapping;
using Services.ExceptionHandlers;

namespace Services.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<ICityService,CityService>();

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);
        //
        // services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // services.AddAutoMapper(typeof(MappingProfile).Assembly);

        services.AddExceptionHandler<CriticalExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        
        return services;
    }
}