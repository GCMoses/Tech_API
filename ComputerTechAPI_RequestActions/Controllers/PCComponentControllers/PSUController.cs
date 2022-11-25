using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpGet("{id:guid}", Name = "GetPSUForProduct")]
    public IActionResult GetPSUForProduct(Guid productId, Guid id)
    {
        var psu = _service.PSUService.GetPSU(productId, id, trackChanges: false);
        return Ok(psu);
    }


    [HttpPost]
    public IActionResult CreatePSUForProduct(Guid productId, [FromBody] PSUCreateDTO psuCreate)
    {
        if (psuCreate is null)
            return BadRequest("PSUCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var psuToReturn =
        _service.PSUService.CreatePSUForProduct(productId, psuCreate, trackChanges:
        false);
        return CreatedAtRoute("GetPSUForProduct", new
        {
            productId,
            id =
        psuToReturn.Id
        },
        psuToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeletePSUForProduct(Guid productId, Guid id)
    {
        _service.PSUService.DeletePSUForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdatePSUForProduct(Guid productId, Guid id,
        [FromBody] PSUUpdateDTO psuUpdate)
    {
        if (psuUpdate is null)
            return BadRequest("PSUUpdateDTO object is null");

        _service.PSUService.UpdatePSUForProduct(productId, id, psuUpdate,
            productTrackChanges: false, psuTrackChanges: true);

        return NoContent();
    }


    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdatePSUForProduct(Guid productId, Guid id, [FromBody]
    JsonPatchDocument<PSUUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.PSUService.GetPSUForPatch(productId, id,
        productTrackChanges: false,
        psuTrackChanges: true);
        patchDoc.ApplyTo(result.psuToPatch, ModelState);

        TryValidateModel(result.psuToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.PSUService.SaveChangesForPatch(result.psuToPatch,
        result.psuEntity);
        return NoContent();
    }
}
