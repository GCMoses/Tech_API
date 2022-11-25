using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/cpucooler")]
[ApiController]
public class CPUCoolerController : ControllerBase
{
    private readonly IServiceManager _service;
    public CPUCoolerController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetCPUCoolersForProduct(Guid productId)
    {
        var cpuCoolers = _service.CPUCoolerService.GetCPUCoolers(productId, trackChanges: false);
        return Ok(cpuCoolers);
    }

    [HttpGet("{id:guid}", Name = "GetCPUCoolerForProduct")]
    public IActionResult GetCPUCoolerForProduct(Guid productId, Guid id)
    {
        var cpuCooler = _service.CPUCoolerService.GetCPUCooler(productId, id, trackChanges: false);
        return Ok(cpuCooler);
    }


    [HttpPost]
    public IActionResult CreateCPUCoolerForProduct(Guid productId, [FromBody] CPUCoolerCreateDTO cpuCoolerCreate)
    {
        if (cpuCoolerCreate is null)
            return BadRequest("CPUCoolerCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var cpuCoolerToReturn =
        _service.CPUCoolerService.CreateCPUCoolerForProduct(productId, cpuCoolerCreate, trackChanges:
        false);
        return CreatedAtRoute("GetCPUCoolerForProduct", new
        {
            productId,
            id =
        cpuCoolerToReturn.Id
        },
        cpuCoolerToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCPUCoolerForProduct(Guid productId, Guid id)
    {
        _service.CPUCoolerService.DeleteCPUCoolerForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateCPUCoolerForProduct(Guid productId, Guid id,
        [FromBody] CPUCoolerUpdateDTO cpuCoolerUpdate)
    {
        if (cpuCoolerUpdate is null)
            return BadRequest("CPUCoolerUpdateDTO object is null");

        _service.CPUCoolerService.UpdateCPUCoolerForProduct(productId, id, cpuCoolerUpdate,
            productTrackChanges: false, cpuCoolerTrackChanges: true);

        return NoContent();
    }


    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateCPUCoolerForProduct(Guid productId, Guid id,
[FromBody] JsonPatchDocument<CPUCoolerUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.CPUCoolerService.GetCPUCoolerForPatch(productId, id,
        productTrackChanges: false,
        cpuCoolerTrackChanges: true);
        patchDoc.ApplyTo(result.cpuCoolerToPatch, ModelState);

        TryValidateModel(result.cpuCoolerToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.CPUCoolerService.SaveChangesForPatch(result.cpuCoolerToPatch,
        result.cpuCoolerEntity);
        return NoContent();
    }
}
