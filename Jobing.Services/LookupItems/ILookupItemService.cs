using Services.LookupItems.Create;
using Services.LookupItems.Update;

namespace Services.LookupItems;

public interface ILookupItemService
{
    Task<ServiceResult<List<TDto>>> GetAllAsync<TDto>(string? culture = null) where TDto : class;
    
    Task<ServiceResult<TDto?>> GetByIdAsync<TDto>(int id, string? culture = null) where TDto : class;
    Task<ServiceResult<TDto?>> GetGroupItemsAsync<TDto>(int code, string? culture = null) where TDto : class;

    public Task<ServiceResult<LookupItemUserDto>> CreateAsync(CreateLookupItemRequest request);
    public Task<ServiceResult> UpdateAsync(int id, UpdateLookupItemRequest request);
    public Task<ServiceResult> DeleteAsync(int id);
}