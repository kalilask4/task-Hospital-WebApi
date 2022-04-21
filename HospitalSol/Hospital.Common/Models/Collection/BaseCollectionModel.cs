namespace Hospital.Common.Models.Collection;

public class BaseCollectionModel<T> where T: class
{
    public IReadOnlyCollection<T> Items { get; set; }
    public long TotalCount { get; set; }
}