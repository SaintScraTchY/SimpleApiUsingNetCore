using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NS.Infrastructure.Identity.Models;

namespace NS.Infrastructure.Identity;

public class AppIdentityContext : IdentityDbContext<AppUser>
{
    const string cnnString = "Data Source=.;Initial Catalog=NadinDB;Trusted_Connection=True;TrustServerCertificate=True";
    public AppIdentityContext()
    {
        
    }
    public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(cnnString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}