using Microsoft.AspNetCore.Identity;

namespace WreckRoad.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
