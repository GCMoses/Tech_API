using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDevicesParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.SmartDevicesLinkParams;
using ComputerTechAPI_RequestActions.FilteringActions;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;

namespace ComputerTechAPI_RequestActions.Controllers.SmartDevicesControllers;

[Route("api/products/{productId}/smartphones")]
[ApiController]
public class SmartPhoneController : ControllerBase
{
    private readonly IServiceManager _service;
    public SmartPhoneController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all SmartPhones  
    /// </summary>
    /// <returns>SmartPhones list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetSmartPhonesForProductAsync(Guid productId,
      [FromQuery] SmartPhoneParams smartPhonesParams)
    {
        var smartPhoneLinkParams = new SmartPhoneLinkParameters(smartPhonesParams, HttpContext);

        var result = await _service.SmartPhoneService.GetSmartPhonesAsync(productId,
            smartPhoneLinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the SmartPhone by Id only
    /// </summary>
    /// <returns>SmartPhone</returns>
    [HttpGet("{id:guid}", Name = "GetSmartPhoneForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetSmartPhoneForProductAsync(Guid productId, Guid id)
    {
        var smartPhone = await _service.SmartPhoneService.GetSmartPhoneAsync(productId, id, trackChanges: false);
        return Ok(smartPhone);
    }

    /// <summary>
    /// Create the SmartPhone 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="smartPhoneCreate"></param>
    /// <returns>A newly created SmartPhone</returns>
    /// <response code="201">Returns the newly created SmartPhone</response>
    /// <response code="400">If the SmartPhone is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateSmartPhoneForProductAsync(Guid productId, [FromBody] SmartPhoneCreateDTO smartPhoneCreate)
    {
        if (smartPhoneCreate is null)
            return BadRequest("SmartPhoneCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var smartPhoneToReturn =
        await _service.SmartPhoneService.CreateSmartPhoneForProductAsync(productId, smartPhoneCreate, trackChanges:
        false);
        return CreatedAtRoute("GetSmartPhoneForProduct", new
        {
            productId,
            id = smartPhoneToReturn.Id
        },
        smartPhoneToReturn);
    }

    /// <summary>
    /// Delete the SmartPhone by Id
    /// </summary>
    /// <returns>Delete SmartPhone item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteSmartPhoneForProductAsync(Guid productId, Guid id)
    {
       await _service.SmartPhoneService.DeleteSmartPhoneForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the SmartPhone by Id
    /// </summary>
    /// <returns>Update SmartPhone item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateSmartPhoneForProductAsync(Guid productId, Guid id,
        [FromBody] SmartPhoneUpdateDTO smartPhoneUpdate)
    {
        if (smartPhoneUpdate is null)
            return BadRequest("SmartPhoneUpdateDTO object is null");

       await _service.SmartPhoneService.UpdateSmartPhoneForProductAsync(productId, id, smartPhoneUpdate,
            productTrackChanges: false, smartPhoneTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the SmartPhone by Id
    /// </summary>
    /// <returns>Patch SmartPhone item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateSmartPhoneForProductAsync(Guid productId, Guid id, [FromBody]
    JsonPatchDocument<SmartPhoneUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = await _service.SmartPhoneService.GetSmartPhoneForPatchAsync(productId, id,
        productTrackChanges: false,
        smartPhoneTrackChanges: true);
        patchDoc.ApplyTo(result.smartPhoneToPatch, ModelState);

        TryValidateModel(result.smartPhoneToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
         await _service.SmartPhoneService.SaveChangesForPatchAsync(result.smartPhoneToPatch,
        result.smartPhoneEntity);
        return NoContent();
    }
}