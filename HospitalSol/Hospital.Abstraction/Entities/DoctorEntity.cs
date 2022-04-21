namespace Hospital.Abstraction.Entities;

public class DoctorEntity: BaseEntity
{
    /// <summary>
    /// ФИО врача
    /// </summary>
    public string? FullName { get; set; }
    
    /// <summary>
    /// Кабинет врача
    /// </summary>
    public long? OfficeId { get; set; }
    public OfficeEntity? Office { get; set; }
    
    /// <summary>
    /// Специализация врача
    /// </summary>
    public long? SpecializationId { get; set; }
    public SpecializationEntity? Specialization { get; set; }
    
    /// <summary>
    /// Участок врача (для участковых врачей)
    /// </summary>
    public long? AreaId { get; set; }
    public AreaEntity? Area { get; set; }
}