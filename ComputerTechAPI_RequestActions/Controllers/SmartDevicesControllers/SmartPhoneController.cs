﻿using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.SmartDevicesControllers;

[Route("api/products/{productId}/smartphone")]
[ApiController]
public class SmartPhoneController : ControllerBase
{
    private readonly IServiceManager _service;
    public SmartPhoneController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetSmartPhonesForProduct(Guid productId)
    {
        var smartPhones = _service.SmartPhoneService.GetSmartPhones(productId, trackChanges: false);
        return Ok(smartPhones);
    }

    [HttpGet("{id:guid}", Name = "GetSmartPhoneForProduct")]
    public IActionResult GetSmartPhoneForProduct(Guid productId, Guid id)
    {
        var smartPhone = _service.SmartPhoneService.GetSmartPhone(productId, id, trackChanges: false);
        return Ok(smartPhone);
    }


    [HttpPost]
    public IActionResult CreateSmartPhoneForProduct(Guid productId, [FromBody] SmartPhoneCreateDTO smartPhoneCreate)
    {
        if (smartPhoneCreate is null)
            return BadRequest("SmartPhoneCreateDTO object is null");
        var smartPhoneToReturn =
        _service.SmartPhoneService.CreateSmartPhoneForProduct(productId, smartPhoneCreate, trackChanges:
        false);
        return CreatedAtRoute("GetSmartPhoneForProduct", new
        {
            productId,
            id = smartPhoneToReturn.Id
        },
        smartPhoneToReturn);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteSmartPhoneForProduct(Guid productId, Guid id)
    {
        _service.SmartPhoneService.DeleteSmartPhoneForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateSmartPhoneForProduct(Guid productId, Guid id,
        [FromBody] SmartPhoneUpdateDTO smartPhoneUpdate)
    {
        if (smartPhoneUpdate is null)
            return BadRequest("SmartPhoneUpdateDTO object is null");

        _service.SmartPhoneService.UpdateSmartPhoneForProduct(productId, id, smartPhoneUpdate,
            productTrackChanges: false, smartPhoneTrackChanges: true);

        return NoContent();
    }
}