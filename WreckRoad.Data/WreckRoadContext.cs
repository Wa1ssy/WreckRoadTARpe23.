using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WreckRoad.Core.Domain;


namespace WreckRoad.Data
{
    public class WreckRoadContext : IdentityDbContext<ApplicationUser>
    {
        public WreckRoadContext(DbContextOptions<WreckRoadContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
    }
}
