using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCLinkParams;
using ComputerTechAPI_RequestActions.FilteringActions;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;

namespace ComputerTechAPI_RequestActions.Controllers.PCControllers;

[Route("api/products/{productId}/desktops")]
[ApiController]
public class DesktopController : ControllerBase
{
    private readonly IServiceManager _service;
    public DesktopController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all Desktops  
    /// </summary>
    /// <returns>Desktops list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetDesktopsForProductAsync(Guid productId,
      [FromQuery] DesktopParams desktopParams)
    {
        var desktoplinkParams = new DesktopLinkParameters(desktopParams, HttpContext);

        var result = await _service.DesktopService.GetDesktopsAsync(productId,
            desktoplinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the Desktop by Id only
    /// </summary>
    /// <returns>Desktop</returns>
    [HttpGet("{id:guid}", Name = "GetDesktopForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetDesktopForProductAsync(Guid productId, Guid id)
    {
        var desktop = await _service.DesktopService.GetDesktopAsync(productId, id, trackChanges: false);
        return Ok(desktop);
    }

    /// <summary>
    /// Create the Desktop 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="desktop"></param>
    /// <returns>A newly created Desktop</returns>
    /// <response code="201">Returns the newly created Desktop</response>
    /// <response code="400">If the Desktop is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateDesktopForProduct
        (Guid productId, [FromBody] DesktopCreateDTO desktop)
    {
        var desktopToReturn = await _service.DesktopService.CreateDesktopForProductAsync(productId, desktop,
            trackChanges: false);

        return CreatedAtRoute("GetDesktopForProduct", new { productId, id = desktopToReturn.Id },
            desktopToReturn);
    }

    /// <summary>
    /// Delete the Desktop by Id
    /// </summary>
    /// <returns>Delete Desktop item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteDesktopForProductAsync(Guid productId, Guid id)
    {
        await _service.DesktopService.DeleteDesktopForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the Desktop by Id
    /// </summary>
    /// <returns>Update Desktop item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateDesktopForForProductAsync(Guid productId, Guid id,
        [FromBody] DesktopUpdateDTO desktop)
    {
        await _service.DesktopService.UpdateDesktopForProductAsync(productId, id, desktop,
            productTrackChanges: false, desktopTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the Desktop by Id
    /// </summary>
    /// <returns>Patch Desktop item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateDesktopForProductAsync(Guid productId, Guid id,
        [FromBody] JsonPatchDocument<DesktopUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.DesktopService.GetDesktopForPatchAsync(productId, id,
            productTrackChanges: false, desktopTrackChanges: true);

        patchDoc.ApplyTo(result.desktopToPatch, ModelState);

        TryValidateModel(result.desktopToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.DesktopService.SaveChangesForPatchAsync(result.desktopToPatch, result.desktopEntity);

        return NoContent();
    }
}
