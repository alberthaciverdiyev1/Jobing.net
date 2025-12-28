using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  public DbSet<Cities.City> Cities { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
    base.OnModelCreating(modelBuilder);
  }

}