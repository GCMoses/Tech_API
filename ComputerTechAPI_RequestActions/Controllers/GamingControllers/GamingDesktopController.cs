using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.GamingController;

[Route("api/products/{productId}/gamingdesktop")]
[ApiController]
public class GamingDesktopController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingDesktopController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGamingDesktopsForProduct(Guid productId)
    {
        var gamingDesktops = _service.GamingDesktopService.GetGamingDesktops(productId, trackChanges: false);
        return Ok(gamingDesktops);
    }

    [HttpGet("{id:guid}", Name = "GamingDesktopById")]
    public IActionResult GetGamingDesktopForProduct(Guid productId, Guid id)
    {
        var gamingDesktop = _service.GamingDesktopService.GetGamingDesktop(productId, id, trackChanges: false);
        return Ok(gamingDesktop);
    }
}
