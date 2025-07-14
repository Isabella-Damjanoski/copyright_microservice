using Microsoft.AspNetCore.Mvc;
using ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;
using ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Mappers;
using ServiceTitan.ContactCenter.Interactions.Service.Data;
using ServiceTitan.ContactCenter.Interactions.Service.Data.Models;
using MongoDB.Driver;
using ServiceTitan.ContactCenter.Interactions.Service.Data.MongoDocuments;

namespace ContactCenter.Interactions.Service.Api.V1.Controllers;

// [Authorize] // Temporarily commented out for to avoid authentication issues in the test environment
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
[Route("v1/[controller]")]
public class OrdersController(
    IDataService dataService
) : ControllerBase
{
    private readonly IMongoCollection<Order> _ordersCollection = dataService.GetOrdersCollection();

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<OrderOutputDto>> AddOrderAsync(
        [FromBody] OrderCreateDto orderCreateDto
    )
    {
        if (orderCreateDto == null)
        {
            return BadRequest("OrderCreateDto cannot be null.");
        }

        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(orderCreateDto.Name))
        {
            errors.Add("CustomerName is required.");
        }

        if (string.IsNullOrWhiteSpace(orderCreateDto.Email))
        {
            errors.Add("Email is required.");
        }

        if (errors.Any())
        {
            return BadRequest(string.Join(" ", errors));
        }

        var order = OrdersMapper.FromOrderCreateDtoToOrder(
            orderCreateDto
        );

        order = await dataService.AddOrderAsync(order);

        var response = OrdersMapper.FromOrderToOrderOutputDto(order);

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}", Name = "GetOrderAsync")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<OrderOutputDto>> GetOrderAsync(string id)
    {
        var order = await dataService.GetOrderAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        var response = OrdersMapper.FromOrderToOrderOutputDto(order);

        return Ok(response);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchOrdersAsync(
        string? name = null,
        string? orderId = null,
        string? phone = null,
        string? email = null,
        int? status = null,
        DateTime? createdAt = null,
        int page = 1,
        int pageSize = 8)
    {
        var builder = Builders<Order>.Filter;
        var filter = builder.Empty;

        if (!string.IsNullOrWhiteSpace(name))
            filter &= builder.Eq("Customer.Name", name);

        if (!string.IsNullOrWhiteSpace(orderId))
            filter &= builder.Eq("Id", orderId);

        if (!string.IsNullOrWhiteSpace(phone))
            filter &= builder.Eq("Customer.Phone", phone);

        if (!string.IsNullOrWhiteSpace(email))
            filter &= builder.Eq("Customer.Email", email);

        if (status.HasValue)
            filter &= builder.Eq("Status", status.Value);

        if (createdAt.HasValue)
            filter &= builder.Eq("CreatedAt", createdAt.Value);

        var skip = (page - 1) * pageSize;
        var totalOrders = await _ordersCollection.CountDocumentsAsync(filter);

        var orders = await _ordersCollection
            .Find(filter)
            .Skip(skip)
            .Limit(pageSize)
            .ToListAsync();

        var orderDtos = orders.Select(o => new OrderOutputDto
        {
            Id = o.Id,
            CreatedAt = o.CreatedAt,
            UpdatedAt = o.UpdatedAt,
            Status = o.Status,
            ConfidenceScore = o.ConfidenceScore,
            Customer = new CustomerDto
            {
                Name = o.Name,
                Phone = o.Phone,
                Email = o.Email
            },
            Item = o.Items.Select(i => new ItemDto
            {
                ClothingType = i.ClothingType,
                Colour = i.Colour,
                Size = i.Size,
                Quantity = i.Quantity,
                Price = i.Price
            }).ToArray()
        }).ToArray();

        var totalPages = (int)Math.Ceiling((double)totalOrders / pageSize);

        var pageDto = new PageDto
        {
            PageNumber = page,
            TotalPages = totalPages,
            PageSize = pageSize,
            TotalCount = (int)totalOrders,
            Items = orderDtos
        };

        return Ok(pageDto);
    }
}
