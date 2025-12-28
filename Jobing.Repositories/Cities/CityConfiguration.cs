using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.City;

public class CityConfiguration:IEntityTypeConfiguration<Cities.City>
{
    public void Configure(EntityTypeBuilder<Cities.City> builder)
    {
        builder.ToTable("Cities");
        builder.HasKey(x=>x.Id);
        builder.Property(x=>x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x=>x.IsActive).IsRequired().HasDefaultValue(false);
        builder.Property(x=>x.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);
        builder.Property(x=>x.UpdatedAt).IsRequired().HasDefaultValue(null);
        builder.Property(x=>x.DeletedAt).IsRequired().HasDefaultValue(null);
    }
}