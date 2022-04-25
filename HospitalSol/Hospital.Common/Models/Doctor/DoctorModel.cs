namespace Hospital.Common.Models.Doctor;

public class DoctorModel
{
    /// <summary>
    /// Идентификатор врача
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Фамилия врача
    /// </summary>
    public string FamilyName { get; set; }

    /// <summary>
    /// Имя врача
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Отчество врача
    /// </summary>
    public string SurName { get; set; }

    /// <summary>
    /// Кабинет врача
    /// </summary>
    public long OfficeId { get; set; }

    public OfficeModel Office { get; set; }

    /// <summary>
    /// Специализации врача
    /// </summary>
    public List<SpecializationModel> Specializations { get; set; } = new();

    /// <summary>
    /// Участок врача (для участковых врачей)
    /// </summary>
    public long? AreaId { get; set; }

    public AreaModel Area { get; set; }
}