namespace Hospital.Abstraction.Entities;

public class AreaEntity:BaseEntity
{
    /// <summary>
    /// Номер участка
    /// </summary>
    public string? Number { get; set; }
    
    /// <summary>
    /// Пациенты участка
    /// </summary>
    public List<PatientEntity> Patients { get; set; } = new();
}