using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.GamingController;

[Route("api/products/{productId}/gamingconsole")]
[ApiController]
public class GamingConsoleController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingConsoleController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGamingConsolesForProduct(Guid productId)
    {
        var gamingConsoles = _service.GamingConsoleService.GetGamingConsoles(productId, trackChanges: false);
        return Ok(gamingConsoles);
    }

    [HttpGet("{id:guid}", Name = "GetGamingConsoleForProduct")]
    public IActionResult GetGamingConsoleForProduct(Guid productId, Guid id)
    {
        var gamingConsole = _service.GamingConsoleService.GetGamingConsole(productId, id, trackChanges: false);
        return Ok(gamingConsole);
    }


    [HttpPost]
    public IActionResult CreateGamingConsoleForProduct(Guid productId, [FromBody] GamingConsoleCreateDTO gamingConsoleCreate)
    {
        if (gamingConsoleCreate is null)
            return BadRequest("GamingConsoleCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
    
        var gamingConsoleToReturn =
        _service.GamingConsoleService.CreateGamingConsoleForProduct(productId, gamingConsoleCreate, trackChanges:
        false);
        return CreatedAtRoute("GetGamingConsoleForProduct", new
        {
            productId,
            id = gamingConsoleToReturn.Id
        },
        gamingConsoleToReturn);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGamingConsoleForProduct(Guid productId, Guid id)
    {
        _service.GamingConsoleService.DeleteGamingConsoleForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateGamingConsoleForProduct(Guid productId, Guid id,
        [FromBody] GamingConsoleUpdateDTO gamingConsoleUpdate)
    {
        if (gamingConsoleUpdate is null)
            return BadRequest("GamingConsoleUpdateDTO object is null");

        _service.GamingConsoleService.UpdateGamingConsoleForProduct(productId, id, gamingConsoleUpdate,
            productTrackChanges: false, gamingConsoleTrackChanges: true);

        return NoContent();
    }


    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateGamingConsoleForProduct(Guid productId, Guid id,
[FromBody] JsonPatchDocument<GamingConsoleUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.GamingConsoleService.GetGamingConsoleForPatch(productId, id,
        productTrackChanges: false,
        gamingConsoleTrackChanges: true);
        patchDoc.ApplyTo(result.gamingConsoleToPatch, ModelState);

        TryValidateModel(result.gamingConsoleToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.GamingConsoleService.SaveChangesForPatch(result.gamingConsoleToPatch,
        result.gamingConsoleEntity);
        return NoContent();
    }
}
