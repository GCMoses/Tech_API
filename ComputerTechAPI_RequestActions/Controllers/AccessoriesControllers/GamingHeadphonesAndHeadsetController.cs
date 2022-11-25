using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.AccessoriesController;

[Route("api/products/{productId}/gamingheadphonesandheadsets")]
[ApiController]
public class GamingHeadphonesAndHeadsetController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingHeadphonesAndHeadsetController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGamingHeadphonesAndHeadsetsForProduct(Guid productId)
    {
        var gamingHeadphonesAndHeadsets = _service.GamingHeadphonesAndHeadsetService.GetGamingHeadphonesAndHeadsets(productId, trackChanges: false);
        return Ok(gamingHeadphonesAndHeadsets);
    }

    [HttpGet("{id:guid}", Name = "GetGamingHeadphonesAndHeadsetForProduct")] 
    public IActionResult GetGamingHeadphonesAndHeadsetForProduct(Guid productId, Guid id)
    {
        var gamingHeadphonesAndHeadset = _service.GamingHeadphonesAndHeadsetService.GetGamingHeadphonesAndHeadset(productId, id, trackChanges: false);
        return Ok(gamingHeadphonesAndHeadset);
    }


   

    [HttpPost]
    public IActionResult CreateGamingHeadphonesAndHeadsetForProduct(Guid productId, [FromBody] GamingHeadphonesAndHeadsetCreateDTO gamingHeadphonesAndHeadsetCreate)
    {
        if (gamingHeadphonesAndHeadsetCreate is null)
            return BadRequest("GamingHeadphonesAndHeadsetCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var gamingHeadphonesAndHeadsetToReturn =
        _service.GamingHeadphonesAndHeadsetService.CreateGamingHeadphonesAndHeadsetForProduct(productId, gamingHeadphonesAndHeadsetCreate, trackChanges:
        false);
        return CreatedAtRoute("GetGamingHeadphonesAndHeadsetForProduct", new
        {
            productId, 
            id = gamingHeadphonesAndHeadsetToReturn.Id
        },
        gamingHeadphonesAndHeadsetToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGamingHeadphonesAndHeadsetForProduct(Guid productId, Guid id)
    {
        _service.GamingHeadphonesAndHeadsetService.DeleteGamingHeadphonesAndHeadsetForProduct(productId, id, trackChanges:
        false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateGamingHeadphonesAndHeadsetForProduct(Guid productId, Guid id,
        [FromBody] GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadsetUpdate)
    {
        if (gamingHeadphonesAndHeadsetUpdate is null)
            return BadRequest("GamingHeadphonesAndHeadsetUpdateDTO object is null");

        _service.GamingHeadphonesAndHeadsetService.UpdateGamingHeadphonesAndHeadsetForProduct(productId, id, gamingHeadphonesAndHeadsetUpdate,
            productTrackChanges: false, gamingHeadphonesAndHeadsetTrackChanges: true);

        return NoContent();
    }


    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateGamingHeadsetAndHeadphonesForProduct(Guid productId, Guid id, [FromBody] 
    JsonPatchDocument<GamingHeadphonesAndHeadsetUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.GamingHeadphonesAndHeadsetService.GetGamingHeadphonesAndHeadsetForPatch(productId, id,
        productTrackChanges: false,
        gamingHeadphonesAndHeadsetTrackChanges: true);
        patchDoc.ApplyTo(result.gamingHeadphonesAndHeadsetToPatch, ModelState);

        TryValidateModel(result.gamingHeadphonesAndHeadsetToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        _service.GamingHeadphonesAndHeadsetService.SaveChangesForPatch(result.gamingHeadphonesAndHeadsetToPatch,
        result.gamingHeadphonesAndHeadsetEntity);
        return NoContent();
    }


}
