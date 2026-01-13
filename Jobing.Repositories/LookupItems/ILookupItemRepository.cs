using Repositories.Generics;

namespace Repositories.LookupItems;

public interface ILookupItemRepository : IGenericRepository<LookupItem>
{
    public Task<IReadOnlyList<LookupItem>> GetGroupItemsAsync(string code);
}