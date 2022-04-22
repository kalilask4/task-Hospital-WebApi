using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Contracts.Requests;

/// <summary>
/// Контракт создания и обновления пациента
/// </summary>
public class CreatePatientRequest
{
    [Required]
    public string FamilyName { get; set; }

    [Required]
    public string Name { get; set; }
    
    public string? Surname { get; set; }
    
    [Required]
    public string Address { get; set; }
    
    [Required]
    public DateTime Birthdate { get; set; }

    [Required]
    public Gender PatientGender { get; set; }
    
    [Required]
    public long AreaId { get; set; }
    
    public enum Gender 
    {
        Man = 1,
        Woman = 2,
    }
}