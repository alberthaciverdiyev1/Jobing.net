using AutoMapper;
using Repositories.Cities;
using Services.Cities.Create;
using Services.Cities.Update;

namespace Services.Cities.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<City, CityDto>().ReverseMap();
     //   CreateMap<CreateCityRequest, City>();
       // CreateMap<UpdateCityRequest, City>();
    }
}