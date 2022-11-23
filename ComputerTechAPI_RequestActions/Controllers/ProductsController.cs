using ComputerTechAPI_DtoAndFeatures.DTO;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_RequestActions.ModelBinding;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace ComputerTechAPI_RequestActions.Controllers;

[Route("api/products")]
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


    [HttpGet("collection/({ids})", Name = "ProductCollection")]
    public IActionResult GetProductCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var products = _service.ProductService.GetByIds(ids, trackChanges: false);

        return Ok(products);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductCreateDTO productCreate)
    {
        if (productCreate is null)
            return BadRequest("ProductCreateDTO object is null");

        var createdProduct = _service.ProductService.CreateProduct(productCreate);

        return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, createdProduct);
    }



    [HttpDelete("{id:guid}")]
    public IActionResult DeleteProduct(Guid id)
    {
        _service.ProductService.DeleteProduct(id, trackChanges: false);

        return NoContent();
    }
}

