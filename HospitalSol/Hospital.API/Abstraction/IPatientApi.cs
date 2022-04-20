using Hospital.Abstraction.Entities;
using Hospital.Common.Models;
using Refit;


namespace Hospital.API.Abstraction;

public interface IPatientApi
{
    [Get("/api/Patient/{patientId})")]
    public Task<PatientModel> Get(long patientId);
}