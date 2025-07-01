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

    public string Id { get; init; } = $"{Guid.NewGuid()}";

    public required DateTime CreatedAt { get; set; }

    public required DateTime UpdatedAt { get; set; }
}