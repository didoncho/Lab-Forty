using Business;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class OrderRepository(DataContext context)
{
    // Create: an Order does not create a User or Products - it attaches EXISTING ones.
    // The user is attached by its foreign key; the products are loaded (tracked) and
    // linked so EF only writes the join rows instead of inserting new products.
    public async Task<Order> CreateAsync(decimal price, DateOnly shippingDate, int userId, List<int> productIds)
    {
        var products = await context.Products
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync();

        var order = new Order
        {
            Price = price,
            ShippingDate = shippingDate,
            UserId = userId,
            Products = products
        };

        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return order;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await context.Orders
            .AsNoTracking()
            .Include(o => o.User)
            .Include(o => o.Products)
            .ToListAsync();
    }

    public async Task<Order?> GetAsync(int id)
    {
        return await context.Orders
            .AsNoTracking()
            .Include(o => o.User)
            .Include(o => o.Products)
            .FirstOrDefaultAsync(o => o.ID == id);
    }

    public async Task<Order?> GetByDateAsync(DateOnly date)
    {
        return await context.Orders
            .AsNoTracking()
            .Include(o => o.User)
            .Include(o => o.Products)
            .FirstOrDefaultAsync(o => o.ShippingDate == date);
    }

    // Update variant #1: tracked entity + SaveChangesAsync.
    public async Task<bool> UpdateAsync(int id, decimal price, DateOnly shippingDate)
    {
        var order = await context.Orders.FirstOrDefaultAsync(o => o.ID == id);
        if (order is null)
            return false;

        order.Price = price;
        order.ShippingDate = shippingDate;
        await context.SaveChangesAsync();
        return true;
    }

    // Update variant #2: ExecuteUpdateAsync, no tracking. (Not supported by InMemory.)
    public async Task<bool> UpdateExecuteAsync(int id, decimal price, DateOnly shippingDate)
    {
        return await context.Orders
            .Where(o => o.ID == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(o => o.Price, price)
                .SetProperty(o => o.ShippingDate, shippingDate)) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await context.Orders.FirstOrDefaultAsync(o => o.ID == id);
        if (order is null)
            return false;

        context.Orders.Remove(order);
        await context.SaveChangesAsync();
        return true;
    }
}
