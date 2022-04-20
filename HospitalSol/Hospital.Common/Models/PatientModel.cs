namespace Hospital.Common.Models;

public class PatientModel
{
    public long Id { get; set; }
    public string Name { get; set; }
   
    public AreaModel Area { get; set; }
    public long? AreaId { get; set; }
}