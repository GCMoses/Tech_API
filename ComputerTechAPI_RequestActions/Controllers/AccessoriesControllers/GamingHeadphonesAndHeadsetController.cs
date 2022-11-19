using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.AccessoriesController;

[Route("api/products/{productId}/gamingheadphonesandheadsets")]
[ApiController]
public class GamingHeadphonesAndHeadsetController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingHeadphonesAndHeadsetController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGamingHeadphonesAndHeadsetsForProduct(Guid productId)
    {
        var gamingHeadphonesAndHeadsets = _service.GamingHeadphonesAndHeadsetService.GetGamingHeadphonesAndHeadsets(productId, trackChanges: false);
        return Ok(gamingHeadphonesAndHeadsets);
    }

    [HttpGet("{id:guid}", Name = "GamingHeadphonesAndHeadsetById")]
    public IActionResult GetGamingHeadphonesAndHeadsetForProduct(Guid productId, Guid id)
    {
        var gamingHeadphonesAndHeadset = _service.GamingHeadphonesAndHeadsetService.GetGamingHeadphonesAndHeadset(productId, id, trackChanges: false);
        return Ok(gamingHeadphonesAndHeadset);
    }
}
