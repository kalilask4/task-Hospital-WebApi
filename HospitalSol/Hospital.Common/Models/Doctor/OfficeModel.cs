namespace Hospital.Common.Models.Doctor;

public class OfficeModel
{
    /// <summary>
    /// Номер кабинета
    /// </summary>
    public string Number { get; set; }
    
    /// <summary>
    /// Доктор относящийся к данному кабинету
    /// </summary>
    public long DoctorId { get; set; }
    public DoctorModel Doctor { get; set; }

}