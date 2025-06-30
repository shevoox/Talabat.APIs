using Microsoft.AspNetCore.Identity;
using Talabat.Core.Entityies.Identity;

namespace Talabat.Core.Services
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager);
    }
}
