using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCControllers;

[Route("api/products/{productId}/laptop")]
[ApiController]
public class LaptopController : ControllerBase
{
    private readonly IServiceManager _service;
    public LaptopController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetLaptopsForProduct(Guid productId)
    {
        var laptops = _service.LaptopService.GetLaptops(productId, trackChanges: false);
        return Ok(laptops);
    }

    [HttpGet("{id:guid}", Name = "LaptopById")]
    public IActionResult GetLaptopForProduct(Guid productId, Guid id)
    {
        var laptop = _service.LaptopService.GetLaptop(productId, id, trackChanges: false);
        return Ok(laptop);
    }
}
