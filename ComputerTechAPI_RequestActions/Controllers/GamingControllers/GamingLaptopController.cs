using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.GamingController;

[Route("api/products/{productId}/gaminglaptop")]
[ApiController]
public class GamingLaptopController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingLaptopController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGamingLaptopsForProduct(Guid productId)
    {
        var gamingLaptops = _service.GamingLaptopService.GetGamingLaptops(productId, trackChanges: false);
        return Ok(gamingLaptops);
    }

    [HttpGet("{id:guid}", Name = "GamingLaptopById")]
    public IActionResult GetGamingLaptopForProduct(Guid productId, Guid id)
    {
        var gamingLaptop = _service.GamingLaptopService.GetGamingLaptop(productId, id, trackChanges: false);
        return Ok(gamingLaptop);
    }
}
