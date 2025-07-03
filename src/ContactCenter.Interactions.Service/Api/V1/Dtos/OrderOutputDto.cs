namespace ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;

public record OrderOutputDto
{
    public required string Id { get; set; }

    public required DateTime CreatedAt { get; set; }

    public required DateTime UpdatedAt { get; set; }

    public required int Status { get; set; }

    public required int ConfidenceScore { get; set; }

    public required CustomerDto Customer { get; set; }

    public required ItemDto Item { get; set; }
}

public record CustomerDto
{
    public required string Name { get; set; }

    public string? Phone { get; set; }

    public required string Email { get; set; }
}

public record ItemDto
{
    public required string ClothingType { get; set; }

    public required string Colour { get; set; }

    public required string Size { get; set; }

    public required int Quantity { get; set; }

    public required int Price { get; set; }
}