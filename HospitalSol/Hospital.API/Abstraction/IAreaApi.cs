using Hospital.Common.Models.Doctor;
using Refit;

namespace Hospital.API.Abstraction;


public interface IAreaApi
{
    [Get("/api/Area/{areaId})")]
    public Task<AreaModel> Get(long areaId);
}