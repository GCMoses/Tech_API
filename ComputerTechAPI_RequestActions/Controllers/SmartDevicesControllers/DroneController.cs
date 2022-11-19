using ComputerTechAPI_TechService.Contracts;
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

    [HttpGet("{id:guid}", Name = "DroneById")]
    public IActionResult GetDroneForProduct(Guid productId, Guid id)
    {
        var drone = _service.DroneService.GetDrone(productId, id, trackChanges: false);
        return Ok(drone);
    }
}
