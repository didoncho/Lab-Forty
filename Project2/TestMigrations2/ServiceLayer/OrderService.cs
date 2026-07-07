using Business;
using DatabaseLayer;

namespace ServiceLayer;

public class OrderService(OrderRepository orderRepository)
{
    public List<Order> GetAllOrders()
    {
        return orderRepository.GetAll();
    }

    public void CreateOrder(Order order)
    {
        orderRepository.Created(order);
    }

    public Order? GetOrderByDate(DateOnly date)
    {
        return orderRepository.GetByDate(date);
    }

    public Order? GetOrderById(int id)
    {
        return orderRepository.Get(id);
    }
}