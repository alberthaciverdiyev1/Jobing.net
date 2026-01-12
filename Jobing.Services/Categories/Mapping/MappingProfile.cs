using AutoMapper;
using Repositories.Categories;
using Services.Categories.Create;

namespace Services.Categories.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<CreateCategoryRequest, Category>()
            .ForMember(dest => dest.NameAz, opt => opt.MapFrom(src => src.NameAz.ToLowerInvariant()))
            .ForMember(dest => dest.NameRu, opt => opt.MapFrom(src => src.NameRu.ToLowerInvariant()))
            .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn.ToLowerInvariant()))
            .ForMember(dest => dest.NameTr, opt => opt.MapFrom(src => src.NameTr.ToLowerInvariant()));
    }
}