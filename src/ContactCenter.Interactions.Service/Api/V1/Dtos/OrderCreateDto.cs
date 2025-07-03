namespace ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;

public record OrderCreateDto
{
    public required string Name { get; set; }

    public required int ConfidenceScore { get; set; }

    public string? Phone { get; set; }

    public required string Email { get; set; }

    public required string ClothingType { get; set; }

    public required string Colour { get; set; }

    public required string Size { get; set; }

    public required int Quantity { get; set; }

    public required int Price { get; set; }

}
