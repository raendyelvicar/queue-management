using Microsoft.AspNetCore.Mvc;

namespace KioskService.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class KioskController : ControllerBase
{
    // GET
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Test from KioskController");
    }
}