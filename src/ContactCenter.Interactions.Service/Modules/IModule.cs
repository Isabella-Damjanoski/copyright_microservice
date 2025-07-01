namespace ServiceTitan.ContactCenter.Interactions.Service.Modules;

/// <summary>
/// A well-defined interface for configuring a module of services to DI
/// </summary>
public interface IModule
{
    /// <summary>
    /// Configure the DI services for this module
    /// </summary>
    [ExcludeFromCodeCoverage]
    static virtual void ConfigureServices(IServiceCollection services) { }

    /// <summary>
    /// Configure the DI services for this module with app builder object to pass configuration
    /// </summary>
    [ExcludeFromCodeCoverage]
    static virtual void ConfigureServices(IServiceCollection services, WebApplicationBuilder appBuilder) { }
}

public static class ModuleExtensions
{
    /// <summary>
    /// Add the given <see cref="IModule"/>'s services to DI
    /// </summary>
    public static IServiceCollection AddModule<T>(
        this IServiceCollection services,
        WebApplicationBuilder? appBuilder = null
    )
        where T : IModule
    {
        if (appBuilder != null)
        {
            T.ConfigureServices(services, appBuilder);
        }
        else
        {
            T.ConfigureServices(services);
        }

        return services;
    }
}
