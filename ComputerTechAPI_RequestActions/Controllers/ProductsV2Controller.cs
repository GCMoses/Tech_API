using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers;

[Route("api/products")]
[ApiController]
[ApiExplorerSettings(GroupName = "v2")]

public class ProductsV2Controller : ControllerBase
{
    private readonly IServiceManager _service;

    public ProductsV2Controller(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _service.ProductService
            .GetAllProductsAsync(trackChanges: false);

        var productsV2 = products.Select(x => $"{x.Category} V2");

        return Ok(productsV2);
    }
}
