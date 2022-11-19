using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/hdd")]
[ApiController]
public class HDDController : ControllerBase
{
    private readonly IServiceManager _service;
    public HDDController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetHDDsForProduct(Guid productId)
    {
        var hdds = _service.HDDService.GetHDDs(productId, trackChanges: false);
        return Ok(hdds);
    }

    [HttpGet("{id:guid}", Name = "HDDById")]
    public IActionResult GetHDDForProduct(Guid productId, Guid id)
    {
        var hdd = _service.HDDService.GetHDD(productId, id, trackChanges: false);
        return Ok(hdd);
    }
}
