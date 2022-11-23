using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
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

    [HttpGet("{id:guid}", Name = "GetMotherboardForProduct")]
    public IActionResult GetMotherboardForProduct(Guid productId, Guid id)
    {
        var motherboard = _service.MotherboardService.GetMotherboard(productId, id, trackChanges: false);
        return Ok(motherboard);
    }


    [HttpPost]
    public IActionResult CreateMotherboardForProduct(Guid productId, [FromBody] MotherboardCreateDTO motherboardCreate)
    {
        if (motherboardCreate is null)
            return BadRequest("MotherboardCreateDTO object is null");
        var motherboardToReturn =
        _service.MotherboardService.CreateMotherboardForProduct(productId, motherboardCreate, trackChanges:
        false);
        return CreatedAtRoute("GetMotherboardForProduct", new
        {
            productId,
            id =
        motherboardToReturn.Id
        },
        motherboardToReturn);
    }



    [HttpDelete("{id:guid}")]
    public IActionResult DeleteMotherboardForProduct(Guid productId, Guid id)
    {
        _service.MotherboardService.DeleteMotherboardForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateMotherboardForProduct(Guid productId, Guid id,
        [FromBody] MotherboardUpdateDTO motherboardUpdate)
    {
        if (motherboardUpdate is null)
            return BadRequest("MotherboardUpdateDTO object is null");

        _service.MotherboardService.UpdateMotherboardForProduct(productId, id, motherboardUpdate,
            productTrackChanges: false, motherboardTrackChanges: true);

        return NoContent();
    }
}
