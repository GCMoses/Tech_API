using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpGet("{id:guid}", Name = "GetSSDForProduct")]
    public IActionResult GetSSDForProduct(Guid productId, Guid id)
    {
        var ssd = _service.SSDService.GetSSD(productId, id, trackChanges: false);
        return Ok(ssd);
    }


    [HttpPost]
    public IActionResult CreateSSDForProduct(Guid productId, [FromBody] SSDCreateDTO ssdCreate)
    {
        if (ssdCreate is null)
            return BadRequest("SSDCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var ssdToReturn =
        _service.SSDService.CreateSSDForProduct(productId, ssdCreate, trackChanges:
        false);
        return CreatedAtRoute("GetSSDForProduct", new
        {
            productId,
            id =
        ssdToReturn.Id
        },
        ssdToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteSSDForProduct(Guid productId, Guid id)
    {
        _service.SSDService.DeleteSSDForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateSSDForProduct(Guid productId, Guid id,
        [FromBody] SSDUpdateDTO ssdUpdate)
    {
        if (ssdUpdate is null)
            return BadRequest("SSDUpdateDTO object is null");

        _service.SSDService.UpdateSSDForProduct(productId, id, ssdUpdate,
            productTrackChanges: false, ssdTrackChanges: true);

        return NoContent();
    }


    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateSSDForProduct(Guid productId, Guid id, [FromBody]
    JsonPatchDocument<SSDUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.SSDService.GetSSDForPatch(productId, id,
        productTrackChanges: false,
        ssdTrackChanges: true);
        patchDoc.ApplyTo(result.ssdToPatch, ModelState);

        TryValidateModel(result.ssdToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.SSDService.SaveChangesForPatch(result.ssdToPatch,
        result.ssdEntity);
        return NoContent();
    }
}
