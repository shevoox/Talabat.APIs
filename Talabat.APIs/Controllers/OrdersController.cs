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
    //[Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [ProducesResponseType(typeof(OrderToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponce), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto orderDto)
        {
            var address = _mapper.Map<AddressDto, Adreess>(orderDto.ShippingAddress);
            var order = await _orderService.CreateOrderAsync(orderDto.BuyerEmail, orderDto.BasketId, orderDto.DeliveryMethodId, address);
            if (order is null) return BadRequest(new ApiErrorResponce(400));
            return Ok(_mapper.Map<Order, OrderToReturnDto>(order));
        }

        [HttpGet]//api/order?email=test@gmail.com
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrderForUser(string Email)
        {
            //var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var orders = await _orderService.GetOrdersForUserAsync(Email);
            return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderToReturnDto>>(orders));
        }
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponce), StatusCodes.Status404NotFound)]
        [HttpGet("id")]//api/order/1?email=test@gmail.com
        public async Task<ActionResult<OrderToReturnDto>> GetOrderForUser(int id, string Email)
        {
            var order = await _orderService.GetOrderByIdForUserAsync(id, Email);
            if (order is null) return NotFound(new ApiErrorResponce(404));
            return Ok(_mapper.Map<Order, OrderToReturnDto>(order));
        }
        [HttpGet("deliveryMethods")]//get:/Api/orders/deliveryMethods
        public async Task<ActionResult<IEnumerable<DeliveryMethod>>> GetDeliveryMethods()
        {
            var deliveryMethods = await _orderService.GetDeliveryMethodsAsync();
            return Ok(deliveryMethods);
        }
    }
}
