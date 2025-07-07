using AutoMapper;
using Talabat.APIs.Dtos;
using Talabat.Core.Entityies.Order_Aggregate;

namespace Talabat.APIs.Helpers
{
    public class OrderItemPictureResolver : IValueResolver<OrderItem, OrderItemDTO, string>
    {
        private readonly IConfiguration _configuration;

        public OrderItemPictureResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Product.ProductUrl))
                return $"{_configuration["BaseApiURL"]}/{source.Product.ProductUrl}";
            return string.Empty;



        }
    }
}
