using ServiceTitan.ContactCenter.Interactions.Service.Data.MongoDocuments;
using ServiceTitan.ContactCenter.Interactions.Service.Data.Repositories;

namespace ServiceTitan.ContactCenter.Interactions.Service.Data;

public class DataService(
    IOrdersRepository ordersRepository
) : IDataService
{
    private readonly IOrdersRepository _orderRepository = ordersRepository;

    public async Task<Order?> GetOrderAsync(string id)
    {
        return await _orderRepository.GetOrderAsync(id);
    }

    public async Task<Order> AddOrderAsync(Order order)
    {
        return await _orderRepository.AddOrderAsync(order);
    }

    public async Task<Order?> UpdateOrderAsync(Order order)
    {
        return await _orderRepository.UpdateOrderAsync(order);
    }

    public async Task<Order?> UpdateConfidenceScoreAsync(string id, string confidenceScore)
    {
        return await _orderRepository.UpdateConfidenceScoreAsync(id, confidenceScore);
    }

    public Task<List<Order>> GetOrdersAsync()
    {
        return _orderRepository.GetOrdersAsync();
    }

    // public async Task<Order?> UpdateOrderStatusAsync(string id, OrderStatus status)
    // {
    //     return await _orderRepository.UpdateOrderStatusAsync(id, status);
    // }
}
