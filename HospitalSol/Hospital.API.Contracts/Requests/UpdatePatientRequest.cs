namespace Hospital.API.Contracts.Requests;

public class UpdatePatientRequest : CreatePatientRequest
{
    public long Id { get; set; }
}