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

    [HttpGet("{id:guid}", Name = "SmartPhoneById")]
    public IActionResult GetSmartPhoneForProduct(Guid productId, Guid id)
    {
        var smartPhone = _service.SmartPhoneService.GetSmartPhone(productId, id, trackChanges: false);
        return Ok(smartPhone);
    }
}
