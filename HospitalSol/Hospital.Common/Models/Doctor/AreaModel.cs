using Hospital.Common.Models.Patient;

namespace Hospital.Common.Models.Doctor;

public class AreaModel
{
    /// <summary>
    /// Идентификатор участка
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Номер участка
    /// </summary>
    public string Number { get; set; }
}