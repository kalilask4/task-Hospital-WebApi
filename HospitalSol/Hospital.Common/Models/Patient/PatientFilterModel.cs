namespace Hospital.Common.Models.Patient;

public class PatientFilterModel
{
    public long[] Ids { get; set; }

    public string FamilyName { get; set; }

    public string Name { get; set; }

    public string? SurName { get; set; }

    public string? Address { get; set; }

    public DateTime Birthdate { get; set; }

    public string? PatientGender { get; set; }

    public string? Area { get; set; }
}