using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.GamingController;

[Route("api/products/{productId}/gamingconsole")]
[ApiController]
public class GamingConsoleController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingConsoleController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGamingConsolesForProduct(Guid productId)
    {
        var gamingConsoles = _service.GamingConsoleService.GetGamingConsoles(productId, trackChanges: false);
        return Ok(gamingConsoles);
    }

    [HttpGet("{id:guid}", Name = "GamingConsoleById")]
    public IActionResult GetGamingConsoleForProduct(Guid productId, Guid id)
    {
        var gamingConsole = _service.GamingConsoleService.GetGamingConsole(productId, id, trackChanges: false);
        return Ok(gamingConsole);
    }
}
