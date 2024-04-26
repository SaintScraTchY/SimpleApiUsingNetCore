using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NS.Application.Contracts.Identity;
using NS.Application.Models.Auth;

namespace NS.Api.Controllers.v1;

[Route("Api/v1/[controller]")]
[AllowAnonymous]
public class UserController
{
    private readonly IAuthenticationService _authenticationService;

    public UserController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Authenticate")] 
    [AllowAnonymous]
    public async Task<ActionResult<AuthenticateResponse>> AuthenticateAsync(AuthenticateRequest authenticateRequest)
    {
        return (await _authenticationService.AuthenticateAsync(authenticateRequest));
    }
    
    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<ActionResult<RegisterResponse>> RegisterAsync(RegisterRequest registerRequest)
    {
        return await _authenticationService.RegisterAsync(registerRequest);
    }
}