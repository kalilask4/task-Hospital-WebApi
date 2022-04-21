namespace Hospital.API.Contracts.Requests;

public class UpdatePatientRequest: CreatePatientRequest
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long AreaId { get; set; }
}