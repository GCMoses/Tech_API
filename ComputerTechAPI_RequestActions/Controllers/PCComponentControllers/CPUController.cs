using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/cpu")]
[ApiController]
public class CPUController : ControllerBase
{
    private readonly IServiceManager _service;
    public CPUController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetCPUsForProduct(Guid productId)
    {
        var cpus = _service.CPUService.GetCPUs(productId, trackChanges: false);
        return Ok(cpus);
    }

    [HttpGet("{id:guid}", Name = "CPUById")]
    public IActionResult GetCPUForProduct(Guid productId, Guid id)
    {
        var cpu = _service.CPUService.GetCPU(productId, id, trackChanges: false);
        return Ok(cpu);
    }
}
