using Hospital.API.Contracts.Requests;
using Hospital.API.Contracts.Responses;
using Hospital.Common.Models.Patient;
using Refit;

namespace Hospital.API.Abstraction;

public interface IPatientApi
{
    [Post("/api/Patient")]
    Task<BaseCreateResponse> Create([Body] CreatePatientRequest createPatientRequest);

    
    [Get("/api/Patient/{patientId})")]
    public Task<PatientModel> Get(long patientId);
}