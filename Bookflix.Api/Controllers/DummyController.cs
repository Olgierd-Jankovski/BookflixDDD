using Microsoft.AspNetCore.Mvc;

namespace Bookflix.Api.Controllers;

[Route("[controller]")]
public class DummyController : ApiController
{
    [HttpGet]
    public IActionResult ListDummyData()
    {
        return Ok(Array.Empty<string>());
    }
}