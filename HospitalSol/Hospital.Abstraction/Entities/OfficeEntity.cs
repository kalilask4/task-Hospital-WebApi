namespace Hospital.Abstraction.Entities;

public class OfficeEntity : BaseEntity
{
    /// <summary>
    /// Номер кабинета
    /// </summary>
    public string? Number { get; set; }


    public override string ToString()
    {
        return this.Number;
    }
}