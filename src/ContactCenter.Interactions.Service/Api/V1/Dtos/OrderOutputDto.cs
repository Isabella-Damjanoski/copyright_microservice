namespace ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;

public record OrderOutputDto
{
    public required string Id { get; set; }

    public required DateTime CreatedAt { get; set; }

    public required DateTime UpdatedAt { get; set; }

    public required int Status { get; set; }
}
