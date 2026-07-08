using Business;
using DatabaseLayer;

namespace ServiceLayer;

public class ProductService(ProductRepository productRepository)
{
    public Task<List<Products>> GetAllProductsAsync() => productRepository.GetAllAsync();

    public Task<Products?> GetProductByIdAsync(int id) => productRepository.GetAsync(id);

    public Task<Products?> GetProductByNameAsync(string name) => productRepository.GetByNameAsync(name);

    public Task<Products> CreateProductAsync(string name, double number, string description)
    {
        var product = new Products
        {
            Name = name,
            Number = number,
            Description = description
        };

        return productRepository.CreateAsync(product);
    }

    public Task<bool> UpdateProductAsync(int id, string name, double number, string description) =>
        productRepository.UpdateAsync(id, name, number, description);

    public Task<bool> UpdateProductExecuteAsync(int id, string name, double number, string description) =>
        productRepository.UpdateExecuteAsync(id, name, number, description);

    public Task<bool> DeleteProductAsync(int id) => productRepository.DeleteAsync(id);
}
