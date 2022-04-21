using Hospital.Common.Models;
using Hospital.Common.Models.Patient;

namespace Hospital.Abstraction.ServicesInterfaces;

public interface IPatientService
{ 
        /// <summary>
        /// Создание пациента
        /// </summary>
        /// <param name="createPatienModel">Модель создаваемого события</param>
        /// <returns></returns>
        Task<long> CreateAsync(CreatePatientModel createPatientModel);
        
        /// <summary>
        /// Получение информации о пауиенте по идентификатору
        /// </summary>
        /// <param name="patientId">Идентификатор пациента</param>
        /// <returns></returns>
        Task<PatientModel> GetAsync(long patientId);
/*
        /// <summary>
        /// Редактирование пациента
        /// </summary>
        /// <param name="updatePatientModel"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdatePatientModel updatePatientModel);

        /// <summary>
        /// Получение информации о поциентк по идентификатору
        /// </summary>
        /// <param name="patientId">Идентификатор пациента</param>
        /// <returns></returns>
        Task<PatientModel> GetAsync(long patientId);

        /// <summary>
        /// Получение информации о событиях
        /// </summary>
        /// <param name="getListModel">Фильтр, пагинация</param>
        /// <returns></returns>
        Task<BaseCollectionModel<PatientModel>> GetAsync(GetListModel<PatientFilterModel> getListModel);
        */
        /// <summary>
        /// Удаление события
        /// </summary>
        /// <param name="patientId">Идентификатор пациента</param>
        /// <returns></returns>
        Task DeleteAsync(long patientId);
        
}