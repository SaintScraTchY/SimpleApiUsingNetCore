using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NS.Api.Controllers.v1;

[Route("Api/v1/tokens")]
[AllowAnonymous]
public class UserController
{
    [HttpPost("GenerateToken")]
    public async Task<IActionResult> GenerateToken()
    {
        return null;
    }
}