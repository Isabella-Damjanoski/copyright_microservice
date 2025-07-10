using ServiceTitan.ContactCenter.Interactions.Service.Data.MongoDocuments;

namespace ServiceTitan.ContactCenter.Interactions.Service.Data.Repositories;

public interface IOrdersRepository
{
    public Task<Order?> GetOrderAsync(string id);

    public Task<Order> AddOrderAsync(Order order);

    public Task<Order?> UpdateOrderAsync(Order order);

    public Task<Order?> UpdateConfidenceScoreAsync(string id, string confidenceScore);
};