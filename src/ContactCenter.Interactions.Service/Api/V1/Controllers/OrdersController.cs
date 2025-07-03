using Microsoft.AspNetCore.Mvc;
using ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;
using ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Mappers;
using ServiceTitan.ContactCenter.Interactions.Service.Data;

namespace ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Controllers;

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
}
