using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.GamingTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.GamingLinkParams;
using ComputerTechAPI_RequestActions.FilteringActions;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;

namespace ComputerTechAPI_RequestActions.Controllers.GamingController;

[Route("api/products/{productId}/gamingconsoles")]
[ApiController]
public class GamingConsoleController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingConsoleController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all Consoles  
    /// </summary>
    /// <returns>Consoles list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetGamingConsolesForProductAsync(Guid productId,
     [FromQuery] GamingConsoleParams gamingConsoleParams)
    {
        var gamingConsolelinkParams = new GamingConsoleLinkParameters(gamingConsoleParams, HttpContext);

        var result = await _service.GamingConsoleService.GetGamingConsolesAsync(productId,
            gamingConsolelinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the Console by Id only
    /// </summary>
    /// <returns>Console</returns>
    [HttpGet("{id:guid}", Name = "GetGamingConsoleForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetGamingConsoleForProductAsync(Guid productId, Guid id)
    {
        var gamingConsole = await _service.GamingConsoleService.GetGamingConsoleAsync(productId, id, trackChanges: false);
        return Ok(gamingConsole);
    }

    /// <summary>
    /// Create the Console 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name = "gamingConsole"></param>
    /// <returns>A newly created Desktop</returns>
    /// <response code="201">Returns the newly created Desktop</response>
    /// <response code="400">If the Desktop is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateGamingConsoleForProductAsync
        (Guid productId, [FromBody] GamingConsoleCreateDTO gamingConsole)
    {
        var gamingConsoleToReturn = await _service.GamingConsoleService.CreateGamingConsoleForProductAsync(productId, gamingConsole,
            trackChanges: false);

        return CreatedAtRoute("GetGamingConsoleForProduct", new { productId, id = gamingConsoleToReturn.Id },
            gamingConsoleToReturn);
    }

    /// <summary>
    /// Delete the Console by Id
    /// </summary>
    /// <returns>Delete Console item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteGamingConsoleForProductAsync(Guid productId, Guid id)
    {
        await _service.GamingConsoleService.DeleteGamingConsoleForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the Console by Id
    /// </summary>
    /// <returns>Update Console item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateGamingConsoleForProductAsync(Guid productId, Guid id,
        [FromBody] GamingConsoleUpdateDTO gamingConsole)
    {
        await _service.GamingConsoleService.UpdateGamingConsoleForProductAsync(productId, id, gamingConsole,
            productTrackChanges: false, gamingConsoleTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the Console by Id
    /// </summary>
    /// <returns>Patch Console item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateGamingConsoleForProductAsync(Guid productId, Guid id,
        [FromBody] JsonPatchDocument<GamingConsoleUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.GamingConsoleService.GetGamingConsoleForPatchAsync(productId, id,
            productTrackChanges: false, gamingConsoleTrackChanges: true);

        patchDoc.ApplyTo(result.gamingConsoleToPatch, ModelState);

        TryValidateModel(result.gamingConsoleToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.GamingConsoleService.SaveChangesForPatchAsync(result.gamingConsoleToPatch, result.gamingConsoleEntity);

        return NoContent();
    }
}
