using Services.Categories.Create;
using Services.Categories.Update;

namespace Services.Categories;

public interface ICategoryService
{
    public Task<ServiceResult<List<CategoryDto>>> GetAll();
    public Task<ServiceResult<CategoryDto?>> GetByIdAsync(int id);
    public Task<ServiceResult<CreateCategoryResponse>> CreateAsync(CreateCategoryRequest request);
    public Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest request);
    public Task<ServiceResult> DeleteAsync(int id);
}