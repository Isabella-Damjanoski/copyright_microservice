using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Extensions.Migration;

namespace ServiceTitan.ContactCenter.Interactions.Service.Data.MongoDocuments;

[BsonIgnoreExtraElements]
public record Order : IVersioned
{
    internal const int CurrentVersion = 1;

    public required int Version { get; set; } = CurrentVersion;

    [BsonId]
    [UsedImplicitly]
    private ObjectId ObjectId { get; set; }

    public string Id { get; set; }

    public required DateTime CreatedAt { get; set; }

    public required DateTime UpdatedAt { get; set; }

    public required int? Status { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public string? Phone { get; set; }

    public required string ConfidenceScore { get; set; }

    public required List<OrderItem> Items { get; set; }
}

public class OrderItem
{
   public required string ClothingType { get; set; }

    public required string Colour { get; set; }

    public required string Size { get; set; }

    public required int Quantity { get; set; }

    public required int Price { get; set; }
}