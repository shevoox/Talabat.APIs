using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entityies.Identity;

namespace Talabat.Infrastructure.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>

    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
        }



        // لو حبيت تعمل Configurations إضافية
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // مثال: تعديل اسم جدول المستخدم
            builder.Entity<Address>().ToTable("Addresses");

            // ممكن تضيف Configurations إضافية هنا
        }
    }
}

