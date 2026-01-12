using Repositories.Database;
using Repositories.Generics;

namespace Repositories.Categories;

public class CategoryRepository(AppDbContext context) : GenericRepository<Category>(context), ICategoryRepository
{
}