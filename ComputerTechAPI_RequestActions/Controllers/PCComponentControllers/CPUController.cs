using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpGet("{id:guid}", Name = "GetCPUForProductById")]
    public IActionResult GetCPUForProduct(Guid productId, Guid id)
    {
        var cpu = _service.CPUService.GetCPU(productId, id, trackChanges: false);
        return Ok(cpu);
    }


    [HttpPost]
    public IActionResult CreateCPUForProduct(Guid productId, [FromBody] CPUCreateDTO cpuCreate)
    {
        if (cpuCreate is null)
            return BadRequest("CPUCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var cpuToReturn =
        _service.CPUService.CreateCPUForProduct(productId, cpuCreate, trackChanges:
        false);
        return CreatedAtRoute("GetCPUForProduct", new
        {
            productId,
            id =
        cpuToReturn.Id
        },
        cpuToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCPUForProduct(Guid productId, Guid id)
    {
        _service.CPUService.DeleteCPUForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateCPUForProduct(Guid productId, Guid id,
        [FromBody] CPUUpdateDTO cpuUpdate)
    {
        if (cpuUpdate is null)
            return BadRequest("CPUUpdateDTO object is null");

        _service.CPUService.UpdateCPUForProduct(productId, id, cpuUpdate,
            productTrackChanges: false, cpuTrackChanges: true);

        return NoContent();
    }


    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateCPUForProduct(Guid productId, Guid id,
[FromBody] JsonPatchDocument<CPUUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.CPUService.GetCPUForPatch(productId, id,
        productTrackChanges: false,
        cpuTrackChanges: true);
        patchDoc.ApplyTo(result.cpuToPatch, ModelState);

        TryValidateModel(result.cpuToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.CPUService.SaveChangesForPatch(result.cpuToPatch,
        result.cpuEntity);
        return NoContent();
    }
}
