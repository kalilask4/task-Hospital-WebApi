namespace Hospital.API.Contracts.Requests;

/// <summary>
/// Контракт создания и обновления пациента
/// </summary>
public class CreatePatientRequest
{
    public string Name { get; set; }
    public long AreaId { get; set; }
}