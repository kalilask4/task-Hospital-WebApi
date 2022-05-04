using FluentValidation;
using Hospital.Abstraction.Interfaces;
using Hospital.Common.Exceptions;
using Hospital.Common.Models.Collection;
using Hospital.Common.Models.Doctor;

namespace Hospital.BL.Doctor;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IValidator<CreateDoctorModel> _createDoctorModelValidator;
    private readonly IValidator<UpdateDoctorModel> _updateDoctorModelValidator;
    private readonly IValidator<GetListModel<DoctorFilterModel>> _getFilterModelValidator;


    public DoctorService(
        IDoctorRepository doctorRepository,
        IValidator<CreateDoctorModel> createDoctorModelValidator,
        IValidator<UpdateDoctorModel> updateDoctorModelValidator,
        IValidator<GetListModel<DoctorFilterModel>> getFilterModelValidator)
    {
        _doctorRepository = doctorRepository;
        _createDoctorModelValidator = createDoctorModelValidator;
        _updateDoctorModelValidator = updateDoctorModelValidator;
        _getFilterModelValidator = getFilterModelValidator;
    }

    /// <inheritdoc cref="IDctorService.CreateAsync(CreateDoctorModel)"/>
    public async Task<long> CreateAsync(CreateDoctorModel createDoctorModel)
    {
        await _createDoctorModelValidator.ValidateAndThrowAsync(createDoctorModel);
        return await _doctorRepository.CreateAsync(createDoctorModel);
    }

    /// <inheritdoc cref="IDctorService.UpdateAsync(UpdateDoctorModel)"/>
    public async Task UpdateAsync(UpdateDoctorModel updateDoctorModel)
    {
        await _updateDoctorModelValidator.ValidateAndThrowAsync(updateDoctorModel);
        await _doctorRepository.UpdateAsync(updateDoctorModel);
    }

    /// <inheritdoc cref="IDctorService.GetAsync(long)"/>

    public async Task<DoctorModel> GetAsync(long doctorId)
    {
        return await _doctorRepository.GetAsync(doctorId);
    }

    /// <inheritdoc cref="IDctorService.GetAsync(GetListModel{T})"/>
    public async Task<BaseCollectionModel<ListDoctorModel>> GetAsync(GetListModel<DoctorFilterModel> getListModel)
    {
        await _getFilterModelValidator.ValidateAndThrowAsync(getListModel);
        return await _doctorRepository.GetAsync(getListModel);
    }

    /// <inheritdoc cref="IDctorService.DeleteAsync(long)"/>
    public async Task DeleteAsync(long doctorId)
    {
        var doctorModel = await _doctorRepository.GetAsync(doctorId);

        if (doctorModel == null)
            throw new EntityNotFoundException($"Врача с идентификатором {doctorId} не существует");

        await _doctorRepository.DeleteAsync(doctorId);
    }
}