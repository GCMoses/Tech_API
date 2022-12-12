using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.AccessoriesLinkParams;
using ComputerTechAPI_RequestActions.FilteringActions;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ComputerTechAPI_RequestActions.Controllers.AccessoriesController;

[Route("api/products/{productId}/gamingheadphonesandheadsets")]
[ApiController]
public class GamingHeadphonesAndHeadsetController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingHeadphonesAndHeadsetController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets the list of all GamingHeadphonesAndHeadsets
    /// </summary>
    /// <returns>The GamingHeadphonesAndHeadsets list</returns>   
    [HttpGet]
    [HttpHead]
    [Authorize()]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public async Task<IActionResult> GetGamingHeadphonesAndHeadsetsForProductAsync(Guid productId,
     [FromQuery] GamingHeadphonesAndHeadsetParams gamingHeadphonesAndHeadsetParams)
    {
        var gamingHeadphonesAndHeadsetlinkParams = new GamingHeadphonesAndHeadsetLinkParameters(gamingHeadphonesAndHeadsetParams, HttpContext);

        var result = await _service.GamingHeadphonesAndHeadsetService.GetGamingHeadphonesAndHeadsetsAsync(productId,
            gamingHeadphonesAndHeadsetlinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the Headset by Id only
    /// </summary>
    /// <returns>Headset</returns>
    [HttpGet("{id:guid}", Name = "GetGamingHeadphonesAndHeadsetForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetGamingHeadphonesAndHeadsetForProductAsync(Guid productId, Guid id)
    {
        var gamingHeadphonesAndHeadset = await _service.GamingHeadphonesAndHeadsetService.GetGamingHeadphonesAndHeadsetAsync(productId, id, trackChanges: false);
        return Ok(gamingHeadphonesAndHeadset);
    }


    /// <summary>
    /// Create the gaming headset 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="gamingHeadphonesAndHeadset"></param>
    /// <returns>A newly created Headset</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateGamingHeadphonesAndHeadsetForProductAsync
        (Guid productId, [FromBody] GamingHeadphonesAndHeadsetCreateDTO gamingHeadphonesAndHeadset)
    {
        var gamingHeadphonesAndHeadsetToReturn = await _service.GamingHeadphonesAndHeadsetService.
            CreateGamingHeadphonesAndHeadsetForProductAsync(productId, gamingHeadphonesAndHeadset,
            trackChanges: false);

        return CreatedAtRoute("GetGamingHeadphonesAndHeadsetForProduct", new { productId, id = gamingHeadphonesAndHeadsetToReturn.Id },
            gamingHeadphonesAndHeadsetToReturn);
    }

    /// <summary>
    /// Delete the headset by Id
    /// </summary>
    /// <returns>Delete headset item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteGamingHeadphonesAndHeadsetForProductAsync(Guid productId, Guid id)
    {
        await _service.GamingHeadphonesAndHeadsetService.DeleteGamingHeadphonesAndHeadsetForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }


    /// <summary>
    /// Update the headset item
    /// </summary>
    /// <returns>Delete headset item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateGamingHeadphonesAndHeadsetForProductAsync(Guid productId, Guid id,
        [FromBody] GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadset)
    {
        await _service.GamingHeadphonesAndHeadsetService.UpdateGamingHeadphonesAndHeadsetForProductAsync(productId, id, gamingHeadphonesAndHeadset,
            productTrackChanges: false, gamingHeadphonesAndHeadsetTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the headset by Id
    /// </summary>
    /// <returns>Patch headset item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateGamingHeadphonesAndHeadsetForProductAsync(Guid productId, Guid id,
        [FromBody] JsonPatchDocument<GamingHeadphonesAndHeadsetUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.GamingHeadphonesAndHeadsetService.GetGamingHeadphonesAndHeadsetForPatchAsync(productId, id,
            productTrackChanges: false, gamingHeadphonesAndHeadsetTrackChanges: true);

        patchDoc.ApplyTo(result.gamingHeadphonesAndHeadsetToPatch, ModelState);

        TryValidateModel(result.gamingHeadphonesAndHeadsetToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.GamingHeadphonesAndHeadsetService.SaveChangesForPatchAsync(result.gamingHeadphonesAndHeadsetToPatch, result.gamingHeadphonesAndHeadsetEntity);

        return NoContent();
    }
}
