namespace Hospital.Abstraction.Entities;

public class OfficeEntity: BaseEntity
{
    /// <summary>
    /// Номер кабинета
    /// </summary>
    public string? Number { get; set; }
    
    /// <summary>
    /// Доктор относящийся к данному кабинету
    /// </summary>
    public long? OfficeId { get; set; }

    public AreaEntity? Office { get; set; }
}