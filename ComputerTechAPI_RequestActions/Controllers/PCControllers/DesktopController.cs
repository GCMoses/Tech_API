using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCControllers;

[Route("api/products/{productId}/desktop")]
[ApiController]
public class DesktopController : ControllerBase
{
    private readonly IServiceManager _service;
    public DesktopController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetDesktopsForProduct(Guid productId)
    {
        var desktops = _service.DesktopService.GetDesktops(productId, trackChanges: false);
        return Ok(desktops);
    }

    [HttpGet("{id:guid}", Name = "DesktopById")]
    public IActionResult GetDesktopForProduct(Guid productId, Guid id)
    {
        var desktop = _service.DesktopService.GetDesktop(productId, id, trackChanges: false);
        return Ok(desktop);
    }


    [HttpPost]
    public IActionResult CreateDesktopForProduct(Guid productId, [FromBody] DesktopCreateDTO desktopCreate)
    {
        if (desktopCreate is null)
            return BadRequest("DesktopCreateDTO object is null");
        var desktopToReturn =
        _service.DesktopService.CreateDesktopForProduct(productId, desktopCreate, trackChanges:
       false);
        return CreatedAtRoute("GetDesktopForProduct", new
        {
            productId,
            id = desktopToReturn.Id
        },
        desktopToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteDesktopForProduct(Guid productId, Guid id)
    {
        _service.DesktopService.DeleteDesktopForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateDesktopForProduct(Guid productId, Guid id,
        [FromBody] DesktopUpdateDTO desktopUpdate)
    {
        if (desktopUpdate is null)
            return BadRequest("DesktopUpdateDTO object is null");

        _service.DesktopService.UpdateDesktopForProduct(productId, id, desktopUpdate,
            productTrackChanges: false, desktopTrackChanges: true);

        return NoContent();
    }
}
