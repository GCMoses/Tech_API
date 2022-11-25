using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/pccase")]
[ApiController]
public class LaptopController : ControllerBase
{
    private readonly IServiceManager _service;
    public LaptopController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetCasesForProduct(Guid productId)
    {
        var pcCases = _service.CaseService.GetCases(productId, trackChanges: false);
        return Ok(pcCases);
    }

    [HttpGet("{id:guid}", Name = "GetCaseForProduct")]
    public IActionResult GetCaseForProduct(Guid productId, Guid id)
    {
        var pcCase = _service.CaseService.GetCase(productId, id, trackChanges: false);
        return Ok(pcCase);
    }

    [HttpPost]
    public IActionResult CreateCaseForProduct(Guid productId, [FromBody] CaseCreateDTO pcCaseCreate)
    {
        if (pcCaseCreate is null)
            return BadRequest("CaseCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var pcCaseToReturn =
        _service.CaseService.CreateCaseForProduct(productId, pcCaseCreate, trackChanges:
        false);
        return CreatedAtRoute("GetCaseForProduct", new
        {
            productId,
            id =
        pcCaseToReturn.Id
        },
        pcCaseToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCaseForProduct(Guid productId, Guid id)
    {
        _service.CaseService.DeleteCaseForProduct(productId, id, trackChanges: false);

        return NoContent();
    }


    [HttpPut("{id:guid}")]
    public IActionResult UpdateCaseForProduct(Guid productId, Guid id,
        [FromBody] CaseUpdateDTO pcCaseUpdate)
    {
        if (pcCaseUpdate is null)
            return BadRequest("CaseUpdateDTO object is null");

        _service.CaseService.UpdateCaseForProduct(productId, id, pcCaseUpdate,
            productTrackChanges: false, pcCaseTrackChanges: true);

        return NoContent();
    }


    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateCaseForProduct(Guid productId, Guid id,
[FromBody] JsonPatchDocument<CaseUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.CaseService.GetCaseForPatch(productId, id,
        productTrackChanges: false,
        pcCaseTrackChanges: true);
        patchDoc.ApplyTo(result.pcCaseToPatch, ModelState);

        TryValidateModel(result.pcCaseToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.CaseService.SaveChangesForPatch(result.pcCaseToPatch,
        result.pcCaseEntity);
        return NoContent();
    }
}
