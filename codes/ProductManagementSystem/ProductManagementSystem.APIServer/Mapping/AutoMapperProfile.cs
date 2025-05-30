using AutoMapper;
using ProductManagementSystem.Repository;
using ProductManagementSystem.APIServer.Models;

namespace ProductManagementSystem.APIServer.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductReadDto>()
                .ForMember<int>(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember<string>(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember<string?>(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                 .ForMember<decimal>(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<ProductWriteDto, Product>()
               .ForMember<string>(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember<string?>(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember<decimal>(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<ProductWriteDto, ProductReadDto>()
               .ForMember<string>(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember<string?>(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember<decimal>(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<UserRegistrationDto, User>()
                .ForMember<string>(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember<string>(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember<long?>(dest => dest.Mobile, opt => opt.MapFrom(src => src.Mobile))
                .ForMember<DateOnly?>(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));

            CreateMap<LogInUserDto, User>()
                .ForMember<string>(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember<string>(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }
    }
}
