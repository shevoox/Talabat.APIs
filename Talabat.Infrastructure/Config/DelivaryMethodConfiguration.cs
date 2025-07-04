using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Entityies.Order_Aggregate;

namespace Talabat.Infrastructure.Config
{
    internal class DelivaryMethodConfigurations : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(deliveryMethod => deliveryMethod.Cost).HasColumnType("decimal(18,2)");
        }
    }
}
