using ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;
using ServiceTitan.ContactCenter.Interactions.Service.Data.MongoDocuments;
namespace ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Mappers;

public static class OrdersMapper
{
    public static OrderOutputDto FromOrderToOrderOutputDto(Order order)
    {
        return new OrderOutputDto
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            UpdatedAt = order.UpdatedAt,
        };
    }

    public static Order FromOrderCreateDtoToOrder(OrderCreateDto orderCreateDto)
    {
        return new Order
        {
            Version = Order.CurrentVersion,
            Id = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            // Map other properties from orderCreateDto as needed
        };
    }
}