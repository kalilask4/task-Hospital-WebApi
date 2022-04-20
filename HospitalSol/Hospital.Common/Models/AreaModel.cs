namespace Hospital.Common.Models;

public class AreaModel
{
    public long Id { get; set; }
    public List<PatientModel> Patients { get; set; } = new();
}