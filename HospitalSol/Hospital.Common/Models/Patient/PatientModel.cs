using Hospital.Common.Models.Area;

namespace Hospital.Common.Models.Patient;

public class PatientModel
{
    public long Id { get; set; }
    public string Name { get; set; }
   
    public AreaModel Area { get; set; }
    public long? AreaId { get; set; }
}