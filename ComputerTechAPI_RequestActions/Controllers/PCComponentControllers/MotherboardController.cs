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

[Route("api/products/{productId}/motherboards")]
[ApiController]
public class MotherboardController : ControllerBase
{
    private readonly IServiceManager _service;
    public MotherboardController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all Motherboards 
    /// </summary>
    /// <returns>Motherboards list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]   
    public async Task<IActionResult> GetMotherboardsForProductAsync(Guid productId,
    [FromQuery] MotherboardParams motherboardParams)
    {
        var motherboardlinkParams = new MotherboardLinkParameters(motherboardParams, HttpContext);

        var result = await _service.MotherboardService.GetMotherboardsAsync(productId,
            motherboardlinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the Motherboard by Id only
    /// </summary>
    /// <returns>Motherboard</returns>
    [HttpGet("{id:guid}", Name = "GetMotherboardForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetMotherboardForProductAsync(Guid productId, Guid id)
    {
        var motherboard = await _service.MotherboardService.GetMotherboardAsync(productId, id, trackChanges: false);
        return Ok(motherboard);
    }

    /// <summary>
    /// Create the RouteMotherboardr
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="motherboardCreate"></param>
    /// <returns>A newly created Motherboard</returns>
    /// <response code="201">Returns the newly created Motherboard</response>
    /// <response code="400">If the Motherboard is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateMotherboardForProductAsync(Guid productId, [FromBody] MotherboardCreateDTO motherboardCreate)
    {
        if (motherboardCreate is null)
            return BadRequest("MotherboardCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var motherboardToReturn =
        await _service.MotherboardService.CreateMotherboardForProductAsync(productId, motherboardCreate, trackChanges:
        false);
        return CreatedAtRoute("GetMotherboardForProduct", new
        {
            productId, id = motherboardToReturn.Id
        },
        motherboardToReturn);
    }


    /// <summary>
    /// Delete the Motherboard by Id
    /// </summary>
    /// <returns>Delete Motherboard item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteMotherboardForProduct(Guid productId, Guid id)
    {
        await _service.MotherboardService.DeleteMotherboardForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the Motherboard by Id
    /// </summary>
    /// <returns>Update Motherboard item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateMotherboardForProductAsync(Guid productId, Guid id,
        [FromBody] MotherboardUpdateDTO motherboardUpdate)
    {
        if (motherboardUpdate is null)
            return BadRequest("MotherboardUpdateDTO object is null");

        await _service.MotherboardService.UpdateMotherboardForProductAsync(productId, id, motherboardUpdate,
            productTrackChanges: false, motherboardTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the Motherboard by Id
    /// </summary>
    /// <returns>Patch Motherboard item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateMotherboardForProductAsync(Guid productId, Guid id, [FromBody]
    JsonPatchDocument<MotherboardUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = await _service.MotherboardService.GetMotherboardForPatchAsync(productId, id,
        productTrackChanges: false,
        motherboardTrackChanges: true);
        patchDoc.ApplyTo(result.motherboardToPatch, ModelState);

        TryValidateModel(result.motherboardToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.MotherboardService.SaveChangesForPatchAsync(result.motherboardToPatch,
        result.motherboardEntity);
        return NoContent();
    }
}
