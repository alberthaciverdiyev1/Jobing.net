using Repositories.Cities;
using Services.Cities.Create;
using Services.Cities.Update;

namespace Services.Cities;

public interface ICityService
{
    public Task<ServiceResult<List<CityDto>>> GetLastCitiesAsync();
    public Task<ServiceResult<List<CityDto>>> GetAll();

    public Task<ServiceResult<CityDto?>> GetByIdAsync(int id);
    public Task<ServiceResult<CreateCityResponse>> CreateAsync(CreateCityRequest request);
    public Task<ServiceResult> UpdateAsync(int id, UpdateCityRequest request);
    public Task<ServiceResult> DeleteAsync(int id);
    
}