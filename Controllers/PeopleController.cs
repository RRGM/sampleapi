using Microsoft.AspNetCore.Mvc;
using sampleapi.Interfaces;

namespace sampleapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly IPeopleService _peopleService;
    public PeopleController(IPeopleService peopleService)
    {
        _peopleService = peopleService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _peopleService.GetById(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetList(int limit)
    {
        return await Task.FromResult(Ok(new { limit }));
    }
}
