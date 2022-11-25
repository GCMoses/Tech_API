﻿using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCControllers;

[Route("api/products/{productId}/laptop")]
[ApiController]
public class LaptopController : ControllerBase
{
    private readonly IServiceManager _service;
    public LaptopController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetLaptopsForProduct(Guid productId)
    {
        var laptops = _service.LaptopService.GetLaptops(productId, trackChanges: false);
        return Ok(laptops);
    }

    [HttpGet("{id:guid}", Name = "LaptopById")]
    public IActionResult GetLaptopForProduct(Guid productId, Guid id)
    {
        var laptop = _service.LaptopService.GetLaptop(productId, id, trackChanges: false);
        return Ok(laptop);
    }


    [HttpPost]
    public IActionResult CreateLaptopForProduct(Guid productId, [FromBody] LaptopCreateDTO laptopCreate)
    {
        if (laptopCreate is null)
            return BadRequest("LaptopCreateDTO object is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var laptopToReturn =
        _service.LaptopService.CreateLaptopForProduct(productId, laptopCreate, trackChanges:
        false);
        return CreatedAtRoute("GetLaptopForProduct", new
        {
            productId,
            id = laptopToReturn.Id
        },
        laptopToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteLaptopForProduct(Guid productId, Guid id)
    {
        _service.LaptopService.DeleteLaptopForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateLaptopForProduct(Guid productId, Guid id,
        [FromBody] LaptopUpdateDTO laptopUpdate)
    {
        if (laptopUpdate is null)
            return BadRequest("LaptopUpdateDTO object is null");

        _service.LaptopService.UpdateLaptopForProduct(productId, id, laptopUpdate,
            productTrackChanges: false, laptopTrackChanges: true);

        return NoContent();
    }


    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateLaptopForProduct(Guid productId, Guid id, [FromBody]
    JsonPatchDocument<LaptopUpdateDTO> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = _service.LaptopService.GetLaptopForPatch(productId, id,
        productTrackChanges: false,
        laptopTrackChanges: true);
        patchDoc.ApplyTo(result.laptopToPatch, ModelState);

        TryValidateModel(result.laptopToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        _service.LaptopService.SaveChangesForPatch(result.laptopToPatch,
        result.laptopEntity);
        return NoContent();
    }
}
