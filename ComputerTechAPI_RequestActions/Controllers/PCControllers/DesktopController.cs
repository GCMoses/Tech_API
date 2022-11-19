using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCControllers;

[Route("api/products/{productId}/desktop")]
[ApiController]
public class DesktopController : ControllerBase
{
    private readonly IServiceManager _service;
    public DesktopController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetDesktopsForProduct(Guid productId)
    {
        var desktops = _service.DesktopService.GetDesktops(productId, trackChanges: false);
        return Ok(desktops);
    }

    [HttpGet("{id:guid}", Name = "DesktopById")]
    public IActionResult GetDesktopForProduct(Guid productId, Guid id)
    {
        var desktop = _service.DesktopService.GetDesktop(productId, id, trackChanges: false);
        return Ok(desktop);
    }
}
