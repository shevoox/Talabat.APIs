

namespace Talabat.Core.Entityies.Order_Aggregate
{
    public class Order : BaseEntity
    {
        public Order() { }

        public Order(string buyerEmail, Adreess shippingAddress, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            DeliveryMethod = deliveryMethod;
            Items = items;
            Subtotal = subtotal;

        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.pending;
        public Adreess ShippingAddress { get; set; }
        /*public int? DeliveryMethodId { get; set; }*///foreign key one to one delivary optional
        public DeliveryMethod DeliveryMethod { get; set; } //navigation prop [one]
        ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>(); //navigation prop [many]
        public decimal Subtotal { get; set; }//totalItem X quantity

        //[NotMapped]
        //public decimal Total => Subtotal + DeliveryMethod.Cost;

        public decimal GetTotal() => Subtotal + DeliveryMethod.Cost;
        public string PaymentIntentId { get; set; } = string.Empty;
    }
}
