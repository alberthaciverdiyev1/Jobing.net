using Microsoft.EntityFrameworkCore;
using Repositories.Database;
using Repositories.Generics;

namespace Repositories.Categories;

public class CategoryRepository(AppDbContext context) : GenericRepository<Category>(context), ICategoryRepository
{
    public async Task<IReadOnlyList<Category>> GetChildrenAsync(int id)
    {
        return await Context.Categories
            .Where(c => c.ParentId == id && c.DeletedAt == null)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Category>> GetAllWithChildrenAsync()
    {
        return await Context.Categories.Include(c => c.Children).ToListAsync();
    }
}