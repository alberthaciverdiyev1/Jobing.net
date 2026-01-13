using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Categories;
using Repositories.Cities;
using Repositories.Companies;
using Repositories.Database;
using Repositories.Generics;
using Repositories.LookupItems;

namespace Repositories.Extensions;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionStrings =
                configuration.GetSection(ConnectionStringOptions.Key).Get<ConnectionStringOptions>();
            options.UseSqlServer(connectionStrings!.SqlServer, optionsBuilder =>
            {
                optionsBuilder.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
            });
        });

        services.AddScoped<ICityInterface, CityRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ILookupItemRepository, LookupItemRepository>();
        
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}