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

[Route("api/products/{productId}/gamingdesktops")]
[ApiController]
public class GamingDesktopController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingDesktopController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all Gaming Desktops  
    /// </summary>
    /// <returns>Gaming Desktops list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetGamingDesktopsForProduct(Guid productId,
        [FromQuery] GamingDesktopParams gamingDesktopParams)
    {
        var gamingDesktoplinkParams = new GamingDesktopLinkParameters(gamingDesktopParams, HttpContext);

        var result = await _service.GamingDesktopService.GetGamingDesktopsAsync(productId,
            gamingDesktoplinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the Gaming Desktop by Id only
    /// </summary>
    /// <returns>Gaming Desktop</returns>
    [HttpGet("{id:guid}", Name = "GetGamingDesktopForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetGamingDesktopForProductAsync(Guid productId, Guid id)
    {
        var gamingDesktop = await _service.GamingDesktopService.GetGamingDesktopAsync(productId, id, trackChanges: false);
        return Ok(gamingDesktop);
    }

    /// <summary>
    /// Create the Gaming Desktop 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="gamingDesktop"></param>
    /// <returns>A newly created Gaming Desktop</returns>
    /// <response code="201">Returns the newly created Gaming Desktop</response>
    /// <response code="400">If the Gaming Desktop is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateGamingDesktopForProduct
        (Guid productId, [FromBody] GamingDesktopCreateDTO gamingDesktop)
    {
        var gamingDesktopToReturn = await _service.GamingDesktopService.CreateGamingDesktopForProductAsync(productId, gamingDesktop,
            trackChanges: false);

        return CreatedAtRoute("GetGamingDesktopForProduct", new { productId, id = gamingDesktopToReturn.Id },
            gamingDesktopToReturn);
    }

    /// <summary>
    /// Delete the Gaming Desktop by Id
    /// </summary>
    /// <returns>Delete Gaming Desktop item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteDesktopForProduct(Guid productId, Guid id)
    {
        await _service.GamingDesktopService.DeleteGamingDesktopForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the Gaming Desktop by Id
    /// </summary>
    /// <returns>Update Gaming Desktop item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateGamingDesktopForProductAsync(Guid productId, Guid id,
        [FromBody] GamingDesktopUpdateDTO gamingDesktop)
    {
        await _service.GamingDesktopService.UpdateGamingDesktopForProductAsync(productId, id, gamingDesktop,
            productTrackChanges: false, gamingDesktopTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the Gaming Desktop by Id
    /// </summary>
    /// <returns>Patch Gaming Desktop item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateGamingDesktopForProduct(Guid productId, Guid id,
        [FromBody] JsonPatchDocument<GamingDesktopUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.GamingDesktopService.GetGamingDesktopForPatchAsync(productId, id,
            productTrackChanges: false, gamingDesktopTrackChanges: true);

        patchDoc.ApplyTo(result.gamingDesktopToPatch, ModelState);

        TryValidateModel(result.gamingDesktopToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.GamingDesktopService.SaveChangesForPatchAsync(result.gamingDesktopToPatch, result.gamingDesktopEntity);

        return NoContent();
    }
}