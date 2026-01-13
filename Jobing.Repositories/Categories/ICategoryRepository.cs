using Repositories.Generics;

namespace Repositories.Categories;

public interface ICategoryRepository:IGenericRepository<Category>
{
   public Task<IReadOnlyList<Category>> GetChildrenAsync(int id);
   public Task<IReadOnlyList<Category>> GetAllWithChildrenAsync();
}