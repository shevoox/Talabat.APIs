using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entityies.Identity;

namespace Talabat.Infrastructure.Identity
{
    public static class AppIdentityDbContexSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!await userManager.Users.AnyAsync())
            {
                var user = new AppUser()
                {
                    DisplayName = "Mahmoud Ahmed",
                    Email = "mahmoud.ahmed@example.com",
                    UserName = "mahmoud.ahmed",
                    PhoneNumber = "01012345678"
                };

                var result = await userManager.CreateAsync(user, "Passw0rd!");

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error: {error.Description}");
                    }
                }
                else
                {
                    Console.WriteLine("User created successfully!");
                }
            }
            else
            {
                Console.WriteLine("User already exists.");
            }
        }

    }
}
