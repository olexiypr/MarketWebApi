using Microsoft.AspNetCore.Mvc;

namespace WebApi.Auth;
[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    [HttpPost]
    public IActionResult Token()
    {
        
        return Ok();
    }
}