using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Dtos;
using Talabat.APIs.Error;
using Talabat.Core.Entityies.Order_Aggregate;
using Talabat.Core.Services.OrderService;

namespace Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponce), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var address = _mapper.Map<AddressDto, Adreess>(orderDto.ShippingAddress);
            var order = await _orderService.CreateOrderAsync(orderDto.BuyerEmail, orderDto.BasketId, orderDto.DeliveryMethodId, address);
            if (order is null) return BadRequest(new ApiErrorResponce(400));
            return Ok(order);
        }
    }
}
