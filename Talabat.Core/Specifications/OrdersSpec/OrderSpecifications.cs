using Talabat.Core.Entityies.Order_Aggregate;

namespace Talabat.Core.Specifications.OrdersSpec
{
    public class OrderSpecifications : BaseSpecifications<Order>
    {
        public OrderSpecifications(string BuyerEmail) : base(O => O.BuyerEmail == BuyerEmail)
        {
            Includes.Add(O => O.DeliveryMethod);
            Includes.Add(O => O.Items);


            AddOrderByDesc(O => O.OrderDate);
        }
        public OrderSpecifications(int OrderId, string BuyerEmail) : base(O => O.Id == OrderId && O.BuyerEmail == BuyerEmail)
        {
            Includes.Add(O => O.DeliveryMethod);
            Includes.Add(O => O.Items);



        }
    }
}
