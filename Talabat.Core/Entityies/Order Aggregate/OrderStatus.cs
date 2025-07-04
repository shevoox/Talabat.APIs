using System.Runtime.Serialization;

namespace Talabat.Core.Entityies.Order_Aggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "pending")]
        pending,
        [EnumMember(Value = "payment Recevied")]
        paymentReceived,
        [EnumMember(Value = "payment Failed")]
        paymentFailed,

    }
}
