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

[Route("api/products/{productId}/hdds")]
[ApiController]
public class HDDController : ControllerBase
{
    private readonly IServiceManager _service;
    public HDDController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all HDDs 
    /// </summary>
    /// <returns>HDDs list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetHDDsForProductAsync(Guid productId,
   [FromQuery] HDDParams hddParams)
    {
        var hddlinkParams = new HDDLinkParameters(hddParams, HttpContext);

        var result = await _service.HDDService.GetHDDsAsync(productId,
            hddlinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the HDD by Id only
    /// </summary>
    /// <returns>HDD</returns>
    [HttpGet("{id:guid}", Name = "GetHDDForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetHDDForProductAsync(Guid productId, Guid id)
    {
        var hdd = await _service.HDDService.GetHDDAsync(productId, id, trackChanges: false);
        return Ok(hdd);
    }

    /// <summary>
    /// Create the HDD
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="hddCreate"></param>
    /// <returns>A newly created HDD</returns>
    /// <response code="201">Returns the newly created HDD</response>
    /// <response code="400">If the HDD is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateHDDForProductAsync(Guid productId, [FromBody] HDDCreateDTO hddCreate)
    {
        if (hddCreate is null)
            return BadRequest("HDDCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var hddToReturn =
        await _service.HDDService.CreateHDDForProductAsync(productId, hddCreate, trackChanges:
        false);
        return CreatedAtRoute("GetHDDForProduct", new
        {
            productId, id = hddToReturn.Id
        },
        hddToReturn);
    }


    /// <summary>
    /// Delete the HDD by Id
    /// </summary>
    /// <returns>Delete HDD item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteHDDForProduct(Guid productId, Guid id)
    {
        await _service.HDDService.DeleteHDDForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the HDD by Id
    /// </summary>
    /// <returns>Update HDD item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateHDDForProductAsync(Guid productId, Guid id,
        [FromBody] HDDUpdateDTO hddUpdate)
    {
        if (hddUpdate is null)
            return BadRequest("HDDUpdateDTO object is null");

        await _service.HDDService.UpdateHDDForProductAsync(productId, id, hddUpdate,
            productTrackChanges: false, hddTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the HDD by Id
    /// </summary>
    /// <returns>Patch HDD item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateHDDForProductAsync(Guid productId, Guid id,[FromBody] 
    JsonPatchDocument<HDDUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = await _service.HDDService.GetHDDForPatchAsync(productId, id,
        productTrackChanges: false,
        hddTrackChanges: true);
        patchDoc.ApplyTo(result.hddToPatch, ModelState);

        TryValidateModel(result.hddToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.HDDService.SaveChangesForPatchAsync(result.hddToPatch,
        result.hddEntity);
        return NoContent();
    }
}
