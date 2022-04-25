using System.ComponentModel.DataAnnotations;
using Hospital.Common.Models.Doctor;

namespace Hospital.API.Contracts.Requests;

/// <summary>
/// Контракт создания и обновления врача
/// </summary>
public class CreateDoctorRequest
{
    [Required] public string FamilyName { get; set; }

    [Required] public string Name { get; set; }

    public string? Surname { get; set; }

    [Required] public long OfficeId { get; set; }

    [Required] public List<SpecializationModel> Specializations { get; set; } = new();

    public long? AreaId { get; set; }
}