

using Microsoft.AspNetCore.Mvc;
using FootballExplorer.Server.Services;

namespace FootballExplorer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FootballController : ControllerBase
{
    private readonly FootballApiService _footballApiService;

    public FootballController(FootballApiService footballApiService)
    {
        _footballApiService = footballApiService;
    }

    [HttpGet("competitions")]
    public async Task<IActionResult> GetCompetitions()
    {
        try
        {
            var competitions = await _footballApiService.GetAsync("competitions");

            return Ok(competitions);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(502, new
            {
                message = "Unable to retrieve football data.",
                details = ex.Message
            });
        }
    }
}
