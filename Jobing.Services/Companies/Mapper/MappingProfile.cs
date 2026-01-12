using AutoMapper;
using Repositories.Companies;

namespace Services.Companies.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyAdminDto>()
            .ReverseMap();

        CreateMap<Company, CompanyUserDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest, destMember, context) =>
            {
                var culture = context.Items["culture"] as string ?? "az";
                return src.Name.TryGetValue(culture, out var value) ? value : src.Name.GetValueOrDefault("az", "");
            }))
            .ForMember(dest => dest.Description, opt => opt.MapFrom((src, dest, destMember, context) =>
            {
                var culture = context.Items["culture"] as string ?? "az";
                return src.Description.TryGetValue(culture, out var value) ? value : src.Description.GetValueOrDefault("az", "");
            }))
            .ReverseMap();
    }
}