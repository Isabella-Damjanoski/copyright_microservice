using ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;
using ServiceTitan.ContactCenter.Interactions.Service.Data.MongoDocuments;
namespace ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Mappers;

public static class OrdersMapper
{
    public static OrderOutputDto FromOrderToOrderOutputDto(Order order)
    {
        var listOfItems = new List<ItemDto>();

        if (order.Items != null)
        {
            foreach (var item in order.Items)
            {
                listOfItems.Add(new ItemDto
                {
                    ClothingType = item.ClothingType,
                    Colour = item.Colour,
                    Size = item.Size,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }
        }

        var OrderOutput = new OrderOutputDto
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            UpdatedAt = order.UpdatedAt,
            Status = order.Status,
            ConfidenceScore = order.ConfidenceScore,
            Customer = new CustomerDto
            {
                Name = order.Name,
                Phone = order.Phone,
                Email = order.Email
            },
            Item = listOfItems.ToArray()
        };

        return OrderOutput;
    }

    public static Order FromOrderCreateDtoToOrder(OrderCreateDto orderCreateDto)
    {
        var order = new Order
        {
            Version = Order.CurrentVersion,
            Id = Guid.NewGuid().ToString(),
            Name = orderCreateDto.Name,
            ConfidenceScore = orderCreateDto.ConfidenceScore,
            Phone = orderCreateDto.Phone,
            Email = orderCreateDto.Email,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Status = 1,
            // Map other properties from orderCreateDto as needed
            Items = new List<OrderItem>()
        };

        if (orderCreateDto.Items != null)
        {
            foreach (var item in orderCreateDto.Items)
            {
                order.Items.Add(new OrderItem
                {
                    ClothingType = item.ClothingType,
                    Colour = item.Colour,
                    Size = item.Size,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }
        }
        return order;
    }
}