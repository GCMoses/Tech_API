using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;
using ComputerTechAPI_Entities.LinkModels.TechLinkParams.PCComponentLinkParams;
using ComputerTechAPI_RequestActions.FilteringActions;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/pccases")]
[ApiController]
public class CaseController : ControllerBase
{
    private readonly IServiceManager _service;
    public CaseController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all Cases 
    /// </summary>
    /// <returns>Cases list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetCasesForProductAsync(Guid productId,
    [FromQuery] CaseParams pcCaseParams)
    {
        var pcCaselinkParams = new CaseLinkParameters(pcCaseParams, HttpContext);

        var result = await _service.CaseService.GetCasesAsync(productId,
            pcCaselinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the Case by Id only
    /// </summary>
    /// <returns>Case</returns>
    [HttpGet("{id:guid}", Name = "GetCaseForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetCaseForProductAsync(Guid productId, Guid id)
    {
        var pcCase = await _service.CaseService.GetCaseAsync(productId, id, trackChanges: false);
        return Ok(pcCase);
    }

    /// <summary>
    /// Create the Case
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="pcCaseCreate"></param>
    /// <returns>A newly created Case</returns>
    /// <response code="201">Returns the newly created Case</response>
    /// <response code="400">If the Case is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateCaseForProductAsync(Guid productId, [FromBody] CaseCreateDTO pcCaseCreate)
    {
        if (pcCaseCreate is null)
            return BadRequest("CaseCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var pcCaseToReturn =
         await _service.CaseService.CreateCaseForProductAsync(productId, pcCaseCreate, trackChanges:
        false);
        return CreatedAtRoute("GetCaseForProduct", new
        {
            productId, id = pcCaseToReturn.Id
        },
        pcCaseToReturn);
    }

    /// <summary>
    /// Delete the Case by Id
    /// </summary>
    /// <returns>Delete Case item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteCaseForProductAsync(Guid productId, Guid id)
    {
        await _service.CaseService.DeleteCaseForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the Case by Id
    /// </summary>
    /// <returns>Update Case item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateCaseForProductAsync(Guid productId, Guid id,
        [FromBody] CaseUpdateDTO pcCaseUpdate)
    {
        if (pcCaseUpdate is null)
            return BadRequest("CaseUpdateDTO object is null");

        await _service.CaseService.UpdateCaseForProductAsync(productId, id, pcCaseUpdate,
            productTrackChanges: false, pcCaseTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the Case by Id
    /// </summary>
    /// <returns>Patch Case item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateCaseForProductAsync(Guid productId, Guid id,
    [FromBody] JsonPatchDocument<CaseUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = await _service.CaseService.GetCaseForPatchAsync(productId, id,
        productTrackChanges: false,
        pcCaseTrackChanges: true);
        patchDoc.ApplyTo(result.pcCaseToPatch, ModelState);

        TryValidateModel(result.pcCaseToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.CaseService.SaveChangesForPatchAsync(result.pcCaseToPatch,
        result.pcCaseEntity);
        return NoContent();
    }
}
