namespace ServiceTitan.ContactCenter.Interactions.Service.Data.Models;

public class PagedResult<T>
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public double TotalCount { get; set; }

    public double TotalPages { get; set; }

    public required IReadOnlyList<T> Items { get; set; }
}
