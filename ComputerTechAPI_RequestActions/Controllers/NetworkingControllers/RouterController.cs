using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpGet("{id:guid}", Name = "GetRouterForProduct")]
    public IActionResult GetRouterForProduct(Guid productId, Guid id)
    {
        var router = _service.RouterService.GetRouter(productId, id, trackChanges: false);
        return Ok(router);
    }




    [HttpPost]
    public IActionResult CreateRouterForProduct(Guid productId, [FromBody] RouterCreateDTO routerCreate)
    {
        if (routerCreate is null)
            return BadRequest("RouterCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var routerToReturn =
        _service.RouterService.CreateRouterForProduct(productId, routerCreate, trackChanges:
        false);
        return CreatedAtRoute("GetRouterForProduct", new
        {
            productId,
            id =
        routerToReturn.Id
        },
        routerToReturn);
    }



    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRouterForProduct(Guid productId, Guid id)
    {
        _service.RouterService.DeleteRouterForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateRouterForProduct(Guid productId, Guid id,
        [FromBody] RouterUpdateDTO routerUpdate)
    {
        if (routerUpdate is null)
            return BadRequest("RouterUpdateDTO object is null");

        _service.RouterService.UpdateRouterForProduct(productId, id, routerUpdate,
            productTrackChanges: false, routerTrackChanges: true);

        return NoContent();
    }


    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateRouterForProduct(Guid productId, Guid id,
[FromBody] JsonPatchDocument<RouterUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.RouterService.GetRouterForPatch(productId, id,
        productTrackChanges: false,
        routerTrackChanges: true);
        patchDoc.ApplyTo(result.routerToPatch, ModelState);

        TryValidateModel(result.routerToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.RouterService.SaveChangesForPatch(result.routerToPatch,
        result.routerEntity);
        return NoContent();
    }
}
