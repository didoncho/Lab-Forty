using Business;
using DatabaseLayer;

namespace ServiceLayer;

public class OrderService(OrderRepository orderRepository)
{
    public Task<List<Order>> GetAllOrdersAsync() => orderRepository.GetAllAsync();

    public Task<Order?> GetOrderByIdAsync(int id) => orderRepository.GetAsync(id);

    public Task<Order?> GetOrderByDateAsync(DateOnly date) => orderRepository.GetByDateAsync(date);

    // Attaches an existing user and existing products to a new order.
    public Task<Order> CreateOrderAsync(decimal price, DateOnly shippingDate, int userId, List<int> productIds) =>
        orderRepository.CreateAsync(price, shippingDate, userId, productIds ?? []);

    public Task<bool> UpdateOrderAsync(int id, decimal price, DateOnly shippingDate) =>
        orderRepository.UpdateAsync(id, price, shippingDate);

    public Task<bool> UpdateOrderExecuteAsync(int id, decimal price, DateOnly shippingDate) =>
        orderRepository.UpdateExecuteAsync(id, price, shippingDate);

    public Task<bool> DeleteOrderAsync(int id) => orderRepository.DeleteAsync(id);
}
