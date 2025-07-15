using MongoDB.Driver;
using ServiceTitan.ContactCenter.Interactions.Service.Data.MongoDocuments;

namespace ServiceTitan.ContactCenter.Interactions.Service.Data;

public interface IDataService
{
    public Task<Order?> GetOrderAsync(string id);

    public Task<Order> AddOrderAsync(Order order);

    public Task<Order?> UpdateOrderAsync(Order order);

    public Task<Order?> UpdateConfidenceScoreAsync(string id, string confidenceScore);

    public Task<List<Order>> GetOrdersAsync();
};
