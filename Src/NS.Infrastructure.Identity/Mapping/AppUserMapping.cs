using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NS.Infrastructure.Identity.Models;

namespace NS.Infrastructure.Identity.Mapping;

public class AppUserMapping : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("IdentityUsers");

        builder.Ignore(x => x.Email);
        builder.Ignore(x => x.EmailConfirmed);
        builder.Ignore(x => x.PhoneNumberConfirmed);
        builder.Ignore(x => x.LockoutEnabled);
        builder.Ignore(x => x.FullName);
        builder.Ignore(x => x.AccessFailedCount);
        builder.Ignore(x => x.TwoFactorEnabled);
        
    }
}