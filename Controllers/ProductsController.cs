using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


using ProductShop.Models;
using ProductShop.Services;

namespace ProductShop.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/api/v1/products")]
    public ActionResult<List<Product>> GetAll() => ProductsService.GetAll();


    [HttpGet("/api/v1/products/{id}")]
    public ActionResult<Product> Get(int id) {
        var product = ProductsService.Get(id);

        if (product == null)
            return NotFound();
        
        return product;
    }

    [HttpGet("/api/v1/products/query")]
    public ActionResult<List<Product>> Query(){
        return new List<Product>();
    }

    [HttpPost("/api/v1/products")]
    public IActionResult Post(Product product) {
        ProductsService.Add(product);
        return CreatedAtAction(nameof(Get), new {id = product.Id}, product);
    }

    [HttpDelete("/api/v1/products/{id}")]
    public IActionResult Delete(int id) {
        var product = ProductsService.Get(id);

        if (product == null)
            return NotFound();
        
        ProductsService.Delete(id);

        return NoContent();
    }

    [HttpPut("/api/v1/products")]
    public IActionResult Put(Product product) {
        if (ProductsService.Get(product.Id) == null) return NotFound(product);

        ProductsService.Update(product);

        return NoContent();
    }
}