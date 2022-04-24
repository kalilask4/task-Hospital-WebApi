using Hospital.Common.Models.Patient;

namespace Hospital.Common.Models.Doctor;

public class AreaModel
{
    /// <summary>
    /// Номер участка
    /// </summary>
    public string Number { get; set; }
    
    /// <summary>
    /// Пациенты участка
    /// </summary>
    public List<PatientModel> Patients { get; set; } = new();
    
    public long DoctorId { get; set; }
    public DoctorModel Doctor { get; set; }
}