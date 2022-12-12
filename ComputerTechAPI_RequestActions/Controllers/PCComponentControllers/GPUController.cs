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

[Route("api/products/{productId}/gpus")]
[ApiController]
public class GPUController : ControllerBase
{
    private readonly IServiceManager _service;
    public GPUController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the array of all GPUs 
    /// </summary>
    /// <returns>GPUs list</returns>
    [HttpGet]
    [HttpHead]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public async Task<IActionResult> GetGPUsForProductAsync(Guid productId,
    [FromQuery] GPUParams gpuParams)
    {
        var gpulinkParams = new GPULinkParameters(gpuParams, HttpContext);

        var result = await _service.GPUService.GetGPUsAsync(productId,
            gpulinkParams, trackChanges: false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));


        return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : Ok(result.linkResponse.ShapedEntities);
    }

    /// <summary>
    /// Gets the GPU by Id only
    /// </summary>
    /// <returns>GPU</returns>
    [HttpGet("{id:guid}", Name = "GetGPUForProduct")]
    public async Task<IActionResult> GetGPUForProductAsync(Guid productId, Guid id)
    {
        var gpu = await _service.GPUService.GetGPUAsync(productId, id, trackChanges: false);
        return Ok(gpu);
    }

    /// <summary>
    /// Create the GPU
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="gpuCreate"></param>
    /// <returns>A newly created GPU</returns>
    /// <response code="201">Returns the newly created GPU</response>
    /// <response code="400">If the GPU is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public async Task<IActionResult> CreateGPUForProduct(Guid productId, [FromBody] GPUCreateDTO gpuCreate)
    {
        if (gpuCreate is null)
            return BadRequest("CPUCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var gpuToReturn =
        await _service.GPUService.CreateGPUForProductAsync(productId, gpuCreate, trackChanges: false);
        return CreatedAtRoute("GetGPUForProduct", new
        {
            productId, id = gpuToReturn.Id
        },
        gpuToReturn);
    }


    /// <summary>
    /// Delete the Router by Id
    /// </summary>
    /// <returns>Delete Router item</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteGPUForProductAsync(Guid productId, Guid id)
    {
        await _service.GPUService.DeleteGPUForProductAsync(productId, id, trackChanges: false);

        return NoContent();
    }

    /// <summary>
    /// Update the Router by Id
    /// </summary>
    /// <returns>Update Router item</returns>
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateGPUForProductAsync(Guid productId, Guid id, [FromBody] GPUUpdateDTO gpuUpdate)
    {
        if (gpuUpdate is null)
            return BadRequest("GPUUpdateDTO object is null");

        await _service.GPUService.UpdateGPUForProductAsync(productId, id, gpuUpdate,
            productTrackChanges: false, gpuTrackChanges: true);

        return NoContent();
    }

    /// <summary>
    /// Partially Update the Router by Id
    /// </summary>
    /// <returns>Patch Router item</returns>
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> PartiallyUpdateGPUForProductAsync(Guid productId, Guid id,
    [FromBody] JsonPatchDocument<GPUUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = await _service.GPUService.GetGPUForPatchAsync(productId, id,
        productTrackChanges: false, gpuTrackChanges: true);
        patchDoc.ApplyTo(result.gpuToPatch, ModelState);

        TryValidateModel(result.gpuToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.GPUService.SaveChangesForPatchAsync(result.gpuToPatch, result.gpuEntity);
        return NoContent();
    }
}

