namespace ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;

public record OrderCreateDto
{
    public required string CustomerName { get; set; }

    public required string Email { get; set; }

    public string? Phone { get; set; }
}
