using Hospital.Common.Models.Patient;

namespace Hospital.Common.Models.Area;

public class AreaModel
{
    public long Id { get; set; }
    public List<PatientModel> Patients { get; set; } = new();
}