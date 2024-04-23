using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController
{
    [HttpGet("GetProduct")]
    [AllowAnonymous]
    public async Task<IActionResult> GetProduct()
    {
        return null;
    }
}