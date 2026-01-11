using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Repositories.Interceptors;

public class AuditDbContextInterceptors:SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {

        foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries().ToList())
        {
            switch (entityEntry.State)
            {
                case EntityState.Added:

                    if (entityEntry.Entity is IAuditEntity auditEntity)
                    {
                        auditEntity.CreatedAt = DateTime.UtcNow;
                        eventData.Context.Entry(auditEntity).Property(x => x.CreatedAt).IsModified = false;
                    }
                    break;
                case EntityState.Modified:

                    if (entityEntry.Entity is IAuditEntity auditUpdateEntity)
                    {
                        auditUpdateEntity.UpdatedAt = DateTime.UtcNow;
                        eventData.Context.Entry(auditUpdateEntity).Property(x => x.UpdatedAt).IsModified = false;

                    }
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    continue;
            }
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}