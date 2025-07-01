using NodaTime;
using ServiceTitan.ContactCenter.Interactions.Service.Modules;

namespace ServiceTitan.ContactCenter.Interactions.Service;

public static class Startup
{
    public static void ConfigureConfiguration(this WebApplicationBuilder builder, string[] args) =>
        builder
            .Configuration.AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
            .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            // Settings overriden by tests will be injected here
            .AddCommandLine(args);

    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddModule<ApiModule>();
        services.AddModule<DataModule>();
    }

    public static void ConfigureApplicationMiddleware(this WebApplication app)
    {
        app.AddModule<ApiModule>();
    }
}
