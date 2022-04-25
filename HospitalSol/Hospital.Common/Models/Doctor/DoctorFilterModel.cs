namespace Hospital.Common.Models.Doctor;

public class DoctorFilterModel
{
    public long[] Ids { get; set; }
    
    public string FamilyName { get; set; }

    public string Name { get; set; }

    public string? SurName { get; set; }

    //public long OfficeId { get; set; }
   // public OfficeModel Office { get; set; }
    public string Office { get; set; }
    
    public SpecializationModel[] Specializations { get; set; } = Array.Empty<SpecializationModel>();

    //public long? AreaId { get; set; }
    //public AreaModel Area { get; set; }
    public string? Area { get; set; }
}