using System.Text.Json;
using Azure.Messaging.ServiceBus;

namespace ContactCenter.Interactions.Service.BackgroundServices;

public class ServiceBusListenerBackgroundService : BackgroundService
{
    private readonly ILogger<ServiceBusListenerBackgroundService> _logger;
    private readonly string _serviceBusConnectionString;
    private readonly string _topicName;
    private readonly string _subscriptionName;
    private ServiceBusProcessor? _processor;

    public ServiceBusListenerBackgroundService(
        ILogger<ServiceBusListenerBackgroundService> logger)
    {
        _logger = logger;
        _serviceBusConnectionString = "Endpoint=sb://imageclassificationbus.servicebus.windows.net/;SharedAccessKeyName=imagepolicy;SharedAccessKey=zJVxaxLMu9cnYvGXZXNzYlvSI7ec6PIt1+ASbLXi41Q=;EntityPath=imageclassificationtopic";
        _topicName = Environment.GetEnvironmentVariable("SERVICE_BUS_TOPIC_NAME") ?? "imageclassificationtopic";
        _subscriptionName = Environment.GetEnvironmentVariable("SERVICE_BUS_SUBSCRIPTION_NAME") ?? "imagesub";
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        var client = new ServiceBusClient(_serviceBusConnectionString);
        _processor = client.CreateProcessor(_topicName, _subscriptionName, new ServiceBusProcessorOptions());
        _processor.ProcessMessageAsync += ProcessMessageHandlerAsync;
        _processor.ProcessErrorAsync += ErrorHandlerAsync;
        await _processor.StartProcessingAsync(cancellationToken);
        _logger.LogInformation($"Service Bus topic listener started for topic '{_topicName}' and subscription '{_subscriptionName}'.");
        await base.StartAsync(cancellationToken);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.CompletedTask;
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
        _logger.LogInformation("Received Service Bus message:");
        foreach (var prop in args.Message.ApplicationProperties)
        {
            _logger.LogInformation($"Property: {prop.Key} = {prop.Value}");
        }
        var body = args.Message.Body.ToString();
        _logger.LogInformation($"Message Body: {body}");

        // Parse probability and calculate confidencescore
        try
        {
            using var doc = JsonDocument.Parse(body);
            if (doc.RootElement.TryGetProperty("probability", out var probabilityElement))
            {
                double probability = probabilityElement.GetDouble();
                double confidenceScore = Math.Round(probability);
                _logger.LogInformation($"ConfidenceScore: {confidenceScore}");
                // You can now use confidenceScore as needed
            }
            else
            {
                _logger.LogWarning("Probability property not found in message body.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to parse message body for probability.");
        }

        await args.CompleteMessageAsync(args.Message);
    }

    private Task ErrorHandlerAsync(ProcessErrorEventArgs args)
    {
        _logger.LogError(args.Exception, $"Service Bus error: {args.Exception.Message}");
        return Task.CompletedTask;
    }
}
