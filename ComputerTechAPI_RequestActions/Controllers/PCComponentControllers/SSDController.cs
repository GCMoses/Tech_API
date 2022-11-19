using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/ssd")]
[ApiController]
public class SSDController : ControllerBase
{
    private readonly IServiceManager _service;
    public SSDController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetSSDsForProduct(Guid productId)
    {
        var ssds = _service.SSDService.GetSSDs(productId, trackChanges: false);
        return Ok(ssds);
    }

    [HttpGet("{id:guid}", Name = "SSDById")]
    public IActionResult GetSSDForProduct(Guid productId, Guid id)
    {
        var ssd = _service.SSDService.GetSSD(productId, id, trackChanges: false);
        return Ok(ssd);
    }
}
