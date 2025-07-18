using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Extensions.Migration;
using ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;

namespace ServiceTitan.ContactCenter.Interactions.Service.Data.MongoDocuments;

[BsonIgnoreExtraElements]
public record Order : IVersioned
{
    internal const int CurrentVersion = 1;

    public required int Version { get; set; } = CurrentVersion;

    [BsonId]
    [UsedImplicitly]
    private ObjectId ObjectId { get; set; }

    public string Id { get; init; } = $"{Guid.NewGuid()}";

    public required DateTime CreatedAt { get; set; }

    public required DateTime UpdatedAt { get; set; }

    public required int Status { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string? Phone { get; set; }

    public required string ConfidenceScore { get; set; }

    public required List<OrderItem> Items { get; set; }

    internal object Select(Func<object, ItemDto> value) => throw new NotImplementedException();
}

public class OrderItem
{
   public required string ClothingType { get; set; }

    public required string Colour { get; set; }

    public required string Size { get; set; }

    public required int Quantity { get; set; }

    public required int Price { get; set; }
}