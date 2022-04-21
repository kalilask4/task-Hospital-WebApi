namespace Hospital.Abstraction.Entities;

public class SpecializationEntity: BaseEntity
{
    /// <summary>
    /// Название специализации врача
    /// </summary>
    public string? Tittle { get; set; }
    
    /// <summary>
    /// Врачи данной специализации
    /// </summary>
    public List<DoctorEntity> Doctors { get; set; } = new();
}