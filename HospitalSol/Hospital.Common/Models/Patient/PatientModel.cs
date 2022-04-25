using Hospital.Common.Models.Doctor;

namespace Hospital.Common.Models.Patient;

public class PatientModel
{
    public long Id { get; set; }
    public string FamilyName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Address { get; set; }
    public DateTime Birthdate { get; set; }

    public CreatePatientModel.Gender PatientGender { get; set; }

    public long AreaId { get; set; }
    public AreaModel Area { get; set; }
    
}