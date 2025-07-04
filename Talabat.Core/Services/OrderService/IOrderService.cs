using Talabat.Core.Entityies.Order_Aggregate;

namespace Talabat.Core.Services.OrderService
{
    public interface IOrderService
    {
        Task<Order?> CreateOrderAsync(string buyerEmail, string basket, int deliveryMethodId, Adreess ShippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail);

    }
}
