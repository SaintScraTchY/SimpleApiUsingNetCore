using Microsoft.AspNetCore.Identity;

namespace NS.Infrastructure.Identity.Models;

public class AppUser : IdentityUser
{
    public AppUser()
    {
        EmailConfirmed = true;
    }
}