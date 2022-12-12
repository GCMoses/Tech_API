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

[Route("api/products/{productId}/laptops")]
[ApiController]
public class LaptopController : ControllerBase
{
    private readonly IServiceManager _service;
    public LaptopController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all Laptops  
    /// </summary>
    /// <returns>Laptops list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetLaptopsForProductAsync(Guid productId,
      [FromQuery] LaptopParams laptopParams)
    {
        var laptoplinkParams = new LaptopLinkParameters(laptopParams, HttpContext);

        var result = await _service.LaptopService.GetLaptopsAsync(productId,
            laptoplinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the Laptop by Id only
    /// </summary>
    /// <returns>Laptop</returns>
    [HttpGet("{id:guid}", Name = "GetLaptopForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetLaptopForProductAsync(Guid productId, Guid id)
    {
        var laptop = await _service.LaptopService.GetLaptopAsync(productId, id, trackChanges: false);
        return Ok(laptop);
    }

    /// <summary>
    /// Create the Laptop 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="laptop"></param>
    /// <returns>A newly created Laptop</returns>
    /// <response code="201">Returns the newly created Laptop</response>
    /// <response code="400">If the Laptop is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateLaptopForProductAsync
        (Guid productId, [FromBody] LaptopCreateDTO laptop)
    {
        var laptopToReturn = await _service.LaptopService.CreateLaptopForProductAsync(productId, laptop,
            trackChanges: false);

        return CreatedAtRoute("GetLaptopForProduct", new { productId, id = laptopToReturn.Id },
            laptopToReturn);
    }

    /// <summary>
    /// Delete the Laptop by Id
    /// </summary>
    /// <returns>Delete Laptop item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteLaptopForProductAsync(Guid productId, Guid id)
    {
        await _service.LaptopService.DeleteLaptopForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the Laptop by Id
    /// </summary>
    /// <returns>Update Laptop item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateLaptopForForProductAsync(Guid productId, Guid id,
        [FromBody] LaptopUpdateDTO laptop)
    {
        await _service.LaptopService.UpdateLaptopForProductAsync(productId, id, laptop,
            productTrackChanges: false, laptopTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the Laptop by Id
    /// </summary>
    /// <returns>Patch Laptop item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateLaptopForProductAsync(Guid productId, Guid id,
        [FromBody] JsonPatchDocument<LaptopUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.LaptopService.GetLaptopForPatchAsync(productId, id,
            productTrackChanges: false, laptopTrackChanges: true);

        patchDoc.ApplyTo(result.laptopToPatch, ModelState);

        TryValidateModel(result.laptopToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.LaptopService.SaveChangesForPatchAsync(result.laptopToPatch, result.laptopEntity);

        return NoContent();
    }
}

