using Hospital.Common.Models;
using Hospital.Common.Models.Collection;

namespace Hospital.API.Contracts.Requests;

public class GetListRequest<T>: Pagination where T: class
{
    public T? Filter { get; set; }

    public string SortBy { get; set; }
    public SortOrder SortOrder { get; set; }
}