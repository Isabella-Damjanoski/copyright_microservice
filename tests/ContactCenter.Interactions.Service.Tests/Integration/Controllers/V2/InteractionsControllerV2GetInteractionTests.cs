using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;
using ServiceTitan.ContactCenter.Interactions.Service.Data;
using ServiceTitan.ContactCenter.Interactions.Service.Data.MongoDocuments;

namespace ServiceTitan.ContactCenter.Interactions.Service.Tests.Integration.Controllers.V2;

public class OrdersControllerTests : IClassFixture<OrdersControllerTestFixture>
{
    private readonly HttpClient _client;

    private readonly IDataService _dataService;
    private readonly OrdersControllerTestFixture _factory;
    private const string BASE_V1_API_URL = "/v1/orders";

    public OrdersControllerTests(OrdersControllerTestFixture factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
        _dataService = factory.Services.GetRequiredService<IDataService>();
    }

    [Fact]
    public async Task GetOrder_WhenCalledWithOrderThatDoesntExist_ShouldReturnNotFound()
    {
        // Arrange
        var nonExistentOrderId = Guid.NewGuid().ToString();

        // Act
        var response = await _client.GetAsync($"{BASE_V1_API_URL}/{nonExistentOrderId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetOrder_WhenCalledWithOrderThatDoesExist_ShouldReturnOk()
    {
        // Arrange
        var order = await CreateOrderAsync();

        // Act
        var response = await _client.GetAsync($"{BASE_V1_API_URL}/{order.Id}");
        var responseBody = await response.Content.ReadFromJsonAsync<OrderOutputDto>();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNull();
        responseBody!.Id.Should().Be(order.Id);
    }

    [Fact]
    public async Task PostOrder_WhenCalledWithValidOrder_ShouldReturnCreated()
    {
        // Arrange
        var orderJson = """
        {
            "name": "John Doe",
            "confidenceScore": "high",
            "phone": "+1234567890",
            "email": "john.doe@example.com",
            "items": [
                {
                    "clothingType": "T-Shirt",
                    "colour": "Blue",
                    "size": "M",
                    "quantity": 2,
                    "price": 25
                },
                {
                    "clothingType": "Jeans",
                    "colour": "Black",
                    "size": "32",
                    "quantity": 1,
                    "price": 60
                }
            ]
        }
        """;

        var content = new StringContent(orderJson, System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync(BASE_V1_API_URL, content);

        // Assert
        response.StatusCode.Should().BeOneOf(HttpStatusCode.Created, HttpStatusCode.OK);

        // Optionally, verify the response content
        var responseContent = await response.Content.ReadAsStringAsync();
        responseContent.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task PostOrder_WhenCalledWithInvalidOrder_ShouldReturnBadRequest()
    {
        // Arrange - Missing required fields
        var invalidOrderJson = """
        {
            "name": "",
            "email": "invalid-email"
        }
        """;

        var content = new StringContent(invalidOrderJson, System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync(BASE_V1_API_URL, content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task PostOrder_WhenCalledWithEmptyBody_ShouldReturnBadRequest()
    {
        // Arrange
        var content = new StringContent("", System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync(BASE_V1_API_URL, content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    private Task<Order> CreateOrderAsync()
    {
        var order = new Order
        {
            Version = 1,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Id = Guid.NewGuid().ToString(),
            Status = 1,
            Name = "Test Order",
            ConfidenceScore = "0.95",
            Phone = "+1234567890",
            Email = "test@example.com",
            Items = []
        };

        return _dataService.AddOrderAsync(order);
    }
}

public class OrdersControllerTestFixture : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Add test-specific services here if needed
            // For example, you might want to replace the real database with an in-memory one

            // Override logging to reduce noise in tests
            services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Warning));
        });

        builder.UseEnvironment("Test");

        // You can override configuration here
        // builder.ConfigureAppConfiguration((context, config) =>
        // {
        //     // Add test-specific configuration
        //     config.AddInMemoryCollection(new Dictionary<string, string?>
        //     {
        //         ["MongoDbConnectionString"] = "mongodb://localhost:27017",
        //         ["MongoDbDatabase"] = "TestDatabase"
        //     });
        // });
    }
}