using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Repositories.Categories;
using Repositories.Companies;
using Repositories.Cities;

namespace Repositories.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  public DbSet<City> Cities { get; set; } = default!;
  public DbSet<Category> Categories { get; set; } = default!;
  public DbSet<Company> Companies { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
    base.OnModelCreating(modelBuilder);
  }

}