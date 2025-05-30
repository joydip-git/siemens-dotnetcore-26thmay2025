using AutoMapper;
using ProductManagementSystem.Entities;

namespace ProductManagementSystem.APIService.Mapping
{
    public class AutoMapperPofile : Profile
    {
        public AutoMapperPofile()
        {

            CreateMap<Product, ProductQueryDto>()
               .ForMember<int>(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember<string>(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember<string?>(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember<decimal>(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ReverseMap();

            CreateMap<ProductComandDto, Product>()
               .ForMember<string>(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember<string?>(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember<decimal>(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ReverseMap();

            //CreateMap<Product, ProductReadDto>();
            //CreateMap<ProductWriteDto, Product>();
        }
    }
}
