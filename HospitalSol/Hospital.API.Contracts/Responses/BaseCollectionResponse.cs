namespace Hospital.API.Contracts.Responses;

public class BaseCollectionResponse<T>
{
    public IReadOnlyCollection<T> Items { get; set; }
    public long TotalCount { get; set; }
}