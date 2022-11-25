using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/hdd")]
[ApiController]
public class HDDController : ControllerBase
{
    private readonly IServiceManager _service;
    public HDDController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetHDDsForProduct(Guid productId)
    {
        var hdds = _service.HDDService.GetHDDs(productId, trackChanges: false);
        return Ok(hdds);
    }

    [HttpGet("{id:guid}", Name = "GetHDDForProduct")]
    public IActionResult GetHDDForProduct(Guid productId, Guid id)
    {
        var hdd = _service.HDDService.GetHDD(productId, id, trackChanges: false);
        return Ok(hdd);
    }


    [HttpPost]
    public IActionResult CreateHDDForProduct(Guid productId, [FromBody] HDDCreateDTO hddCreate)
    {
        if (hddCreate is null)
            return BadRequest("HDDCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var hddToReturn =
        _service.HDDService.CreateHDDForProduct(productId, hddCreate, trackChanges:
        false);
        return CreatedAtRoute("GetHDDForProduct", new
        {
            productId,
            id =
        hddToReturn.Id
        },
        hddToReturn);
    }



    [HttpDelete("{id:guid}")]
    public IActionResult DeleteHDDForProduct(Guid productId, Guid id)
    {
        _service.HDDService.DeleteHDDForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateHDDForProduct(Guid productId, Guid id,
        [FromBody] HDDUpdateDTO hddUpdate)
    {
        if (hddUpdate is null)
            return BadRequest("HDDUpdateDTO object is null");

        _service.HDDService.UpdateHDDForProduct(productId, id, hddUpdate,
            productTrackChanges: false, hddTrackChanges: true);

        return NoContent();
    }


    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateHDDForProduct(Guid productId, Guid id,[FromBody] 
    JsonPatchDocument<HDDUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.HDDService.GetHDDForPatch(productId, id,
        productTrackChanges: false,
        hddTrackChanges: true);
        patchDoc.ApplyTo(result.hddToPatch, ModelState);

        TryValidateModel(result.hddToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.HDDService.SaveChangesForPatch(result.hddToPatch,
        result.hddEntity);
        return NoContent();
    }
}
