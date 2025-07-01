using System.Reflection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ServiceTitan.ContactCenter.Interactions.Service.Data;
using ServiceTitan.ContactCenter.Interactions.Service.Data.Repositories;

namespace ServiceTitan.ContactCenter.Interactions.Service.Modules;

public class DataModule : IModule
{
    private static readonly Assembly _assembly = Assembly.GetExecutingAssembly();

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IMongoDatabase>(serviceProvider =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetValue<string>("MongoDbConnectionString");
            var databaseName = configuration.GetValue<string>("MongoDbDatabase");
            var logger = serviceProvider.GetRequiredService<ILogger<DataModule>>();
            logger.LogInformation(
                "Initializing MongoDb database with ConnectionString: {ConnectionString}, Database: {Database}",
                connectionString, databaseName
            );
            var mongoClient = new MongoClient(connectionString);
            return mongoClient.GetDatabase(databaseName);
        });

        // DataService and Repositories
        services.AddTransient<IDataService, DataService>();
        services.AddTransient<IOrdersRepository, OrdersRepository>();
    }
}