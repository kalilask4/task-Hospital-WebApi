namespace Hospital.Common.Models.Doctor;

public class DoctorFilterModel
{
    public long[] Ids { get; set; }

    public string FamilyName { get; set; }

    public string Name { get; set; }

    public string? SurName { get; set; }

    public string Office { get; set; }

    public SpecializationModel[] Specializations { get; set; } = Array.Empty<SpecializationModel>();

    public string? Area { get; set; }
}