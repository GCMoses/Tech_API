using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.AccessoriesLinkParams;
using ComputerTechAPI_RequestActions.FilteringActions;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;

namespace ComputerTechAPI_RequestActions.Controllers.AccessoriesController;

[Route("api/products/{productId}/gamingkeyboards")]
[ApiController]
public class GamingKeyboardController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingKeyboardController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all Keyboards
    /// </summary>
    /// <returns>Keyboards list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetGamingKeyboardsForProductAsync(Guid productId,
     [FromQuery] GamingKeyboardParams gamingKeyboardParams)
    {
        var linkParams = new GamingKeyboardLinkParameters(gamingKeyboardParams, HttpContext);

        var result = await _service.GamingKeyboardService.GetGamingKeyboardsAsync(productId,
            linkParams, trackChanges: false);
            
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the Keyboard by Id only
    /// </summary>
    /// <returns>Keyboard </returns>
    [HttpGet("{id:guid}", Name = "GetGamingKeyboardForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetGamingKeyboardForProductAsync(Guid productId, Guid id)
    {
        var gamingKeyboard = await _service.GamingKeyboardService.GetGamingKeyboardAsync(productId, id, trackChanges: false);
        return Ok(gamingKeyboard);
    }


    /// <summary>
    /// Create the Keyboard 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="gamingKeyboard"></param>
    /// <returns>A newly created Keyboard</returns>
    /// <response code="201">Returns the newly created Keyboard</response>
    /// <response code="400">If the Keyboard is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateGamingKeyboardForProductAsync
        (Guid productId, [FromBody] GamingKeyboardCreateDTO gamingKeyboard)
    {
        var gamingKeyboardToReturn = await _service.GamingKeyboardService.CreateGamingKeyboardForProductAsync(productId, gamingKeyboard,
            trackChanges: false);

        return CreatedAtRoute("GetGamingKeyboardForProduct", new { productId, id = gamingKeyboardToReturn.Id },
            gamingKeyboardToReturn);
    }

    /// <summary>
    /// Delete the Keyboard by Id
    /// </summary>
    /// <returns>Delete Keyboard item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteKeyboardForProductAsync(Guid productId, Guid id)
    {
        await _service.GamingKeyboardService.DeleteGamingKeyboardForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }


    /// <summary>
    /// Update the Keyboard by Id
    /// </summary>
    /// <returns>Update Keyboard item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateGamingKeyboardForProductAsync(Guid productId, Guid id,
        [FromBody] GamingKeyboardUpdateDTO gamingKeyboard)
    {
        await _service.GamingKeyboardService.UpdateGamingKeyboardForProductAsync(productId, id, gamingKeyboard,
            productTrackChanges: false, gamingKeyboardTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the Keyboard by Id
    /// </summary>
    /// <returns>Patch Keyboard item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateGamingKeyboardForProductAsync(Guid productId, Guid id,
        [FromBody] JsonPatchDocument<GamingKeyboardUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.GamingKeyboardService.GetGamingKeyboardForPatchAsync(productId, id,
            productTrackChanges: false, gamingKeyboardTrackChanges: true);

        patchDoc.ApplyTo(result.gamingKeyboardToPatch, ModelState);

        TryValidateModel(result.gamingKeyboardToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.GamingKeyboardService.SaveChangesForPatchAsync(result.gamingKeyboardToPatch, result.gamingKeyboardEntity);

        return NoContent();
    }
}
