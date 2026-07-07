using Business;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class OrderRepository(DataContext context)
{
    public List<Order> GetAll()
    {
        Created();
        return context.Orders.ToList();
    }

    public void Created()
    {
        context.Orders.Add(new Order()
        {
            Price = 0,
            Products = []
        });
        context.SaveChanges();
    }
    
    public void Created(Order order)
    {
        context.Orders.Add(order);
        context.SaveChanges();
    }

    public Order? GetByDate(DateOnly date)
    {
        Created();
        return context.Orders.FirstOrDefault(p => p.ShippingDate == date);
    }

    public Order? Get(int id)
    {
        Created();
        return context.Orders.AsNoTracking().FirstOrDefault(p => p.ID == id);
    }

    public void Update(int id, DateOnly newShippingDate)
    {
        Created();
        var order = Get(id);
        if (order == null)
            return;
        
        order.ShippingDate = newShippingDate;
        context.SaveChanges();
    }
}