using ComputerTechAPI_DtoAndFeatures.DTO;
using ComputerTechAPI_RequestActions.ModelBinding;
using ComputerTechAPI_TechService.Contracts;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ComputerTechAPI_RequestActions.Controllers;

[Route("api/products")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
public class ProductsController : ControllerBase
{
    private readonly IServiceManager _service;
    public ProductsController(IServiceManager service) => _service = service;

    /// <summary>
    /// Gets the list of all product categories
    /// </summary>
    /// <returns>The products list</returns>
    [HttpGet(Name = "GetProducts")]
    [Authorize()]
    public async Task<IActionResult> GetProducts()
    {
            var products = await _service.ProductService.GetAllProductsAsync(trackChanges: false);
            return Ok(products);
    }


    /// <summary>
    /// Gets the product categories by id only
    /// </summary>
    /// <returns>The product by id</returns>
    [HttpGet("{id:guid}", Name = "ProductById")]
    [Authorize()]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
    [HttpCacheValidation(MustRevalidate = false)]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = await _service.ProductService.GetProductAsync (id, trackChanges: false);
        return Ok(product);
    }



    /// <summary>
    /// Gets the product collection by ids 
    /// </summary>
    /// <response code="200">Returns the Product Collection</response>
    /// <returns>The product by ids collection</returns>
    [HttpGet("collection/({ids})", Name = "ProductCollection")]
    [Authorize()]
    public async Task<IActionResult> GetProductCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var products = await _service.ProductService.GetByIdsAsync(ids, trackChanges: false);

        return Ok(products);
    }



    /// <summary>
    /// Create the product categories
    /// </summary>
    /// <param name="productCreate"></param>
    /// <returns>A newly created product</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost(Name= "CreateProduct")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateProductAsync([FromBody] ProductCreateDTO productCreate)
    {
        if (productCreate is null)
            return BadRequest("ProductCreateDTO object is null");

        var createdProduct = await _service.ProductService.CreateProductAsync(productCreate);

        return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, createdProduct);
    }


    /// <summary>
    /// Create the product collection of categories
    /// </summary>
    /// <returns>Created product collection of categories</returns>
    [HttpPost("collection")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> CreateProductCollection ([FromBody] IEnumerable<ProductCreateDTO> productCollection)
    {
        var result = await _service.ProductService.CreateProductCollectionAsync(productCollection);
        return CreatedAtRoute("ProductCollection", new { result.ids },
        result.products);
    }

    /// <summary>
    /// Delete the product category
    /// </summary>
    /// <returns>Delete product category</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _service.ProductService.DeleteProductAsync(id, trackChanges: false);
        return NoContent();
    }

    /// <summary>
    /// Update the product categories
    /// </summary>
    /// <returns>Updated product category</returns>

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "ApiManager")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductUpdateDTO product)
    {
        if (product is null)
            return BadRequest("ProductUpdateDTO object is null");
        await _service.ProductService.UpdateProductAsync(id, product, trackChanges:
        true);
        return NoContent();
    }


    [HttpOptions]
    public IActionResult GetProductsOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST");
        return Ok();
    }

}

