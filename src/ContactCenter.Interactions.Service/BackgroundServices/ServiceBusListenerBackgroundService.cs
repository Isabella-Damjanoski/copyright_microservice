using Azure.Messaging.ServiceBus;
using ServiceTitan.ContactCenter.Interactions.Service.Data.Repositories;

namespace ContactCenter.Interactions.Service.BackgroundServices;

public class ServiceBusListenerBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ServiceBusListenerBackgroundService> _logger;
    private readonly string _serviceBusConnectionString;
    private readonly string _topicName;
    private readonly string _subscriptionName;
    private ServiceBusProcessor? _processor;

    public ServiceBusListenerBackgroundService(
        IServiceProvider serviceProvider,
        ILogger<ServiceBusListenerBackgroundService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        // Use correct environment variable names for Service Bus topic
        _serviceBusConnectionString = "Endpoint=sb://imageclassificationbus.servicebus.windows.net/;SharedAccessKeyName=imagepolicy;SharedAccessKey=zJVxaxLMu9cnYvGXZXNzYlvSI7ec6PIt1+ASbLXi41Q=;EntityPath=imageclassificationtopic"; //Environment.GetEnvironmentVariable("SERVICE_BUS_CONNECTION_STRING") ?? string.Empty;
        _topicName = Environment.GetEnvironmentVariable("SERVICE_BUS_TOPIC_NAME") ?? "imageclassificationtopic";
        // Set your subscription name here (must exist in Azure Service Bus)
        _subscriptionName = Environment.GetEnvironmentVariable("SERVICE_BUS_SUBSCRIPTION_NAME") ?? "imagesub";
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        var client = new ServiceBusClient(_serviceBusConnectionString);
        // Use topic and subscription for processor
        _processor = client.CreateProcessor(_topicName, _subscriptionName, new ServiceBusProcessorOptions());
        _processor.ProcessMessageAsync += ProcessMessageHandlerAsync;
        _processor.ProcessErrorAsync += ErrorHandlerAsync;
        await _processor.StartProcessingAsync(cancellationToken);
        _logger.LogInformation($"Service Bus topic listener started for topic '{_topicName}' and subscription '{_subscriptionName}'.");
        await base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // No implementation needed here, handled in StartAsync
        await Task.CompletedTask;
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        if (_processor != null)
        {
            await _processor.StopProcessingAsync(cancellationToken);
            await _processor.DisposeAsync();
        }
        _logger.LogInformation("Service Bus listener stopped.");
        await base.StopAsync(cancellationToken);
    }

    private async Task ProcessMessageHandlerAsync(ProcessMessageEventArgs args)
    {
        try
        {
            // Expecting OrderId and ConfidenceScore in message properties
            var orderId = args.Message.ApplicationProperties.ContainsKey("OrderId")
                ? args.Message.ApplicationProperties["OrderId"]?.ToString()
                : null;
            var confidenceScore = args.Message.ApplicationProperties.ContainsKey("ConfidenceScore")
                ? Convert.ToInt32(args.Message.ApplicationProperties["ConfidenceScore"])
                : (int?)null;

            if (!string.IsNullOrEmpty(orderId) && confidenceScore.HasValue)
            {
                using var scope = _serviceProvider.CreateScope();
                var repo = scope.ServiceProvider.GetRequiredService<IOrdersRepository>();
                var order = await repo.GetOrderAsync(orderId);
                if (order != null)
                {
                    order.ConfidenceScore = confidenceScore.Value;
                    await repo.UpdateOrderAsync(order);
                    _logger.LogInformation($"Order {orderId} updated with confidence score {confidenceScore.Value}.");
                }
            }

            await args.CompleteMessageAsync(args.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing Service Bus message.");
        }
    }

    private Task ErrorHandlerAsync(ProcessErrorEventArgs args)
    {
        _logger.LogError(args.Exception, $"Service Bus error: {args.Exception.Message}");
        return Task.CompletedTask;
    }
}
