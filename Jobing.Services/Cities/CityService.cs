using System.Net;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Cities;
using Services.Cities.Create;
using Services.Cities.Update;

namespace Services.Cities;

public class CityService(
    ICityInterface cityRepository,
    IUnitOfWork unitOfWork,
    IValidator<CreateCityRequest> createRequestValidator,
    IMapper mapper) : ICityService
{
    public async Task<ServiceResult<List<CityDto>>> GetLastCitiesAsync()
    {
        var cities = await cityRepository.GetLastCitiesAsync(5);

        #region Manual mapping

        // var cityAsDto = cities.Select(c => new CityDto(c.Id, c.Name, c.IsActive, c.CreatedAt)).ToList();

        #endregion

        var cityAsDto = mapper.Map<List<CityDto>>(cities);

        return ServiceResult<List<CityDto>>.Success(cityAsDto);
    }

    public async Task<ServiceResult<List<CityDto>>> GetAll()
    {
        var cities = await cityRepository.GetAll().ToListAsync();

        #region Manual Mapping

        //  var cityAsDto = cities.Select(c => new CityDto(c.Id, c.Name, c.IsActive, c.CreatedAt)).ToList();

        #endregion

        var cityAsDto = mapper.Map<List<CityDto>>(cities);

        return ServiceResult<List<CityDto>>.Success(cityAsDto);
    }

    public async Task<ServiceResult<CityDto?>> GetByIdAsync(int id)
    {
        var city = await cityRepository.GetByIdAsync(id);

        if (city is null)
        {
            return ServiceResult<CityDto?>.Fail("City not found", HttpStatusCode.NotFound);
        }

        var cityDto = mapper.Map<CityDto>(city);

        return ServiceResult<CityDto>.Success(cityDto)!;
    }

    public async Task<ServiceResult<CreateCityResponse>> CreateAsync(CreateCityRequest request)
    {
        var anyCity = await cityRepository.Where(x => x.Name == request.Name).AnyAsync();
        if (anyCity)
        {
            return ServiceResult<CreateCityResponse>.Fail("City name must be unique", HttpStatusCode.BadRequest);
        }

        // var validationResult = await createRequestValidator.ValidateAsync(request);
        //
        // if (!validationResult.IsValid)
        // {
        //     return ServiceResult<CreateCityResponse>.Fail(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
        // }

        var city = new City()
        {
            Name = request.Name,
            IsActive = request.IsActive
        };
        await cityRepository.AddAsync(city);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult<CreateCityResponse>.Success(new CreateCityResponse(city.Id, city.Name, city.IsActive,
            city.CreatedAt));
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateCityRequest request)
    {
        var city = await cityRepository.GetByIdAsync(id);

        if (city is null)
        {
            return ServiceResult.Fail("City not found", HttpStatusCode.NotFound);
        }

        city.Name = request.Name;
        city.IsActive = request.IsActive;

        cityRepository.Update(city);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var city = await cityRepository.GetByIdAsync(id);
        if (city is null)
        {
            return ServiceResult.Fail("City not found");
        }

        cityRepository.Delete(city);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }
}