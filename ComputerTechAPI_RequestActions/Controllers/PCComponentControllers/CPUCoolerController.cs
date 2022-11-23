using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers.PCComponentControllers;

[Route("api/products/{productId}/cpucooler")]
[ApiController]
public class CPUCoolerController : ControllerBase
{
    private readonly IServiceManager _service;
    public CPUCoolerController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetCPUCoolersForProduct(Guid productId)
    {
        var cpuCoolers = _service.CPUCoolerService.GetCPUCoolers(productId, trackChanges: false);
        return Ok(cpuCoolers);
    }

    [HttpGet("{id:guid}", Name = "GetCPUCoolerForProduct")]
    public IActionResult GetCPUCoolerForProduct(Guid productId, Guid id)
    {
        var cpuCooler = _service.CPUCoolerService.GetCPUCooler(productId, id, trackChanges: false);
        return Ok(cpuCooler);
    }


    [HttpPost]
    public IActionResult CreateCPUCoolerForProduct(Guid productId, [FromBody] CPUCoolerCreateDTO cpuCoolerCreate)
    {
        if (cpuCoolerCreate is null)
            return BadRequest("CPUCoolerCreateDTO object is null");
        var cpuCoolerToReturn =
        _service.CPUCoolerService.CreateCPUCoolerForProduct(productId, cpuCoolerCreate, trackChanges:
        false);
        return CreatedAtRoute("GetCPUCoolerForProduct", new
        {
            productId,
            id =
        cpuCoolerToReturn.Id
        },
        cpuCoolerToReturn);
    }
}
