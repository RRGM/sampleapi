using Microsoft.AspNetCore.Mvc;
using sampleapi.Interfaces;

namespace sampleapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanetController : ControllerBase
{
    private readonly IPlanetService _planetService;
    public PlanetController(IPlanetService planetService)
    {
        _planetService= planetService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _planetService.GetById(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetList(int limit)
    {
        return Ok(await _planetService.GetByLimit(limit));
    }
}
