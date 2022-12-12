using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_RequestActions.FilteringActions;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/psus")]
[ApiController]
public class PSUController : ControllerBase
{
    private readonly IServiceManager _service;
    public PSUController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all PSUs 
    /// </summary>
    /// <returns>PSUs list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]

    public async Task<IActionResult> GetPSUsForProductAsync(Guid productId,
    [FromQuery] PSUParams psuParams)
    {
        var psulinkParams = new PSULinkParameters(psuParams, HttpContext);

        var result = await _service.PSUService.GetPSUsAsync(productId,
            psulinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the PSU by Id only
    /// </summary>
    /// <returns>PSU</returns>
    [HttpGet("{id:guid}", Name = "GetPSUForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetPSUForProductAsync(Guid productId, Guid id)
    {
        var psu = await _service.PSUService.GetPSUAsync(productId, id, trackChanges: false);
        return Ok(psu);
    }

    /// <summary>
    /// Create the PSU
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="psuCreate"></param>
    /// <returns>A newly created PSU</returns>
    /// <response code="201">Returns the newly created PSU</response>
    /// <response code="400">If the PSU is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreatePSUForProductAsync(Guid productId, [FromBody] PSUCreateDTO psuCreate)
    {
        if (psuCreate is null)
            return BadRequest("PSUCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var psuToReturn =
        await _service.PSUService.CreatePSUForProductAsync(productId, psuCreate, trackChanges: false);
        return CreatedAtRoute("GetPSUForProduct", new
        {
            productId, id = psuToReturn.Id
        },
        psuToReturn);
    }

    /// <summary>
    /// Delete the PSU by Id
    /// </summary>
    /// <returns>Delete PSU item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeletePSUForProductAsync(Guid productId, Guid id)
    {
        await _service.PSUService.DeletePSUForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the PSU by Id
    /// </summary>
    /// <returns>Update PSU item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public async Task<IActionResult> UpdatePSUForProductAsync(Guid productId, Guid id,
        [FromBody] PSUUpdateDTO psuUpdate)
    {
        if (psuUpdate is null)
            return BadRequest("PSUUpdateDTO object is null");

        await _service.PSUService.UpdatePSUForProductAsync(productId, id, psuUpdate,
            productTrackChanges: false, psuTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the PSU by Id
    /// </summary>
    /// <returns>Patch PSU item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdatePSUForProductAsync(Guid productId, Guid id, [FromBody]
    JsonPatchDocument<PSUUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = await _service.PSUService.GetPSUForPatchAsync(productId, id,
        productTrackChanges: false, psuTrackChanges: true);
        patchDoc.ApplyTo(result.psuToPatch, ModelState);

        TryValidateModel(result.psuToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.PSUService.SaveChangesForPatchAsync(result.psuToPatch,
        result.psuEntity);
        return NoContent();
    }
}
