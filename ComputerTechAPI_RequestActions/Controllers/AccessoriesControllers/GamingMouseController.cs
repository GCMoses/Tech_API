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

[Route("api/products/{productId}/gamingmouses")]
[ApiController]
public class GamingMouseController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingMouseController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets the array of all Mouses  
    /// </summary>
    /// <returns>Mouses list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetGamingMousesForProduct(Guid productId,
      [FromQuery] GamingMouseParams gamingMouseParams)
    {
        var gamingMouselinkParams = new GamingMouseLinkParameters(gamingMouseParams, HttpContext);

        var result = await _service.GamingMouseService.GetGamingMousesAsync(productId,
            gamingMouselinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the Mouse by Id only
    /// </summary>
    /// <returns>Mouse</returns>
    [HttpGet("{id:guid}", Name = "GetGamingMouseForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetGamingMouseForProduct(Guid productId, Guid id)
    {
        var gamingMouse = await _service.GamingMouseService.GetGamingMouseAsync(productId, id, trackChanges: false);
        return Ok(gamingMouse);
    }

    /// <summary>
    /// Create the Mouse 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="gamingMouse"></param>
    /// <returns>A newly created Mouse</returns>
    /// <response code="201">Returns the newly created Mouse</response>
    /// <response code="400">If the Mouse is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateGamingMouseForProductAsync
        (Guid productId, [FromBody] GamingMouseCreateDTO gamingMouse)
    {
        var gamingMouseToReturn = await _service.GamingMouseService.CreateGamingMouseForProductAsync(productId, gamingMouse,
            trackChanges: false);

        return CreatedAtRoute("GetGamingMouseForProduct", new { productId, id = gamingMouseToReturn.Id },
            gamingMouseToReturn);
    }


    /// <summary>
    /// Delete the Mouse by Id
    /// </summary>
    /// <returns>Delete Mouse item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteMouseForProductAsync(Guid productId, Guid id)
    {
        await _service.GamingMouseService.DeleteGamingMouseForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the Mouse by Id
    /// </summary>
    /// <returns>Update Mouse item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateGamingMouseForProductAsync(Guid productId, Guid id,
        [FromBody] GamingMouseUpdateDTO gamingMouse)
    {
        await _service.GamingMouseService.UpdateGamingMouseForProductAsync(productId, id, gamingMouse,
            productTrackChanges: false, gamingMouseTrackChanges: true);

        return NoContent();
    }


    /// <summary>
    /// Partially Update the Mouse by Id
    /// </summary>
    /// <returns>Patch Mouse item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateGamingMouseForProductAsync(Guid productId, Guid id,
        [FromBody] JsonPatchDocument<GamingMouseUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.GamingMouseService.GetGamingMouseForPatchAsync(productId, id,
            productTrackChanges: false, gamingMouseTrackChanges: true);

        patchDoc.ApplyTo(result.gamingMouseToPatch, ModelState);

        TryValidateModel(result.gamingMouseToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.GamingMouseService.SaveChangesForPatchAsync(result.gamingMouseToPatch, result.gamingMouseEntity);

        return NoContent();
    }
}
