using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;
using ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Mappers;
using ServiceTitan.ContactCenter.Interactions.Service.Data;

namespace ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Controllers;

[Authorize]
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
