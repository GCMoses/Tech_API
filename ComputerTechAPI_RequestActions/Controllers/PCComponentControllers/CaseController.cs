using ComputerTechAPI_TechService.Contracts;
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

    [HttpGet("{id:guid}", Name = "CaseById")]
    public IActionResult GetCaseForProduct(Guid productId, Guid id)
    {
        var pcCase = _service.CaseService.GetCase(productId, id, trackChanges: false);
        return Ok(pcCase);
    }
}
