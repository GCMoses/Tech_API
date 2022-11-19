using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/ram")]
[ApiController]
public class RAMController : ControllerBase
{
    private readonly IServiceManager _service;
    public RAMController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetRAMsForProduct(Guid productId)
    {
        var rams = _service.RAMService.GetRAMs(productId, trackChanges: false);
        return Ok(rams);
    }

    [HttpGet("{id:guid}", Name = "RAMById")]
    public IActionResult GetRAMForProduct(Guid productId, Guid id)
    {
        var ram = _service.RAMService.GetRAM(productId, id, trackChanges: false);
        return Ok(ram);
    }
}
