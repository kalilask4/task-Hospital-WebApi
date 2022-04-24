namespace Hospital.Abstraction.Entities;

public class OfficeEntity: BaseEntity
{
    /// <summary>
    /// Номер кабинета
    /// </summary>
    public string? Number { get; set; }
    
    // /// <summary>
    // ///  Врач относящийся к данному кабинету
    // /// </summary>
    // public long? DoctorId { get; set; }
    // public DoctorEntity? Doctor { get; set; }
}