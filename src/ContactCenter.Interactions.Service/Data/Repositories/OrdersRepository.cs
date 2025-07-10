using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NodaTime;
using ServiceTitan.ContactCenter.Interactions.Service.Data.MongoDocuments;

namespace ServiceTitan.ContactCenter.Interactions.Service.Data.Repositories;

public class OrdersRepository(
    IMongoDatabase mongoDatabase
) : IOrdersRepository
{
    private readonly IMongoCollection<Order> _ordersCollection = mongoDatabase.GetCollection<Order>("orders");

    public async Task<Order?> GetOrderAsync(string id)
    {
        var filter = Builders<Order>.Filter.Eq(o => o.Id, id);
        return await _ordersCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Order> AddOrderAsync(Order order)
    {
        if (string.IsNullOrWhiteSpace(order.Name))
            throw new ArgumentException("CustomerName is required.", nameof(order.Name));
        if (string.IsNullOrWhiteSpace(order.Email))
            throw new ArgumentException("Email is required.", nameof(order.Email));

        order.CreatedAt = SystemClock.Instance.GetCurrentInstant().ToDateTimeUtc();
        order.UpdatedAt = order.CreatedAt;
        order.Status = 1;
        await _ordersCollection.InsertOneAsync(order);
        return order;
    }

    public async Task<Order?> UpdateOrderAsync(Order order)
    {
        order.UpdatedAt = SystemClock.Instance.GetCurrentInstant().ToDateTimeUtc();
        var filter = Builders<Order>.Filter.Eq(o => o.Id, order.Id);
        var update = Builders<Order>.Update
            .Set(o => o.UpdatedAt, order.UpdatedAt)
            .Set(o => o.Version, order.Version + 1);

        var result = await _ordersCollection.FindOneAndUpdateAsync(filter, update);
        return result;
    }

    public async Task<Order?> UpdateConfidenceScoreAsync(string id, string confidenceScore)
    {
        var filter = Builders<Order>.Filter.Eq(o => o.Id, id);
        var update = Builders<Order>.Update
            .Set(o => o.ConfidenceScore, confidenceScore)
            .Set(o => o.UpdatedAt, SystemClock.Instance.GetCurrentInstant().ToDateTimeUtc());

        var result = await _ordersCollection.FindOneAndUpdateAsync(filter, update);
        return result;
    }
}
