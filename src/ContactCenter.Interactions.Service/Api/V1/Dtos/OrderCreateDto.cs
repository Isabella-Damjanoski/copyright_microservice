namespace ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;

public record OrderCreateDto
{
    public required string Name { get; set; }
    public required int ConfidenceScore { get; set; }
    public string? Phone { get; set; }
    public required string Email { get; set; }
    public required List<ItemDto> Items { get; set; }
}
