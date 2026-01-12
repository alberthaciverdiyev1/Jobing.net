using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Categories;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(c => c.Id);
        builder.Property(x=>x.NameAz).IsRequired().HasMaxLength(100);
        builder.Property(x=>x.NameRu).IsRequired().HasMaxLength(100);
        builder.Property(x=>x.NameTr).IsRequired().HasMaxLength(100);
        builder.Property(x=>x.NameEn).IsRequired().HasMaxLength(100);
        builder.Property(x=>x.IsActive).IsRequired().HasDefaultValue(true);
        builder.Property(x=>x.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);
        builder.Property(x=>x.UpdatedAt).IsRequired().HasDefaultValue(null);
        builder.Property(x=>x.DeletedAt).IsRequired().HasDefaultValue(null);
    }
}