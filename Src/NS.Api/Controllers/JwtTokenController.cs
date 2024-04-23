using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NS.Api.Controllers;

[Route("tokens")]
[AllowAnonymous]
public class JwtTokenController
{
    [HttpPost("GenerateToken")]
    public async Task<IActionResult> GenerateToken()
    {
        return null;
    }
}