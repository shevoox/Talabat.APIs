using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Talabat.Core.Entityies.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        [NotMapped]
        public Address Address { get; set; }
    }
}
