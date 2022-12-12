using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.NetworkingTechParams;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDecivesTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.NetworkingLinkParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.SmartDevicesLinkParams;
using ComputerTechAPI_RequestActions.FilteringActions;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;

namespace ComputerTechAPI_RequestActions.Controllers.SmartDevicesControllers;

[Route("api/products/{productId}/drones")]
[ApiController]
public class DroneController : ControllerBase
{
    private readonly IServiceManager _service;
    public DroneController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all Drones  
    /// </summary>
    /// <returns>Drones list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetDronesForProductAsync(Guid productId,
      [FromQuery] DroneParams droneParams)
    {
        var dronelinkParams = new DroneLinkParameters(droneParams, HttpContext);

        var result = await _service.DroneService.GetDronesAsync(productId,
            dronelinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the Drone by Id only
    /// </summary>
    /// <returns>Drone</returns>
    [HttpGet("{id:guid}", Name = "GetDroneForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetDroneForProductAsync(Guid productId, Guid id)
    {
        var drone = await _service.DroneService.GetDroneAsync(productId, id, trackChanges: false);
        return Ok(drone);
    }

    /// <summary>
    /// Create the Drone 
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="droneCreate"></param>
    /// <returns>A newly created Drone</returns>
    /// <response code="201">Returns the newly created Drone</response>
    /// <response code="400">If the Drone is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateDroneForProductAsync(Guid productId, [FromBody] DroneCreateDTO droneCreate)
    {
        if (droneCreate is null)
            return BadRequest("DroneCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var droneToReturn =
        await _service.DroneService.CreateDroneForProductAsync(productId, droneCreate, trackChanges:
        false);
        return CreatedAtRoute("GetDroneForProduct", new
        {
            productId,
            id = droneToReturn.Id
        },
        droneToReturn);
    }

    /// <summary>
    /// Delete the Drone by Id
    /// </summary>
    /// <returns>Delete Drone item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteDroneForProductAsync(Guid productId, Guid id)
    {
        await _service.DroneService.DeleteDroneForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the Drone by Id
    /// </summary>
    /// <returns>Update Drone item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateDroneForProductAsync(Guid productId, Guid id,
        [FromBody] DroneUpdateDTO droneUpdate)
    {
        if (droneUpdate is null)
            return BadRequest("DroneUpdateDTO object is null");

        await _service.DroneService.UpdateDroneForProductAsync(productId, id, droneUpdate,
            productTrackChanges: false, droneTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the Drone by Id
    /// </summary>
    /// <returns>Patch Drone item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateDroneForProductAsync(Guid productId, Guid id, [FromBody]
    JsonPatchDocument<DroneUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = await _service.DroneService.GetDroneForPatchAsync(productId, id,
        productTrackChanges: false,
        droneTrackChanges: true);
        patchDoc.ApplyTo(result.droneToPatch, ModelState);

        TryValidateModel(result.droneToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.DroneService.SaveChangesForPatchAsync(result.droneToPatch,
       result.droneEntity);
        return NoContent();
    }
}
