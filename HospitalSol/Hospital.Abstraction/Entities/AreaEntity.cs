namespace Hospital.Abstraction.Entities;

public class AreaEntity:BaseEntity
{
    /// <summary>
    /// Пациенты участка
    /// </summary>
    public List<PatientEntity> Patients { get; set; } = new();
}