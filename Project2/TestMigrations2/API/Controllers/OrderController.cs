using Business;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]

public class OrderController(OrderService orderService) : ControllerBase
{
    [HttpGet("orders/{n:int}")]
    public IEnumerable<Order> GetOrders([FromRoute] int n, [FromQuery] int n2 )
    {
        return orderService.GetAllOrders();
    }

    [HttpPost("AddOrder")]
    public void AddOrder([FromBody] decimal price,[FromQuery] DateOnly date)
    {
        orderService.CreateOrder(new Order(){Price = price, ShippingDate = date});
    }
}