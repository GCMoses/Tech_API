using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/psu")]
[ApiController]
public class PSUController : ControllerBase
{
    private readonly IServiceManager _service;
    public PSUController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetPSUsForProduct(Guid productId)
    {
        var psus = _service.PSUService.GetPSUs(productId, trackChanges: false);
        return Ok(psus);
    }

    [HttpGet("{id:guid}", Name = "PSUById")]
    public IActionResult GetPSUForProduct(Guid productId, Guid id)
    {
        var psu = _service.PSUService.GetPSU(productId, id, trackChanges: false);
        return Ok(psu);
    }
}
