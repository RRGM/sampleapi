using Microsoft.AspNetCore.Mvc;

namespace sampleapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanetController : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return await Task.FromResult(Ok(new { id }));
    }
    [HttpGet]
    public async Task<IActionResult> GetList(int limit)
    {
        return await Task.FromResult(Ok(new { limit }));
    }
}
