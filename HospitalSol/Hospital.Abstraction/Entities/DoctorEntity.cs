namespace Hospital.Abstraction.Entities;

public class DoctorEntity: BaseEntity
{
    /// <summary>
    /// Фамилия врача
    /// </summary>
    public string? FamilyName { get; set; }

    /// <summary>
    /// Имя врача
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Отчество врача
    /// </summary>
    public string? Surname { get; set; }
    
    /// <summary>
    /// Полное ФИО врача
    /// </summary>
    public string FullName { get; set; }
    
    /// <summary>
    /// Специализации врача
    /// </summary>
    public List<SpecializationEntity> Specializations { get; set; } = new();
    
    /// <summary>
    /// Участок врача (для участковых врачей)
    /// </summary>
    public long? AreaId { get; set; }
    public AreaEntity? Area { get; set; }
    
    /// <summary>
    /// Кабинет врача
    /// </summary>
    public long? OfficeId { get; set; }
    public OfficeEntity? Office { get; set; }
}