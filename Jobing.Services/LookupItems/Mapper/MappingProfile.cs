using AutoMapper;
using Repositories.LookupItems;
using Services.LookupItems.Create;
using Services.LookupItems.Update;

namespace Services.LookupItems.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LookupItemUserDto, LookupItem>().ReverseMap();
        
        CreateMap<UpdateLookupItemRequest, LookupItem>();
        CreateMap<CreateLookupItemRequest, LookupItem>();
        
        CreateMap<LookupItem, LookupItemUserDto>()
            .ReverseMap();

        CreateMap<LookupItem, LookupItemAdminDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest, destMember, context) =>
            {
                var culture = context.Items["culture"] as string ?? "az";
                return src.Name.TryGetValue(culture, out var value) ? value : src.Name.GetValueOrDefault("az", "");
            }))
            .ReverseMap();
    }
}