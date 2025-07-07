using Talabat.Core;
using Talabat.Core.Entityies;
using Talabat.Core.Entityies.Order_Aggregate;
using Talabat.Core.Repositories;
using Talabat.Core.Services.OrderService;
using Talabat.Core.Specifications.OrdersSpec;

namespace Talabat.Application
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Order?> CreateOrderAsync(string buyerEmail, string basketId, int deliveryMethodId, Adreess ShippingAddress)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);

            var orderItems = new List<OrderItem>();
            if (basket?.Items.Count > 0)
            {
                foreach (var item in basket.Items)
                {
                    var product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                    var productItemOrder = new ProductItemOrdered(item.Id, product.Name, product.PictureUrl);
                    var orderItem = new OrderItem(productItemOrder, product.Price, item.Quantity);
                    orderItems.Add(orderItem);
                }

            }
            var subTotal = orderItems.Sum(OrderItem => OrderItem.Price * OrderItem.Quantity);
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);

            var Order = new Order(buyerEmail, ShippingAddress, deliveryMethod, orderItems, subTotal);
            await _unitOfWork.Repository<Order>().AddAsync(Order);

            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;
            return Order;


        }

        public async Task<IEnumerable<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var orderRepo = _unitOfWork.Repository<Order>();
            var spec = new OrderSpecifications(buyerEmail);
            var orders = await orderRepo.GetAllWithSpecAsync(spec);
            return orders;
        }
        public async Task<Order?> GetOrderByIdForUserAsync(int orderId, string buyerEmail)
        {
            var orderRepo = _unitOfWork.Repository<Order>();
            var spec = new OrderSpecifications(orderId, buyerEmail);
            var orders = await orderRepo.GetWithSpecAsync(spec);
            return orders;
        }

        public async Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync()
        => await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();

    }
}
