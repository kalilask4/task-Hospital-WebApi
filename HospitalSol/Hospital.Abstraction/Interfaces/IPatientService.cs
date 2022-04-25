using Hospital.Common.Models;
using Hospital.Common.Models.Collection;
using Hospital.Common.Models.Patient;

namespace Hospital.Abstraction.Interfaces;

public interface IPatientService
{
    /// <summary>
    /// Создание пациента
    /// </summary>
    /// <param name="createPatienModel">Модель создаваемого пациента</param>
    /// <returns></returns>
    Task<long> CreateAsync(CreatePatientModel createPatientModel);

    /// <summary>
    /// Получение информации о пауиенте по идентификатору
    /// </summary>
    /// <param name="patientId">Идентификатор пациента</param>
    /// <returns></returns>
    Task<PatientModel> GetAsync(long patientId);

    /// <summary>
    /// Удаление пациента
    /// </summary>
    /// <param name="patientId">Идентификатор пациента</param>
    /// <returns></returns>
    Task DeleteAsync(long patientId);

    /// <summary>
    /// Редактирование пациента
    /// </summary>
    /// <param name="updatePatientModel"></param>
    /// <returns></returns>
    Task UpdateAsync(UpdatePatientModel updatePatientModel);

    /// <summary>
    /// Получение информации о пациентах
    /// </summary>
    /// <param name="getListModel">Фильтр, пагинация</param>
    /// <returns></returns>
    Task<BaseCollectionModel<ListPatientModel>> GetAsync(GetListModel<PatientFilterModel> getListModel);
}