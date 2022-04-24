using FluentValidation;
using Hospital.Abstraction.Interfaces;
using Hospital.BL.Doctor.Validators;
using Hospital.Common.Exceptions;
using Hospital.Common.Models.Doctor;

namespace Hospital.BL.Doctor;

public class DoctorService: IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IValidator<CreateDoctorModel> _createDoctorModelValidator;
    private readonly IValidator<UpdateDoctorModel> _updateDoctorModelValidator;
    //private readonly IValidator<GetListModel<DoctorFilterModel>> _getFilterModelValidator;
    //private readonly IAreaService _areaService;

    
    public DoctorService(
        IDoctorRepository doctorRepository,
        IValidator<CreateDoctorModel> createDoctorModelValidator,
        IValidator<UpdateDoctorModel> updateDoctorModelValidator)
    {
        _doctorRepository = doctorRepository;
        _createDoctorModelValidator = createDoctorModelValidator;
        _updateDoctorModelValidator = updateDoctorModelValidator;
    }

    /// <inheritdoc cref="IOctorService.CreateAsync(CreateDoctorModel)"/>
    public async Task<long> CreateAsync(CreateDoctorModel createDoctorModel)
    { 
        await _createDoctorModelValidator.ValidateAndThrowAsync(createDoctorModel);
        return await _doctorRepository.CreateAsync(createDoctorModel);
    }

    public async Task UpdateAsync(UpdateDoctorModel updateDoctorModel)
    {
        await _updateDoctorModelValidator.ValidateAndThrowAsync(updateDoctorModel);
        await _doctorRepository.UpdateAsync(updateDoctorModel);

    }

    public async Task<DoctorModel> GetAsync(long doctorId)
    {
        return await _doctorRepository.GetAsync(doctorId);
    }

    public async Task DeleteAsync(long doctorId)
    {
        var doctorModel = await _doctorRepository.GetAsync(doctorId);

        if (doctorModel == null)
            throw new EntityNotFoundException($"События с идентификатором {doctorId} не существует");

        await _doctorRepository.DeleteAsync(doctorId);

    }
}