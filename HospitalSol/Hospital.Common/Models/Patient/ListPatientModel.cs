namespace Hospital.Common.Models.Patient;

public class ListPatientModel
{
    /// <summary>
    /// Идентификатор пациента
    /// </summary>
    public long Id { get; set; }
    
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
    public int PatientGender { get; set; }

    /// <summary>
    /// Участок пациента
    /// </summary>
    public string Area { get; set; }
    
    // public enum Gender 
    // {
    //     Man = 1,
    //     Woman = 2,
    // }
}