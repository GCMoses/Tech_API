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
            var products =
            _service.ProductService.GetAllProducts(trackChanges: false);
            return Ok(products);
    }


    [HttpGet("{id:guid}", Name = "ProductById")]
    public IActionResult GetProduct(Guid id)
    {
        var product = _service.ProductService.GetProduct(id, trackChanges: false);
        return Ok(product);
    }
}

