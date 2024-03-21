using Microsoft.AspNetCore.Mvc;

namespace Bookflix.Api.Controllers;

public class DummyController : ApiController
{
    public IActionResult ListDummyData()
    {
        return Ok(Array.Empty<string>());
    }
}