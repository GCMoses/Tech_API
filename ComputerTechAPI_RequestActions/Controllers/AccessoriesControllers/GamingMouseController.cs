using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.AccessoriesController;

[Route("api/products/{productId}/gamingmouse")]
[ApiController]
public class GamingMouseController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingMouseController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGamingMouseForProduct(Guid productId)
    {
        var gamingMouse = _service.GamingMouseService.GetGamingMouses(productId, trackChanges: false);
        return Ok(gamingMouse);
    }

    [HttpGet("{id:guid}", Name = "GamingMouseById")]
    public IActionResult GetGamingMouseForProduct(Guid productId, Guid id)
    {
        var gamingMouse = _service.GamingMouseService.GetGamingMouse(productId, id, trackChanges: false);
        return Ok(gamingMouse);
    }
}
