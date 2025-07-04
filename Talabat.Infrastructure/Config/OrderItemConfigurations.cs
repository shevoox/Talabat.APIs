using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Entityies.Order_Aggregate;

namespace Talabat.Infrastructure.Config
{
    internal class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(orderItem => orderItem.Product, Product => Product.WithOwner());
            //builder.Property(orderItem => orderItem.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Price)
       .HasColumnType("decimal(18,2)");

        }
    }
}
