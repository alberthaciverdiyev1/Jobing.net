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
        CreateMap<CreateCityRequest, City>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
        CreateMap<UpdateCityRequest, City>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
    }
}