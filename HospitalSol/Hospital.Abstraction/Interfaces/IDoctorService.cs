using Hospital.Common.Models.Doctor;

namespace Hospital.Abstraction.Interfaces;

public interface IDoctorService
{
    /// <summary>
    /// Создание врача
    /// </summary>
    /// <param name="createDoctorModel">Модель создаваемого врача</param>
    /// <returns></returns>
    Task<long> CreateAsync(CreateDoctorModel createDoctorModel);

    /// <summary>
    /// Редактирование врача
    /// </summary>
    /// <param name="updateDoctorModel"></param>
    /// <returns></returns>
    Task UpdateAsync(UpdateDoctorModel updateDoctorModel);

    /// <summary>
    /// Получение информации о враче по идентификатору
    /// </summary>
    /// <param name="doctorId">Идентификатор врача</param>
    /// <returns></returns>
    Task<DoctorModel> GetAsync(long doctorId);
    
    /// <summary>
    /// Удаление врача
    /// </summary>
    /// <param name="doctorId">Идентификатор врача</param>
    /// <returns></returns>
    Task DeleteAsync(long doctorId);
}