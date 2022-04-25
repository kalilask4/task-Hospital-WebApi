namespace Hospital.Abstraction.Entities;

public class SpecializationEntity : BaseEntity
{
    /// <summary>
    /// Название специализации врача
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Врачи данной специализации
    /// </summary>
    public List<DoctorEntity> Doctors { get; set; } = new();
}