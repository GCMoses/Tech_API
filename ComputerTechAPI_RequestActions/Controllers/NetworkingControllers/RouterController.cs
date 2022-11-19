using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.NetworkingControllers;

[Route("api/products/{productId}/router")]
[ApiController]
public class RouterController : ControllerBase
{
    private readonly IServiceManager _service;
    public RouterController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetRoutersForProduct(Guid productId)
    {
        var routers = _service.RouterService.GetRouters(productId, trackChanges: false);
        return Ok(routers);
    }

    [HttpGet("{id:guid}", Name = "RouterById")]
    public IActionResult GetRouterForProduct(Guid productId, Guid id)
    {
        var router = _service.RouterService.GetRouter(productId, id, trackChanges: false);
        return Ok(router);
    }
}
