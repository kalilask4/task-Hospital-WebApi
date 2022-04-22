using System.Linq.Expressions;
using Hospital.Abstraction.Entities;
using Hospital.Common.Models;
using Hospital.Common.Models.Collection;
using Hospital.Common.Models.Patient;

namespace Hospital.Abstraction.Interfaces;

public interface IPatientRepository
{
    /// <summary>
    /// Создание пациента
    /// </summary>
    /// <param name="createPatientModel">Модель создаваемого события</param>
    /// <returns></returns>
    Task<long> CreateAsync(CreatePatientModel createPatientModel);

    /// <summary>
    /// Получение информации о пациенте по идентификатору
    /// </summary>
    /// <param name="patientId">Идентификатор пациента</param>
    /// <returns></returns>
    Task<PatientModel> GetAsync(long patientId);

    /*
    /// <summary>
    /// Получение информации о пациентах
    /// </summary>
    /// <param name="getListModel">Фильтр, пагинация</param>
    /// <returns></returns>
    Task<BaseCollectionModel<PatientModel>> GetAsync(GetListModel<PatientFilterModel> getListModel);*/

    /// <summary>
    /// As queryable
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    Task<PatientModel[]> GetByExpression(Expression<Func<PatientEntity, bool>> expression);

    /*
    /// <summary>
    /// Обновление события
    /// </summary>
    /// <param name="updatePatientModels">Событие</param>
    /// <returns></returns>
    Task UpdateAsync(UpdatePatientModel updatePatientModel);*/

    /// <summary>
    /// Удаление пациента
    /// </summary>
    /// <param name="patientId">Идентификатор пациента</param>
    /// <returns></returns>
    Task DeleteAsync(long patientId);
}