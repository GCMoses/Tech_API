﻿using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.GamingController;

[Route("api/products/{productId}/gamingdesktop")]
[ApiController]
public class GamingDesktopController : ControllerBase
{
    private readonly IServiceManager _service;
    public GamingDesktopController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetGamingDesktopsForProduct(Guid productId)
    {
        var gamingDesktops = _service.GamingDesktopService.GetGamingDesktops(productId, trackChanges: false);
        return Ok(gamingDesktops);
    }

    [HttpGet("{id:guid}", Name = "GetGamingDesktopForProduct")]
    public IActionResult GetGamingDesktopForProduct(Guid productId, Guid id)
    {
        var gamingDesktop = _service.GamingDesktopService.GetGamingDesktop(productId, id, trackChanges: false);
        return Ok(gamingDesktop);
    }

    [HttpPost]
    public IActionResult CreateGamingDesktopForProduct(Guid productId, [FromBody] GamingDesktopCreateDTO gamingDesktopCreate)
    {
        if (gamingDesktopCreate is null)
            return BadRequest("GamingDesktopCreateDTO object is null");
        var gamingDesktopToReturn =
        _service.GamingDesktopService.CreateGamingDesktopForProduct(productId, gamingDesktopCreate, trackChanges:
        false);
        return CreatedAtRoute("GetGamingDesktopForProduct", new
        {
            productId,
            id = gamingDesktopToReturn.Id
        },
        gamingDesktopToReturn);
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGamingDesktopForProduct(Guid productId, Guid id)
    {
        _service.GamingDesktopService.DeleteGamingDesktopForProduct(productId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateGamingDesktopForProduct(Guid productId, Guid id,
        [FromBody] GamingDesktopUpdateDTO gamingDesktopUpdate)
    {
        if (gamingDesktopUpdate is null)
            return BadRequest("GamingDesktopUpdateDTO object is null");

        _service.GamingDesktopService.UpdateGamingDesktopForProduct(productId, id, gamingDesktopUpdate,
            productTrackChanges: false, gamingDesktopTrackChanges: true);

        return NoContent();
    }
}