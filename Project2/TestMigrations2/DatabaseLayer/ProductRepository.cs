using Business;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class ProductRepository(DataContext context)
{
    public async Task<Products> CreateAsync(Products product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<List<Products>> GetAllAsync()
    {
        return await context.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Products?> GetAsync(int id)
    {
        return await context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Products?> GetByNameAsync(string name)
    {
        return await context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Name == name);
    }

    // Update variant #1: tracked entity + SaveChangesAsync.
    public async Task<bool> UpdateAsync(int id, string name, double number, string description)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
            return false;

        product.Name = name;
        product.Number = number;
        product.Description = description;
        await context.SaveChangesAsync();
        return true;
    }

    // Update variant #2: ExecuteUpdateAsync, no tracking. (Not supported by InMemory.)
    public async Task<bool> UpdateExecuteAsync(int id, string name, double number, string description)
    {
        return await context.Products
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(p => p.Name, name)
                .SetProperty(p => p.Number, number)
                .SetProperty(p => p.Description, description)) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
            return false;

        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return true;
    }
}
