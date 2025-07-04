using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Entityies.Order_Aggregate;

namespace Talabat.Infrastructure.Config
{
    internal class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(O => O.ShippingAddress, ShippingAddress => ShippingAddress.WithOwner()); //1 :1 [Total]
            builder.Property(O => O.Status)
                .HasConversion(

                OStatus => OStatus.ToString(),

                OStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), OStatus)
                );
            //builder.HasOne(o => o.DeliveryMethod).WithOne();
            //builder.HasIndex(o => o.DeliveryMethodId).IsUnique()
            builder.Property(o => o.Subtotal).HasColumnType("decimal(18,2)");
            builder.HasOne(O => O.DeliveryMethod).WithMany().OnDelete(DeleteBehavior.SetNull);
        }
    }
}
