using Services.Companies.Create;
using Services.Companies.Update;

namespace Services.Companies;

public interface ICompanyService
{
    Task<ServiceResult<List<TDto>>> GetAllAsync<TDto>(string? culture = null) where TDto : class;
    Task<ServiceResult<TDto?>> GetByIdAsync<TDto>(int id, string? culture = null) where TDto : class;

    public Task<ServiceResult<CreateCompanyResponse>> CreateAsync(CreateCompanyRequest request);
    public Task<ServiceResult> UpdateAsync(int id, UpdateCompanyRequest request);
    public Task<ServiceResult> DeleteAsync(int id);
}