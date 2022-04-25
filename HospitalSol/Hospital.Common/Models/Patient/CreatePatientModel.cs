namespace Hospital.Common.Models;

public class CreatePatientModel
{
    /// <summary>
    /// Фамилия пациента
    /// </summary>
    public string FamilyName { get; set; }

    /// <summary>
    /// Имя пациента
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Отчество пациента
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Адрес пациента
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Дота рождения пациента
    /// </summary>
    public DateTime Birthdate { get; set; }

    /// <summary>
    /// Пол пациента
    /// </summary>
    public Gender PatientGender { get; set; }

    /// <summary>
    /// Участок пациента
    /// </summary>
    public long AreaId { get; set; }

    public enum Gender
    {
        Man = 1,
        Woman = 2,
    }
}