using API.Contracts;
using Business;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(ProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Products>> GetAll() => await productService.GetAllProductsAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Products>> GetById([FromRoute] int id)
        => await productService.GetProductByIdAsync(id) is { } product ? Ok(product) : NotFound();

    [HttpGet("by-name/{name}")]
    public async Task<ActionResult<Products>> GetByName([FromRoute] string name)
        => await productService.GetProductByNameAsync(name) is { } product ? Ok(product) : NotFound();

    [HttpPost]
    public async Task<ActionResult<Products>> Create([FromBody] CreateProductRequest request)
    {
        var product = await productService.CreateProductAsync(request.Name, request.Number, request.Description);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    // Update variant #1: tracked entity + SaveChanges.
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequest request)
        => await productService.UpdateProductAsync(id, request.Name, request.Number, request.Description)
            ? NoContent()
            : NotFound();

    // Update variant #2: ExecuteUpdate (no tracking). Requires a relational provider.
    [HttpPut("{id:int}/execute")]
    public async Task<IActionResult> UpdateExecute([FromRoute] int id, [FromBody] UpdateProductRequest request)
        => await productService.UpdateProductExecuteAsync(id, request.Name, request.Number, request.Description)
            ? NoContent()
            : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
        => await productService.DeleteProductAsync(id) ? NoContent() : NotFound();
}
