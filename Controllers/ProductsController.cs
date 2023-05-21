using System.Net.Sockets;
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

    // [HttpGet("/api/v1/products/query")]
    // public ActionResult<List<Product>> Query(){
    //     return new List<Product>();
    // }
    
    [HttpGet("/api/v1/products/SortBy={value},{sortType}")]
    public ActionResult<List<Product>> Query(string value, string sortType)
    {
        bool boolType;
        switch (sortType)
        {
            case "asc":
                boolType = true;
                break;
            case "desc":
                boolType = false;
                break;
            default:
                return BadRequest();
        }
        
        var products = ProductsService.Sort(value, boolType);
        return products;
    }
    
    [HttpGet("/api/v1/products/FilteredBy{field}={value}")]
    public ActionResult<List<Product>> FilterQuery(string field, string value)
    {
        return ProductsService.Filter(field, value);
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
    // [HttpPost("/api/v1/products?{Attr}={Value}")]
    // [HttpPost("/api/v1/products?orderBy={sortOrder},{sortType}")]
    // [HttpPost("/api/v1/products?orderBy={sortOrder},{sortType}&{Attr}={Value}")] 
    // public IActionResult Sorted(string sortOrder = "", string sortType = "desc", string filteredQuery = "")
    // {
    //    
    // }
}