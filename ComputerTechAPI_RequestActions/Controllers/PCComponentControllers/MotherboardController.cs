using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/motherboard")]
[ApiController]
public class MotherboardController : ControllerBase
{
    private readonly IServiceManager _service;
    public MotherboardController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetMotherboardsForProduct(Guid productId)
    {
        var motherboards = _service.MotherboardService.GetMotherboards(productId, trackChanges: false);
        return Ok(motherboards);
    }

    [HttpGet("{id:guid}", Name = "MotherboardById")]
    public IActionResult GetMotherboardForProduct(Guid productId, Guid id)
    {
        var motherboard = _service.MotherboardService.GetMotherboard(productId, id, trackChanges: false);
        return Ok(motherboard);
    }
}
