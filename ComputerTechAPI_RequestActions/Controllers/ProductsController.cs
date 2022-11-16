using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IServiceManager _service;
    public ProductsController(IServiceManager service) => _service = service;
    [HttpGet]
    public IActionResult GetProducts()
    {
        try
        {
            var products =
            _service.ProductService.GetAllProducts(trackChanges: false);
            return Ok(products);
        }
        catch
        {
            return StatusCode(500, "Internal server error");
        }
    }
}

