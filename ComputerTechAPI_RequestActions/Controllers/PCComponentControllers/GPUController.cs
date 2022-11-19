using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/gpu")]
[ApiController]
public class GPUController : ControllerBase
{
    private readonly IServiceManager _service;
    public GPUController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGPUsForProduct(Guid productId)
    {
        var gpus = _service.GPUService.GetGPUs(productId, trackChanges: false);
        return Ok(gpus);
    }

    [HttpGet("{id:guid}", Name = "GPUById")]
    public IActionResult GetGPUForProduct(Guid productId, Guid id)
    {
        var gpu = _service.GPUService.GetGPU(productId, id, trackChanges: false);
        return Ok(gpu);
    }
}
