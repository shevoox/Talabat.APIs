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

            CreateMap<Order, OrderToReturnDto>().ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.DeliveryMethodCost, o => o.MapFrom(s => s.DeliveryMethod.Cost));

            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(p => p.ProductName, o => o.MapFrom(s => s.Product.ProductName))
                .ForMember(p => p.ProductId, o => o.MapFrom(s => s.Product.ProductId))
                .ForMember(p => p.PictureUrl, o => o.MapFrom(s => s.Product.ProductUrl))
                .ForMember(d => d.PictureUrl, O => O.MapFrom<OrderItemPictureResolver>());

        }
    }
}
