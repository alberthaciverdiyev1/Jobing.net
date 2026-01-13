using Microsoft.EntityFrameworkCore;
using Repositories.Database;
using Repositories.Generics;

namespace Repositories.LookupItems;

public class LookupItemRepository(AppDbContext context) :GenericRepository<LookupItem>(context),ILookupItemRepository
{
    public async Task<IReadOnlyList<LookupItem>> GetGroupItemsAsync(string code)
    {
        return await Context.LookupItems
            .Where(i => i.Code ==code)
            .ToListAsync();
    }
}