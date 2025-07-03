using DocumentFormat.OpenXml.Presentation;
using ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;
using ServiceTitan.ContactCenter.Interactions.Service.Data.MongoDocuments;
namespace ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Mappers;

public static class OrdersMapper
{
    public static OrderOutputDto FromOrderToOrderOutputDto(Order order)
    {
        var listOfItems = new List<ItemDto>
        {
            {
                new ItemDto
                {
                    ClothingType = order.ClothingType,
                    Colour = order.Colour,
                    Size = order.Size,
                    Quantity = order.Quantity,
                    Price = order.Price
                }
            }
        };

        var OrderOutput = new OrderOutputDto
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            UpdatedAt = order.UpdatedAt,
            Status = order.Status ?? default(int),
            ConfidenceScore = order.ConfidenceScore,
            Customer = new CustomerDto
            {
                Name = order.Name,
                Phone = order.Phone,
                Email = order.Email
            },
            Item = listOfItems.ToArray()
        };

        return OrderOutput
    }


    public static Order FromOrderCreateDtoToOrder(OrderCreateDto orderCreateDto)
    {
        return new Order
        {
            Version = Order.CurrentVersion,
            Id = Guid.NewGuid().ToString(),
            Name = orderCreateDto.Name,
            ConfidenceScore = orderCreateDto.ConfidenceScore,
            Phone = orderCreateDto.Phone,
            Email = orderCreateDto.Email,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Status = null,
            // Map other properties from orderCreateDto as needed
            ClothingType = orderCreateDto.ClothingType,
            Colour = orderCreateDto.Colour,
            Size = orderCreateDto.Size,
            Quantity = orderCreateDto.Quantity,
            Price = orderCreateDto.Price
        };
    }
}