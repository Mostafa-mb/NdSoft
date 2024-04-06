using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public List<AppUserProduct> AppUserProducts { get; set; } = new List<AppUserProduct>();
    }
}
