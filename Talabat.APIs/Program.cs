
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Talabat.APIs.Extensions;
using Talabat.Core.Entityies.Identity;
using Talabat.Infrastructure.Data;
using Talabat.Infrastructure.Identity;

namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.AddSingleton<IConnectionMultiplexer>((serviceProvider) =>
            {
                var connection = builder.Configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connection);
            });
            builder.Services.AddIdentity<AppUser, IdentityRole>(options => { }).AddEntityFrameworkStores<AppIdentityDbContext>();

            builder.Services.AddApplicationServices(builder.Configuration);
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var storeContext = services.GetRequiredService<StoreContext>();
                    await storeContext.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(storeContext);

                    var identityDbContext = services.GetRequiredService<AppIdentityDbContext>();
                    await identityDbContext.Database.MigrateAsync();

                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    await AppIdentityDbContexSeed.SeedUserAsync(userManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred during migration or seeding");
                }
            }

            // Configure the HTTP request pipeline.

            //app.UseMiddleware<ExceptionMiddleware>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
