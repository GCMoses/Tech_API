using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.AccessoriesController;

[Route("api/products/{productId}/gamingmouse")]
[ApiController]
public class GamingMouseController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingMouseController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGamingMouseForProduct(Guid productId)
    {
        var gamingMouse = _service.GamingMouseService.GetGamingMouses(productId, trackChanges: false);
        return Ok(gamingMouse);
    }

    [HttpGet("{id:guid}", Name = "GetGamingMouseForProduct")]
    public IActionResult GetGamingMouseForProduct(Guid productId, Guid id)
    {
        var gamingMouse = _service.GamingMouseService.GetGamingMouse(productId, id, trackChanges: false);
        return Ok(gamingMouse);
    }



    [HttpPost]
    public IActionResult CreateGamingMouseForProduct(Guid productId, [FromBody] GamingMouseCreateDTO gamingMouseCreate)
    {
        if (gamingMouseCreate is null)
            return BadRequest("GamingMouseCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var gamingMouseToReturn =
        _service.GamingMouseService.CreateGamingMouseForProduct(productId, gamingMouseCreate, trackChanges:
        false);
        return CreatedAtRoute("GetGamingMouseForProduct", new
        {
            productId,
            id = gamingMouseToReturn.Id
        },
        gamingMouseToReturn);
    }



    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGamingMouseForProduct(Guid productId, Guid id)
    {
        _service.GamingMouseService.DeleteGamingMouseForProduct(productId, id, trackChanges:
        false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateGamingMouseForProduct(Guid productId, Guid id,
        [FromBody] GamingMouseUpdateDTO gamingMouseUpdate)
    {
        if (gamingMouseUpdate is null)
            return BadRequest("GamingMouseUpdateDTO object is null");

        _service.GamingMouseService.UpdateGamingMouseForProduct(productId, id, gamingMouseUpdate,
            productTrackChanges: false, gamingMouseTrackChanges: true);

        return NoContent();
    }



    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateGamingMouseForProduct(Guid productId, Guid id, [FromBody] 
    JsonPatchDocument<GamingMouseUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.GamingMouseService.GetGamingMouseForPatch(productId, id,
        productTrackChanges: false,
        gamingMouseTrackChanges: true);
        patchDoc.ApplyTo(result.gamingMouseToPatch, ModelState);

        TryValidateModel(result.gamingMouseToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.GamingMouseService.SaveChangesForPatch(result.gamingMouseToPatch,
        result.gamingMouseEntity);
        return NoContent();
    }
}
