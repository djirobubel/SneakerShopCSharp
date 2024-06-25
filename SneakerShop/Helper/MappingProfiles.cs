using AutoMapper;
using SneakerShop.Dto;
using SneakerShop.Models;

namespace SneakerShop.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Sneaker, SneakerDto>();
            CreateMap<SneakerDto, Sneaker>();
            CreateMap<Size, SizeDto>();
            CreateMap<SizeDto, Size>();
        }
    }
}
