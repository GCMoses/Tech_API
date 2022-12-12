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

[Route("api/products/{productId}/gaminglaptops")]
[ApiController]
public class GamingLaptopController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingLaptopController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all Gaming Laptops 
    /// </summary>
    /// <returns>Gaming Laptops list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetGamingLaptopsForProduct(Guid productId,
    [FromQuery] GamingLaptopParams gamingLaptopParams)
    {
        var gamingLaptoplinkParams = new GamingLaptopLinkParameters(gamingLaptopParams, HttpContext);

        var result = await _service.GamingLaptopService.GetGamingLaptopsAsync(productId,
            gamingLaptoplinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the Gaming Laptop by Id only
    /// </summary>
    /// <returns>Gaming Laptop</returns>
    [HttpGet("{id:guid}", Name = "GetGamingLaptopForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetGamingLaptopForProduct(Guid productId, Guid id)
    {
        var gamingLaptop = await _service.GamingLaptopService.GetGamingLaptopAsync(productId, id, trackChanges: false);
        return Ok(gamingLaptop);
    }

    /// <summary>
    /// Create the Gaming Laptop 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="gamingLaptop"></param>
    /// <returns>A newly created Gaming Laptop</returns>
    /// <response code="201">Returns the newly created Gaming Laptop</response>
    /// <response code="400">If the Gaming Laptop is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateGamingLaptopForProduct
        (Guid productId, [FromBody] GamingLaptopCreateDTO gamingLaptop)
    {
        var gamingLaptopToReturn = await _service.GamingLaptopService.CreateGamingLaptopForProductAsync(productId, gamingLaptop,
            trackChanges: false);

        return CreatedAtRoute("GetGamingLaptopForProduct", new { productId, id = gamingLaptopToReturn.Id },
            gamingLaptopToReturn);
    }

    /// <summary>
    /// Delete the Gaming Laptop by Id
    /// </summary>
    /// <returns>Delete Gaming Laptop item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteLaptopForProduct(Guid productId, Guid id)
    {
        await _service.GamingLaptopService.DeleteGamingLaptopForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the Gaming Laptop by Id
    /// </summary>
    /// <returns>Update Gaming Laptop item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateGamingLaptopForProductAsync(Guid productId, Guid id,
        [FromBody] GamingLaptopUpdateDTO gamingLaptop)
    {
        await _service.GamingLaptopService.UpdateGamingLaptopForProductAsync(productId, id, gamingLaptop,
            productTrackChanges: false, gamingLaptopTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the Gaming Laptop by Id
    /// </summary>
    /// <returns>Patch Gaming Laptop item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateGamingLaptopForProduct(Guid productId, Guid id,
        [FromBody] JsonPatchDocument<GamingLaptopUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.GamingLaptopService.GetGamingLaptopForPatchAsync(productId, id,
            productTrackChanges: false, gamingLaptopTrackChanges: true);

        patchDoc.ApplyTo(result.gamingLaptopToPatch, ModelState);

        TryValidateModel(result.gamingLaptopToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.GamingLaptopService.SaveChangesForPatchAsync(result.gamingLaptopToPatch, result.gamingLaptopEntity);

        return NoContent();
    }
}
