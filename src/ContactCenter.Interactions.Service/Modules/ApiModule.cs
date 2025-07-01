using Microsoft.OpenApi.Models;

namespace ServiceTitan.ContactCenter.Interactions.Service.Modules;

public class ApiModule : IModule, IApplicationModule
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(genOptions =>
        {
            genOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "Interactions Service V1", Version = "v1" });
            genOptions.SwaggerDoc("v2", new OpenApiInfo { Title = "Interactions Service V2", Version = "v2" });
        });

        services.AddHttpLogging(_ => { });
    }

    public static void ConfigureApplication(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(uiOptions =>
        {
            uiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            uiOptions.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
        });

        app.UseHttpLogging();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
    }
}
