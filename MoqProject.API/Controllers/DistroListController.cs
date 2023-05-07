using Microsoft.AspNetCore.Mvc;
using MoqProject.API.Interfaces;

namespace MoqProject.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DistroListController : ControllerBase
{
    private readonly ILogger<DistroListController> _logger;
    private readonly IDistroListService _distroListService;

    public DistroListController(ILogger<DistroListController> logger, IDistroListService distroListService)
    {
        _distroListService = distroListService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDistro(int id)
    {
        var distro = await _distroListService.GetDistroById(id);

        if(distro != null)
            return Ok(distro);

        return NotFound();
    }
}
