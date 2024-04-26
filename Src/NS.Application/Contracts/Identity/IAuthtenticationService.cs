using NS.Application.Models.Auth;

namespace NS.Application.Contracts.Identity;

public interface IAuthenticationService
{
    public Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request);
    public Task<RegisterResponse> RegisterAsync(RegisterRequest request);

}