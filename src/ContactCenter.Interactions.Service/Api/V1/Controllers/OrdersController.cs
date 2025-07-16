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
        string? id = null,
        string? confidenceScore = null,
        string? name = null,
        string? phone = null,
        string? email = null,
        string? clothingType = null,
        string? colour = null,
        string? size = null,
        int? quantity = null,
        int? price = null,
        int page = 1,
        int pageSize = 8)
    {
        var allOrders = await dataService.GetOrdersAsync();

        var filteredOrders = allOrders.Where(o =>
            (string.IsNullOrWhiteSpace(id) || o.Id == id) &&
            (string.IsNullOrWhiteSpace(confidenceScore) || o.ConfidenceScore == confidenceScore) &&
            (string.IsNullOrWhiteSpace(name) || o.Name == name) &&
            (string.IsNullOrWhiteSpace(phone) || o.Phone == phone) &&
            (string.IsNullOrWhiteSpace(email) || o.Email == email) &&
            (clothingType == null || o.Items.Any(i => i.ClothingType == clothingType)) &&
            (colour == null || o.Items.Any(i => i.Colour == colour)) &&
            (size == null || o.Items.Any(i => i.Size == size)) &&
            (!quantity.HasValue || o.Items.Any(i => i.Quantity == quantity.Value)) &&
            (!price.HasValue || o.Items.Any(i => i.Price == price.Value))
        ).ToList();

        var totalOrders = filteredOrders.Count;
        var totalPages = (int)Math.Ceiling((double)totalOrders / pageSize);
        var pagedOrders = filteredOrders.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        var orderDtos = pagedOrders.Select(o => new OrderOutputDto
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
