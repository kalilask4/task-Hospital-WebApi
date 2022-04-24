using Hospital.API.Contracts.Requests;
using Hospital.API.Contracts.Responses;
using Hospital.Common.Models.Doctor;
using Refit;

namespace Hospital.API.Abstraction;

public interface IDoctorApi
{
    [Post("/api/Doctor")]
    Task<BaseCreateResponse> Create([Body] CreateDoctorRequest createDoctorRequest);


    [Get("/api/Doctor/{doctorId})")]
    public Task<DoctorModel> Get(long doctorId);
}