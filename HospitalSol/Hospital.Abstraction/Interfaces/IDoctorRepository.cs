using System.Linq.Expressions;
using Hospital.Abstraction.Entities;
using Hospital.Common.Models.Collection;
using Hospital.Common.Models.Doctor;

namespace Hospital.Abstraction.Interfaces;

public interface IDoctorRepository
{
    /// <summary>
    /// Создание врача
    /// </summary>
    /// <param name="createDoctorModel">Модель создаваемого события</param>
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
    
    /// <summary>
    /// Получение информации о врачах
    /// </summary>
    /// <param name="getListModel">Фильтр, пагинация</param>
    /// <returns></returns>
    Task<BaseCollectionModel<ListDoctorModel>> GetAsync(GetListModel<DoctorFilterModel> getListModel);

    // /// <summary>
    // /// As queryable
    // /// </summary>
    // /// <param name="expression"></param>
    // /// <returns></returns>
    // Task<DoctorModel[]> GetByExpression(Expression<Func<DoctorEntity, bool>> expression);

    
    // /// <summary>
    // /// Получение информации о врачах
    // /// </summary>
    // /// <param name="getListModel">Фильтр, пагинация</param>
    // /// <returns></returns>
    // Task<BaseCollectionModel<DoctorModel>> GetAsync(GetListModel<DoctorFilterModel> getListModel);

}