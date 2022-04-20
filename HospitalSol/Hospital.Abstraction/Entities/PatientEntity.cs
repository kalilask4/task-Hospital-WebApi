namespace Hospital.Abstraction.Entities;

public class PatientEntity: BaseEntity
{
    /// <summary>
    /// Имя пациента
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Участок пациента
    /// </summary>
    public long AreaId { get; set; }
    public AreaEntity? Area { get; set; }

    
}