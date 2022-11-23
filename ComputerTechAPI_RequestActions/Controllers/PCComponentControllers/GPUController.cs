using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
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

    [HttpGet("{id:guid}", Name = "GetGPUForProduct")]
    public IActionResult GetGPUForProduct(Guid productId, Guid id)
    {
        var gpu = _service.GPUService.GetGPU(productId, id, trackChanges: false);
        return Ok(gpu);
    }


    [HttpPost]
    public IActionResult CreateGPUForProduct(Guid productId, [FromBody] GPUCreateDTO gpuCreate)
    {
        if (gpuCreate is null)
            return BadRequest("CPUCreateDTO object is null");
        var gpuToReturn =
        _service.GPUService.CreateGPUForProduct(productId, gpuCreate, trackChanges:
        false);
        return CreatedAtRoute("GetGPUForProduct", new
        {
            productId,
            id =
        gpuToReturn.Id
        },
        gpuToReturn);
    }



    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGPUForProduct(Guid productId, Guid id)
    {
        _service.GPUService.DeleteGPUForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateGPUForProduct(Guid productId, Guid id,
        [FromBody] GPUUpdateDTO gpuUpdate)
    {
        if (gpuUpdate is null)
            return BadRequest("GPUUpdateDTO object is null");

        _service.GPUService.UpdateGPUForProduct(productId, id, gpuUpdate,
            productTrackChanges: false, gpuTrackChanges: true);

        return NoContent();
    }
}

