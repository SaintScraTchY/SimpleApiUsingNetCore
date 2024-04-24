using Microsoft.AspNetCore.Identity;
using NS.Infrastructure.Identity.Models;

namespace NS.Infrastructure.Identity.Services;

public class AuthenticationService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
}