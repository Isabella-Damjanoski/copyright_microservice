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
        order.CreatedAt = SystemClock.Instance.GetCurrentInstant().ToDateTimeUtc();
        order.UpdatedAt = order.CreatedAt;
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
}
