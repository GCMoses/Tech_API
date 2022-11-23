using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/ram")]
[ApiController]
public class RAMController : ControllerBase
{
    private readonly IServiceManager _service;
    public RAMController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetRAMsForProduct(Guid productId)
    {
        var rams = _service.RAMService.GetRAMs(productId, trackChanges: false);
        return Ok(rams);
    }

    [HttpGet("{id:guid}", Name = "GetRAMForProduct")]
    public IActionResult GetRAMForProduct(Guid productId, Guid id)
    {
        var ram = _service.RAMService.GetRAM(productId, id, trackChanges: false);
        return Ok(ram);
    }


    [HttpPost]
    public IActionResult CreateRAMForProduct(Guid productId, [FromBody] RAMCreateDTO ramCreate)
    {
        if (ramCreate is null)
            return BadRequest("RAMCreateDTO object is null");
        var ramToReturn =
        _service.RAMService.CreateRAMForProduct(productId, ramCreate, trackChanges:
        false);
        return CreatedAtRoute("GetRAMForProduct", new
        {
            productId,
            id =
        ramToReturn.Id
        },
        ramToReturn);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRAMForProduct(Guid productId, Guid id)
    {
        _service.RAMService.DeleteRAMForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateRAMForProduct(Guid productId, Guid id,
        [FromBody] RAMUpdateDTO ramUpdate)
    {
        if (ramUpdate is null)
            return BadRequest("RAMUpdateDTO object is null");

        _service.RAMService.UpdateRAMForProduct(productId, id, ramUpdate,
            productTrackChanges: false, ramTrackChanges: true);

        return NoContent();
    }

}
