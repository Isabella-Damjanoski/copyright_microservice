namespace ServiceTitan.ContactCenter.Interactions.Service.Modules;

/// <summary>
/// Configures an application module to configure the WebApplication further
/// </summary>
/// <remarks>
/// We should always use a web application (even for workers) as it enables health checks in k8s, etc
/// </remarks>
public interface IApplicationModule
{
    static abstract void ConfigureApplication(WebApplication app);
}

public static class ApplicationModuleExtensions
{
    /// <summary>
    /// Invokes the given <see cref="IApplicationModule"/>'s <see cref="IApplicationModule.ConfigureApplication(WebApplication)"/> method
    /// </summary>
    public static WebApplication AddModule<T>(this WebApplication app)
        where T : IApplicationModule
    {
        T.ConfigureApplication(app);

        return app;
    }
}
