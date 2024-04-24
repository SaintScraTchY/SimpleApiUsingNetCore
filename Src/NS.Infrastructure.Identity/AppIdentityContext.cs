using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NS.Infrastructure.Identity.Models;

namespace NS.Infrastructure.Identity;

public class AppIdentityContext : IdentityDbContext<AppUser>
{
    public AppIdentityContext(DbContextOptions options) : base(options)
    {
        
    }
}