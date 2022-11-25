using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.AccessoriesController;

[Route("api/products/{productId}/gamingkeyboard")]
[ApiController]
public class GamingKeyboardController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingKeyboardController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGamingKeyboardForProduct(Guid productId)
    {
        var gamingKeyboard = _service.GamingKeyboardService.GetGamingKeyboards(productId, trackChanges: false);
        return Ok(gamingKeyboard);
    }


    [HttpGet("{id:guid}", Name = "GetGamingKeyboardForProduct")]
    public IActionResult GetGamingKeyboardForProduct(Guid productId, Guid id)
    {
        var gamingKeyboard = _service.GamingKeyboardService.GetGamingKeyboard(productId, id, trackChanges: false);
        return Ok(gamingKeyboard);
    }

    [HttpPost]
    public IActionResult CreateGamingKeyboardForProduct(Guid productId, [FromBody] GamingKeyboardCreateDTO gamingKeyboardCreate)
    {
        if (gamingKeyboardCreate is null)
            return BadRequest("GamingKeyboardCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var gamingKeyboardToReturn =
        _service.GamingKeyboardService.CreateGamingKeyboardForProduct(productId, gamingKeyboardCreate, trackChanges:
        false);
        return CreatedAtRoute("GetGamingKeyboardForProduct", new
        {
            productId,
            id = gamingKeyboardToReturn.Id
        },
        gamingKeyboardToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGamingKeyboardForProduct(Guid productId, Guid id)
    {
        _service.GamingKeyboardService.DeleteGamingKeyboardForProduct(productId, id, trackChanges:
        false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateGamingKeyboardForProduct(Guid productId, Guid id,
        [FromBody] GamingKeyboardUpdateDTO gamingKeyboardUpdate)
    {
        if (gamingKeyboardUpdate is null)
            return BadRequest("GamingKeyboardUpdateDTO object is null");

        _service.GamingKeyboardService.UpdateGamingKeyboardForProduct(productId, id, gamingKeyboardUpdate,
            productTrackChanges: false, gamingKeyboardTrackChanges: true);

        return NoContent();
    }


    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateGamingKeyboardForProduct(Guid productId, Guid id, [FromBody] 
    JsonPatchDocument<GamingKeyboardUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.GamingKeyboardService.GetGamingKeyboardForPatch(productId, id,
        productTrackChanges: false,
        gamingKeyboardTrackChanges: true);
        patchDoc.ApplyTo(result.gamingKeyboardToPatch, ModelState);

        TryValidateModel(result.gamingKeyboardToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.GamingKeyboardService.SaveChangesForPatch(result.gamingKeyboardToPatch,
        result.gamingKeyboardEntity);
        return NoContent();
    }
}
