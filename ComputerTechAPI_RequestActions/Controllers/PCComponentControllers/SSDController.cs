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

[Route("api/products/{productId}/ssds")]
[ApiController]
public class SSDController : ControllerBase
{
    private readonly IServiceManager _service;
    public SSDController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all SSDs 
    /// </summary>
    /// <returns>SSDs list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetSSDsForProductAsync(Guid productId,
     [FromQuery] SSDParams ssdParams)
    {
        var ssdlinkParams = new SSDLinkParameters(ssdParams, HttpContext);

        var result = await _service.SSDService.GetSSDsAsync(productId,
            ssdlinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the SSD by Id only
    /// </summary>
    /// <returns>SSD</returns>
    [HttpGet("{id:guid}", Name = "GetSSDForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetSSDForProductAsync(Guid productId, Guid id)
    {
        var ssd = await _service.SSDService.GetSSDAsync(productId, id, trackChanges: false);
        return Ok(ssd);
    }

    /// <summary>
    /// Create the SSD
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="ssdCreate"></param>
    /// <returns>A newly created SSD</returns>
    /// <response code="201">Returns the newly created SSD</response>
    /// <response code="400">If the SSD is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateSSDForProductAsync(Guid productId, [FromBody] SSDCreateDTO ssdCreate)
    {
        if (ssdCreate is null)
            return BadRequest("SSDCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var ssdToReturn =
        await _service.SSDService.CreateSSDForProductAsync(productId, ssdCreate, trackChanges:
        false);
        return CreatedAtRoute("GetSSDForProduct", new
        {
            productId,
            id =
        ssdToReturn.Id
        },
        ssdToReturn);
    }

    /// <summary>
    /// Delete the SSD by Id
    /// </summary>
    /// <returns>Delete SSD item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteSSDForProductAsync(Guid productId, Guid id)
    {
        await _service.SSDService.DeleteSSDForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the SSD by Id
    /// </summary>
    /// <returns>Update SSD item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateSSDForProductAsync(Guid productId, Guid id,
        [FromBody] SSDUpdateDTO ssdUpdate)
    {
        if (ssdUpdate is null)
            return BadRequest("SSDUpdateDTO object is null");

        await _service.SSDService.UpdateSSDForProductAsync(productId, id, ssdUpdate,
            productTrackChanges: false, ssdTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the SSD by Id
    /// </summary>
    /// <returns>Patch SSD item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateSSDForProductAsync(Guid productId, Guid id, [FromBody]
    JsonPatchDocument<SSDUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = await _service.SSDService.GetSSDForPatchAsync(productId, id,
        productTrackChanges: false,
        ssdTrackChanges: true);
        patchDoc.ApplyTo(result.ssdToPatch, ModelState);

        TryValidateModel(result.ssdToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
         await _service.SSDService.SaveChangesForPatchAsync(result.ssdToPatch,
        result.ssdEntity);
        return NoContent();
    }
}
