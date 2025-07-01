using ServiceTitan.ContactCenter.Interactions.Service;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureConfiguration(args);
builder.ConfigureServices();

var app = builder.Build();
app.ConfigureApplicationMiddleware();

await app.RunAsync();

// Necessary to make Program class visible to tests with WebApplicationFactory
#pragma warning disable S1118 // Utility classes should not have public constructors
public partial class Program;
