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

[Route("api/products/{productId}/cpus")]
[ApiController]
public class CPUController : ControllerBase
{
    private readonly IServiceManager _service;
    public CPUController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all CPUs 
    /// </summary>
    /// <returns>CPUs list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize()]
    public async Task<IActionResult> GetCPUsForProductAsync(Guid productId,
    [FromQuery] CPUParams cpuParams)
    {
        var cpulinkParams = new CPULinkParameters(cpuParams, HttpContext);

        var result = await _service.CPUService.GetCPUsAsync(productId,
            cpulinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the CPU by Id only
    /// </summary>
    /// <returns>CPU</returns>
    [HttpGet("{id:guid}", Name = "GetCPUForProductById")]
    [Authorize()]
    public async Task<IActionResult> GetCPUForProductAsync(Guid productId, Guid id)
    {
        var cpu = await _service.CPUService.GetCPUAsync(productId, id, trackChanges: false);
        return Ok(cpu);
    }

    /// <summary>
    /// Create the CPU
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="cpuCreate"></param>
    /// <returns>A newly created CPU</returns>
    /// <response code="201">Returns the newly created CPU</response>
    /// <response code="400">If the CPU is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateCPUForProductAsync(Guid productId, [FromBody] CPUCreateDTO cpuCreate)
    {
        if (cpuCreate is null)
            return BadRequest("CPUCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var cpuToReturn =
        await _service.CPUService.CreateCPUForProductAsync(productId, cpuCreate, trackChanges:
        false);
        return CreatedAtRoute("GetCPUForProduct", new
        {
            productId, id = cpuToReturn.Id
        },
        cpuToReturn);
    }

    /// <summary>
    /// Delete the CPU by Id
    /// </summary>
    /// <returns>Delete CPU item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteCPUForProductAsync(Guid productId, Guid id)
    {
        await _service.CPUService.DeleteCPUForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the CPU by Id
    /// </summary>
    /// <returns>Update CPU item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateCPUForProductAsync(Guid productId, Guid id,
        [FromBody] CPUUpdateDTO cpuUpdate)
    {
        if (cpuUpdate is null)
            return BadRequest("CPUUpdateDTO object is null");

        await _service.CPUService.UpdateCPUForProductAsync(productId, id, cpuUpdate,
            productTrackChanges: false, cpuTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the CPU by Id
    /// </summary>
    /// <returns>Patch CPU item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult>PartiallyUpdateCPUForProductAsync(Guid productId, Guid id,
    [FromBody] JsonPatchDocument<CPUUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = await _service.CPUService.GetCPUForPatchAsync(productId, id,
        productTrackChanges: false,
        cpuTrackChanges: true);
        patchDoc.ApplyTo(result.cpuToPatch, ModelState);

        TryValidateModel(result.cpuToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.CPUService.SaveChangesForPatchAsync(result.cpuToPatch,
        result.cpuEntity);
        return NoContent();
    }
}
