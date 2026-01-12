using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Companies;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");
        builder.HasKey(x=>x.Id);
        builder.Property(x=>x.IsActive).IsRequired().HasDefaultValue(true);
        builder.Property(x=>x.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);
        builder.Property(x=>x.UpdatedAt).IsRequired().HasDefaultValue(null);
        builder.Property(x=>x.DeletedAt).IsRequired().HasDefaultValue(null);
        
    }
}