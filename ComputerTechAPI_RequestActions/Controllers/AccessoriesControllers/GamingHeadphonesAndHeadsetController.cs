using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.AccessoriesController;

[Route("api/products/{productId}/gamingheadphonesandheadsets")]
[ApiController]
public class GamingHeadphonesAndHeadsetController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingHeadphonesAndHeadsetController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGamingHeadphonesAndHeadsetsForProduct(Guid productId)
    {
        var gamingHeadphonesAndHeadsets = _service.GamingHeadphonesAndHeadsetService.GetGamingHeadphonesAndHeadsets(productId, trackChanges: false);
        return Ok(gamingHeadphonesAndHeadsets);
    }

    [HttpGet("{id:guid}", Name = "GetGamingHeadphonesAndHeadsetForProduct")] 
    public IActionResult GetGamingHeadphonesAndHeadsetForProduct(Guid productId, Guid id)
    {
        var gamingHeadphonesAndHeadset = _service.GamingHeadphonesAndHeadsetService.GetGamingHeadphonesAndHeadset(productId, id, trackChanges: false);
        return Ok(gamingHeadphonesAndHeadset);
    }


   

    [HttpPost]
    public IActionResult CreateGamingHeadphonesAndHeadsetForProduct(Guid productId, [FromBody] GamingHeadphonesAndHeadsetCreateDTO gamingHeadphonesAndHeadsetCreate)
    {
        if (gamingHeadphonesAndHeadsetCreate is null)
            return BadRequest("GamingHeadphonesAndHeadsetCreateDTO object is null");
        var gamingHeadphonesAndHeadsetToReturn =
        _service.GamingHeadphonesAndHeadsetService.CreateGamingHeadphonesAndHeadsetForProduct(productId, gamingHeadphonesAndHeadsetCreate, trackChanges:
        false);
        return CreatedAtRoute("GetGamingHeadphonesAndHeadsetForProduct", new
        {
            productId, 
            id = gamingHeadphonesAndHeadsetToReturn.Id
        },
        gamingHeadphonesAndHeadsetToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGamingHeadphonesAndHeadsetForProduct(Guid productId, Guid id)
    {
        _service.GamingHeadphonesAndHeadsetService.DeleteGamingHeadphonesAndHeadsetForProduct(productId, id, trackChanges:
        false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateGamingHeadphonesAndHeadsetForProduct(Guid productId, Guid id,
        [FromBody] GamingHeadphonesAndHeadsetUpdateDTO gamingHeadphonesAndHeadsetUpdate)
    {
        if (gamingHeadphonesAndHeadsetUpdate is null)
            return BadRequest("GamingHeadphonesAndHeadsetUpdateDTO object is null");

        _service.GamingHeadphonesAndHeadsetService.UpdateGamingHeadphonesAndHeadsetForProduct(productId, id, gamingHeadphonesAndHeadsetUpdate,
            productTrackChanges: false, gamingHeadphonesAndHeadsetTrackChanges: true);

        return NoContent();
    }

}
