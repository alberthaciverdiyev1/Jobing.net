using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Repositories.Categories;

namespace Repositories.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  public DbSet<Cities.City> Cities { get; set; } = default!;
  public DbSet<Category> Categories { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
    base.OnModelCreating(modelBuilder);
  }

}