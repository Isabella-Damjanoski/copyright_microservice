namespace ServiceTitan.ContactCenter.Interactions.Service.Api;

public class HealthCheckDto
{
    public required string Name { get; init; }
    public required string Status { get; init; }
    public required string Version { get; init; }
    public required string Env { get; init; }
}
