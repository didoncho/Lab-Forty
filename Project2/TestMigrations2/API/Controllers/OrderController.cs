using API.Contracts;
using Business;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(OrderService orderService) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Order>> GetAll() => await orderService.GetAllOrdersAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Order>> GetById([FromRoute] int id)
        => await orderService.GetOrderByIdAsync(id) is { } order ? Ok(order) : NotFound();

    // Creates an order by attaching an existing user and existing products.
    [HttpPost]
    public async Task<ActionResult<Order>> Create([FromBody] CreateOrderRequest request)
    {
        var order = await orderService.CreateOrderAsync(
            request.Price, request.ShippingDate, request.UserId, request.ProductIds);

        return CreatedAtAction(nameof(GetById), new { id = order.ID }, order);
    }

    // Update variant #1: tracked entity + SaveChanges.
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderRequest request)
        => await orderService.UpdateOrderAsync(id, request.Price, request.ShippingDate)
            ? NoContent()
            : NotFound();

    // Update variant #2: ExecuteUpdate (no tracking). Requires a relational provider.
    [HttpPut("{id:int}/execute")]
    public async Task<IActionResult> UpdateExecute([FromRoute] int id, [FromBody] UpdateOrderRequest request)
        => await orderService.UpdateOrderExecuteAsync(id, request.Price, request.ShippingDate)
            ? NoContent()
            : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
        => await orderService.DeleteOrderAsync(id) ? NoContent() : NotFound();
}
