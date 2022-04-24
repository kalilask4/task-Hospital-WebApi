namespace Hospital.API.Contracts.Requests;

public class UpdateDoctorRequest: CreateDoctorRequest
{
    public long Id { get; set; }
}