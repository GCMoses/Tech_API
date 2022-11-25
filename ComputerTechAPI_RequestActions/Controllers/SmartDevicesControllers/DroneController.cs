        using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.SmartDevicesControllers;

[Route("api/products/{productId}/drone")]
[ApiController]
public class DroneController : ControllerBase
{
    private readonly IServiceManager _service;
    public DroneController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetDronesForProduct(Guid productId)
    {
        var drones = _service.DroneService.GetDrones(productId, trackChanges: false);
        return Ok(drones);
    }

    [HttpGet("{id:guid}", Name = "GetDroneForProduct")]
    public IActionResult GetDroneForProduct(Guid productId, Guid id)
    {
        var drone = _service.DroneService.GetDrone(productId, id, trackChanges: false);
        return Ok(drone);
    }


    [HttpPost]
    public IActionResult CreateDroneForProduct(Guid productId, [FromBody] DroneCreateDTO droneCreate)
    {
        if (droneCreate is null)
            return BadRequest("DroneCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var droneToReturn =
        _service.DroneService.CreateDroneForProduct(productId, droneCreate, trackChanges:
        false);
        return CreatedAtRoute("GetDroneForProduct", new
        {
            productId,
            id = droneToReturn.Id
        },
        droneToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteDroneForProduct(Guid productId, Guid id)
    {
        _service.DroneService.DeleteDroneForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateDroneForProduct(Guid productId, Guid id,
        [FromBody] DroneUpdateDTO droneUpdate)
    {
        if (droneUpdate is null)
            return BadRequest("DroneUpdateDTO object is null");

        _service.DroneService.UpdateDroneForProduct(productId, id, droneUpdate,
            productTrackChanges: false, droneTrackChanges: true);

        return NoContent();
    }


    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateDroneForProduct(Guid productId, Guid id, [FromBody]
    JsonPatchDocument<DroneUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.DroneService.GetDroneForPatch(productId, id,
        productTrackChanges: false,
        droneTrackChanges: true);
        patchDoc.ApplyTo(result.droneToPatch, ModelState);

        TryValidateModel(result.droneToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.DroneService.SaveChangesForPatch(result.droneToPatch,
        result.droneEntity);
        return NoContent();
    }
}
