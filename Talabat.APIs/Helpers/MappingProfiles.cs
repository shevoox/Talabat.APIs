using AutoMapper;
using Talabat.APIs.Dtos;
using Talabat.Core.Entityies;
using Talabat.Core.Entityies.Identity;
using Talabat.Core.Entityies.Order_Aggregate;

namespace Talabat.APIs.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>().
                ForMember(P => P.Brand, O => O.MapFrom(s => s.Brand.Name))
                .ForMember(P => P.Category, O => O.MapFrom(s => s.Category.Name))
                //.ForMember(P => P.PictureUrl, O => O.MapFrom(s => $"{_configuration["BaseApiURL"]}/{s.PictureUrl}"));
                .ForMember(p => p.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, Adreess>();

            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
