namespace ServiceTitan.ContactCenter.Interactions.Service.Api.V1.Dtos;

public record PageDto
{
    public required int PageNumber { get; set; }
    public required int PageSize { get; set; }
    public required int TotalCount { get; set; }
    public required int TotalPages { get; set; }
    public required OrderOutputDto[] Items { get; set; }

    public PageDto(int pageNumber, int totalPages, int pageSize, int totalCount, OrderOutputDto[] items)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = totalPages;
        Items = items;
    }
}