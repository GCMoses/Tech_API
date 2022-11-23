using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
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

    [HttpGet("{id:guid}", Name = "GetGamingLaptopForProduct")]
    public IActionResult GetGamingLaptopForProduct(Guid productId, Guid id)
    {
        var gamingLaptop = _service.GamingLaptopService.GetGamingLaptop(productId, id, trackChanges: false);
        return Ok(gamingLaptop);
    }


    [HttpPost]
    public IActionResult CreateGamingLaptopForProduct(Guid productId, [FromBody] GamingLaptopCreateDTO gamingLaptopCreate)
    {
        if (gamingLaptopCreate is null)
            return BadRequest("GamingLaptopCreateDTO object is null");
        var gamingLaptopToReturn =
        _service.GamingLaptopService.CreateGamingLaptopForProduct(productId, gamingLaptopCreate, trackChanges:
        false);
        return CreatedAtRoute("GetGamingLaptopForProduct", new
        {
            productId,
            id = gamingLaptopToReturn.Id
        },
        gamingLaptopToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGamingLaptopForProduct(Guid productId, Guid id)
    {
        _service.GamingLaptopService.DeleteGamingLaptopForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateGamingLaptopForProduct(Guid productId, Guid id,
        [FromBody] GamingLaptopUpdateDTO gamingLaptopUpdate)
    {
        if (gamingLaptopUpdate is null)
            return BadRequest("GamingLaptopUpdateDTO object is null");

        _service.GamingLaptopService.UpdateGamingLaptopForProduct(productId, id, gamingLaptopUpdate, 
            productTrackChanges: false, gamingLaptopTrackChanges: true);

        return NoContent();
    }
}
