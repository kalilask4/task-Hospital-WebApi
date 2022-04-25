using FluentValidation;
using Hospital.Abstraction.Interfaces;
using Hospital.Common.Exceptions;
using Hospital.Common.Models;
using Hospital.Common.Models.Collection;
using Hospital.Common.Models.Patient;


namespace Hospital.BL.Patient;

public class PatientService : IPatientService
{
    private readonly IValidator<CreatePatientModel> _createPatientModelValidator;
    private readonly IValidator<UpdatePatientModel> _updatePatientModelValidator;
    private readonly IPatientRepository _patientRepository;
    private readonly IValidator<GetListModel<PatientFilterModel>> _getFilterModelValidator;


    public PatientService(
        IValidator<CreatePatientModel> createPatientModelValidator,
        IValidator<UpdatePatientModel> updatePatientModelValidator,
        IValidator<GetListModel<PatientFilterModel>> getFilterModelValidator,
        IPatientRepository patientRepository)
    {
        _createPatientModelValidator = createPatientModelValidator;
        _updatePatientModelValidator = updatePatientModelValidator;
        _getFilterModelValidator = getFilterModelValidator;
        _patientRepository = patientRepository;
    }

    /// <inheritdoc cref="IPatientService.CreateAsync(CreatePatientModel)"/>
    public async Task<long> CreateAsync(CreatePatientModel createPatientModel)
    {
        await _createPatientModelValidator.ValidateAndThrowAsync(createPatientModel);
        return await _patientRepository.CreateAsync(createPatientModel);
    }

    /// <inheritdoc cref="IPatientService.GetAsync(long)"/>
    public async Task<PatientModel> GetAsync(long patientId)
    {
        return await _patientRepository.GetAsync(patientId);
    }

    public async Task DeleteAsync(long patientId)
    {
        var patientModel = await _patientRepository.GetAsync(patientId);
        if (patientModel == null)
            throw new EntityNotFoundException($"Пациента с идентификатором {patientId} не существует");
        await _patientRepository.DeleteAsync(patientId);
    }

    public async Task UpdateAsync(UpdatePatientModel updatePatientModel)
    {
        await _updatePatientModelValidator.ValidateAndThrowAsync(updatePatientModel);
        await _patientRepository.UpdateAsync(updatePatientModel);
    }

    public async Task<BaseCollectionModel<ListPatientModel>> GetAsync(GetListModel<PatientFilterModel> getListModel)
    {
        await _getFilterModelValidator.ValidateAndThrowAsync(getListModel);
        return await _patientRepository.GetAsync(getListModel);
    }
}