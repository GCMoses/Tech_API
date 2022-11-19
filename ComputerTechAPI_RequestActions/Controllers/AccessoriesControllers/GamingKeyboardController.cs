using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.AccessoriesController;

[Route("api/products/{productId}/gamingkeyboard")]
[ApiController]
public class GamingKeyboardController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingKeyboardController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGamingKeyboardForProduct(Guid productId)
    {
        var gamingKeyboard = _service.GamingKeyboardService.GetGamingKeyboards(productId, trackChanges: false);
        return Ok(gamingKeyboard);
    }

    [HttpGet("{id:guid}", Name = "GamingKeyboardById")]
    public IActionResult GetGamingKeyboardForProduct(Guid productId, Guid id)
    {
        var gamingKeyboard = _service.GamingKeyboardService.GetGamingKeyboard(productId, id, trackChanges: false);
        return Ok(gamingKeyboard);
    }
}
