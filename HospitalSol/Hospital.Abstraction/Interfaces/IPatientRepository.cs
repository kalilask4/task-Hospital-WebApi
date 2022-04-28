using Hospital.Common.Models;
using Hospital.Common.Models.Collection;
using Hospital.Common.Models.Patient;

namespace Hospital.Abstraction.Interfaces;

public interface IPatientRepository
{
    /// <summary>
    /// Создание пациента
    /// </summary>
    /// <param name="createPatientModel">Модель создаваемого пациента</param>
    /// <returns></returns>
    Task<long> CreateAsync(CreatePatientModel createPatientModel);

    /// <summary>
    /// Редактирование пациента
    /// </summary>
    /// <param name="updatePatientModel"></param>
    /// <returns></returns>
    Task UpdateAsync(UpdatePatientModel updatePatientModel);

    /// <summary>
    /// Получение информации о пациенте по идентификатору
    /// </summary>
    /// <param name="patientId">Идентификатор пациента</param>
    /// <returns></returns>
    Task<PatientModel> GetAsync(long patientId);


    /// <summary>
    /// Получение информации о пациентах
    /// </summary>
    /// <param name="getListModel">Фильтр, пагинация</param>
    /// <returns></returns>
    Task<BaseCollectionModel<ListPatientModel>> GetAsync(GetListModel<PatientFilterModel> getListModel);


    /// <summary>
    /// Удаление пациента
    /// </summary>
    /// <param name="patientId">Идентификатор пациента</param>
    /// <returns></returns>
    Task DeleteAsync(long patientId);
    
    /// <summary>
    /// Проверка наличия пациента по ФИО
    /// </summary>
    /// <param name="fullName">ФИО пациента</param>
    /// <returns><c> true </c> если пациент с такими ФИО есть, иначе <c> false </c></returns>
    Task<bool> ExistAsync(string fullName);
}