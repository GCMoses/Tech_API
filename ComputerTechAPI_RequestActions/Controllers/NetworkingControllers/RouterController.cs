using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.NetworkingTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.NetworkingLinkParams;
using ComputerTechAPI_RequestActions.FilteringActions;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;

namespace ComputerTechAPI_RequestActions.Controllers.NetworkingControllers;

[Route("api/products/{productId}/routers")]
[ApiController]
public class RouterController : ControllerBase
{
    private readonly IServiceManager _service;
    public RouterController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all Routers 
    /// </summary>
    /// <returns>Routers list</returns>
    [HttpGet]
    [HttpHead]
    [Authorize()]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public async Task<IActionResult> GetRoutersForProductAsync(Guid productId,
      [FromQuery] RouterParams routerParams)
    {
        var routerlinkParams = new RouterLinkParameters(routerParams, HttpContext);

        var result = await _service.RouterService.GetRoutersAsync(productId,
            routerlinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the Router by Id only
    /// </summary>
    /// <returns>Router</returns>
    [HttpGet("{id:guid}", Name = "GetRouterForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetRouterForProductAsync(Guid productId, Guid id)
    {
        var router = await _service.RouterService.GetRouterAsync(productId, id, trackChanges: false);
        return Ok(router);
    }

    /// <summary>
    /// Create the Router
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="router"></param>
    /// <returns>A newly created Router</returns>
    /// <response code="201">Returns the newly created Router</response>
    /// <response code="400">If the Router is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateRouterForProductAsync
        (Guid productId, [FromBody] RouterCreateDTO router)
    {
        var routerToReturn = await _service.RouterService.CreateRouterForProductAsync(productId, router,
            trackChanges: false);

        return CreatedAtRoute("GetRouterForProduct", new { productId, id = routerToReturn.Id },
            routerToReturn);
    }

    /// <summary>
    /// Delete the Router by Id
    /// </summary>
    /// <returns>Delete Router item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteRouterForProductAsync(Guid productId, Guid id)
    {
        await _service.RouterService.DeleteRouterForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the Router by Id
    /// </summary>
    /// <returns>Update Router item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateRouterForProductAsync(Guid productId, Guid id,
        [FromBody] RouterUpdateDTO router)
    {
        await _service.RouterService.UpdateRouterForProductAsync(productId, id, router,
            productTrackChanges: false, routerTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the Router by Id
    /// </summary>
    /// <returns>Patch Router item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateRouterForProductAsync(Guid productId, Guid id,
        [FromBody] JsonPatchDocument<RouterUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.RouterService.GetRouterForPatchAsync(productId, id,
            productTrackChanges: false, routerTrackChanges: true);

        patchDoc.ApplyTo(result.routerToPatch, ModelState);

        TryValidateModel(result.routerToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.RouterService.SaveChangesForPatchAsync(result.routerToPatch, result.routerEntity);

        return NoContent();
    }
}
