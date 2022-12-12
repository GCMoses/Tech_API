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

[Route("api/products/{productId}/cpucoolers")]
[ApiController]
public class CPUCoolerController : ControllerBase
{
    private readonly IServiceManager _service;
    public CPUCoolerController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all CPUCoolers 
    /// </summary>
    /// <returns>CPUCoolers list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetCPUCoolersForProductAsync(Guid productId,
    [FromQuery] CPUCoolerParams cpuCoolerParams)
    {
        var cpuCoolerlinkParams = new CPUCoolerLinkParameters(cpuCoolerParams, HttpContext);

        var result = await _service.CPUCoolerService.GetCPUCoolersAsync(productId,
            cpuCoolerlinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the CPUCooler by Id only
    /// </summary>
    /// <returns>CPUCooler</returns>
    [HttpGet("{id:guid}", Name = "GetCPUCoolerForProduct")]
    [Authorize()]
    public async Task<IActionResult> GetCPUCoolerForProductAsync(Guid productId, Guid id)
    {
        var cpuCooler = await _service.CPUCoolerService.GetCPUCoolerAsync(productId, id, trackChanges: false);
        return Ok(cpuCooler);
    }

    /// <summary>
    /// Create the CPUCooler
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="cpuCoolerCreate"></param>
    /// <returns>A newly created CPUCooler</returns>
    /// <response code="201">Returns the newly created CPUCooler</response>
    /// <response code="400">If the CPUCooler is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public IActionResult CreateCPUCoolerForProductAsync(Guid productId, [FromBody] CPUCoolerCreateDTO cpuCoolerCreate)
    {
        if (cpuCoolerCreate is null)
            return BadRequest("CPUCoolerCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var cpuCoolerToReturn =
        _service.CPUCoolerService.CreateCPUCoolerForProductAsync(productId, cpuCoolerCreate, trackChanges:
        false);
        return CreatedAtRoute("GetCPUCoolerForProduct", new
        {
            productId, id = cpuCoolerToReturn.Id
        },
        cpuCoolerToReturn);
    }

    /// <summary>
    /// Delete the CPUCooler by Id
    /// </summary>
    /// <returns>Delete CPUCooler item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteCPUCoolerForProductAsync(Guid productId, Guid id)
    {
        await _service.CPUCoolerService.DeleteCPUCoolerForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the CPUCooler by Id
    /// </summary>
    /// <returns>Update CPUCooler item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateCPUCoolerForProductAsync(Guid productId, Guid id,
        [FromBody] CPUCoolerUpdateDTO cpuCoolerUpdate)
    {
        if (cpuCoolerUpdate is null)
            return BadRequest("CPUCoolerUpdateDTO object is null");

        await _service.CPUCoolerService.UpdateCPUCoolerForProductAsync(productId, id, cpuCoolerUpdate,
            productTrackChanges: false, cpuCoolerTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the CPUCooler by Id
    /// </summary>
    /// <returns>Patch CPUCooler item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateCPUCoolerForProductAsync(Guid productId, Guid id,
    [FromBody] JsonPatchDocument<CPUCoolerUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = await _service.CPUCoolerService.GetCPUCoolerForPatchAsync(productId, id,
        productTrackChanges: false, cpuCoolerTrackChanges: true);
        patchDoc.ApplyTo(result.cpuCoolerToPatch, ModelState);

        TryValidateModel(result.cpuCoolerToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.CPUCoolerService.SaveChangesForPatchAsync(result.cpuCoolerToPatch,
        result.cpuCoolerEntity);
        return NoContent();
    }
}
