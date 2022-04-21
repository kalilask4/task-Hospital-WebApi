namespace Hospital.Common.Models;

public class CreatePatientModel
{
    /// <summary>
    /// Имя пациента
    /// </summary>
    public string Name { get; set; }

    
    /// <summary>
    /// Участок
    /// </summary>
    public long AreaId { get; set; }
}