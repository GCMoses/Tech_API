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

[Route("api/products/{productId}/rams")]
[ApiController]
public class RAMController : ControllerBase
{
    private readonly IServiceManager _service;
    public RAMController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets the array of all RAMs 
    /// </summary>
    /// <returns>RAMs list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetRAMsForProductAsync(Guid productId,
    [FromQuery] RAMParams ramParams)
    {
        var ramLinkParams = new RAMLinkParameters(ramParams, HttpContext);

        var result = await _service.RAMService.GetRAMsAsync(productId,
            ramLinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the RAM by Id only
    /// </summary>
    /// <returns>RAM</returns>
    [HttpGet("{id:guid}", Name = "GetRAMForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetRAMForProductAsync(Guid productId, Guid id)
    {
        var ram = await _service.RAMService.GetRAMAsync(productId, id, trackChanges: false);
        return Ok(ram);
    }

    /// <summary>
    /// Create the RAM
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="ramCreate"></param>
    /// <returns>A newly created RAM</returns>
    /// <response code="201">Returns the newly created RAM</response>
    /// <response code="400">If the RAM is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateRAMForProductAsync(Guid productId, [FromBody] RAMCreateDTO ramCreate)
    {
        if (ramCreate is null)
            return BadRequest("RAMCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var ramToReturn =
        await _service.RAMService.CreateRAMForProductAsync(productId, ramCreate, trackChanges: false);
        return CreatedAtRoute("GetRAMForProduct", new
        {
            productId, id = ramToReturn.Id
        },
        ramToReturn);
    }

    /// <summary>
    /// Delete the RAM by Id
    /// </summary>
    /// <returns>Delete RAM item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteRAMForProductAsync(Guid productId, Guid id)
    {
        await _service.RAMService.DeleteRAMForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the RAM by Id
    /// </summary>
    /// <returns>Update RAM item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateRAMForProductAsync(Guid productId, Guid id,
        [FromBody] RAMUpdateDTO ramUpdate)
    {
        if (ramUpdate is null)
            return BadRequest("RAMUpdateDTO object is null");

        await _service.RAMService.UpdateRAMForProductAsync(productId, id, ramUpdate,
            productTrackChanges: false, ramTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the RAM by Id
    /// </summary>
    /// <returns>Patch RAM item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateRAMForProductAsync(Guid productId, Guid id, [FromBody]
    JsonPatchDocument<RAMUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = await _service.RAMService.GetRAMForPatchAsync(productId, id,
        productTrackChanges: false,
        ramTrackChanges: true);
        patchDoc.ApplyTo(result.ramToPatch, ModelState);

        TryValidateModel(result.ramToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.RAMService.SaveChangesForPatchAsync(result.ramToPatch,
        result.ramEntity);
        return NoContent();
    }

}
