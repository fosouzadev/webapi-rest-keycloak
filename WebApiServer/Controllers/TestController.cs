using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServer.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TestController : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult PostTest() => Ok();

    [HttpGet]
    [Authorize(Roles = "admin,manager")]
    public IActionResult GetTest() => Ok();

    [HttpPut]
    [Authorize(Roles = "manager")]
    public IActionResult PutTest() => Ok();
}
