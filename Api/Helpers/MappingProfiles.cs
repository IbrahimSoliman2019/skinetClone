using Api.DTOS;
using AutoMapper;
using Core.Entities;
using Core.Identity;

namespace Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductToReturnDTO>()
            .ForMember(d=>d.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))
            .ForMember(d=>d.ProductType,o=>o.MapFrom(s=>s.ProductType.Name))
            .ForMember(d=>d.PictureUrl,o=>o.MapFrom<PictureUrlResolver>());

            CreateMap<Address,AddressDto>().ReverseMap(); 
        }
    }
}