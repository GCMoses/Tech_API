using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
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

    [HttpGet("{id:guid}", Name = "GetHDDForProduct")]
    public IActionResult GetHDDForProduct(Guid productId, Guid id)
    {
        var hdd = _service.HDDService.GetHDD(productId, id, trackChanges: false);
        return Ok(hdd);
    }


    [HttpPost]
    public IActionResult CreateHDDForProduct(Guid productId, [FromBody] HDDCreateDTO hddCreate)
    {
        if (hddCreate is null)
            return BadRequest("HDDCreateDTO object is null");
        var hddToReturn =
        _service.HDDService.CreateHDDForProduct(productId, hddCreate, trackChanges:
        false);
        return CreatedAtRoute("GetHDDForProduct", new
        {
            productId,
            id =
        hddToReturn.Id
        },
        hddToReturn);
    }



    [HttpDelete("{id:guid}")]
    public IActionResult DeleteHDDForProduct(Guid productId, Guid id)
    {
        _service.HDDService.DeleteHDDForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateHDDForProduct(Guid productId, Guid id,
        [FromBody] HDDUpdateDTO hddUpdate)
    {
        if (hddUpdate is null)
            return BadRequest("HDDUpdateDTO object is null");

        _service.HDDService.UpdateHDDForProduct(productId, id, hddUpdate,
            productTrackChanges: false, hddTrackChanges: true);

        return NoContent();
    }
}
