using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SKYResturant.Models
{
    public class SkyDbContext : IdentityDbContext<IdentityUser>
    {  
        public SkyDbContext(DbContextOptions<SkyDbContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
    }
}
