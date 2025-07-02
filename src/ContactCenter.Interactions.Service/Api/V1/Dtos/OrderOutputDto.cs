namespace ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;

public record OrderOutputDto
{
    public required string Id { get; set; }

    public required DateTime CreatedAt { get; set; }

    public required DateTime UpdatedAt { get; set; }

    public required int Status { get; set; }

    public required string CustomerName { get; set; }

    public required string Email { get; set; }

    public string? Phone { get; set; }
}
