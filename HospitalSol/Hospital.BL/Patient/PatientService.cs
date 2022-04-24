using FluentValidation;
using Hospital.Abstraction.Interfaces;
using Hospital.BL.Patient.Validators;
using Hospital.Common.Models;
using Hospital.Common.Models.Patient;

//using Hospital.Common.Exceptions;

namespace Hospital.BL.Patient;

public class PatientService: IPatientService
{
    private readonly IValidator<CreatePatientModel> _createPatientModelValidator;
    //private readonly IValidator<UpdatePatientModel> _updatePatientModelValidator;
    private readonly IPatientRepository _patientRepository;
    //private readonly IValidator<GetListModel<PatientFilterModel>> _getFilterModelValidator;
    //private readonly IAreaService _areaService;

    public PatientService(
        IValidator<CreatePatientModel> createPatientModelValidator,
     //   IValidator<UpdatePatientModel> updatePatientModelValidator,
       // IValidator<GetListModel<PatientFilterModel>> getFilterModelValidator,
        IPatientRepository patientRepository)//,
        //IAreaService areaService)
    {
        _createPatientModelValidator = createPatientModelValidator;
       // _updatePatientModelValidator = updatePatientModelValidator;
        //_getFilterModelValidator = getFilterModelValidator;
        _patientRepository = patientRepository;
        //_areaService = areaService;
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

        //if (patientModel == null)
         //   throw new EntityNotFoundException($"События с идентификатором {patientId} не существует");

        await _patientRepository.DeleteAsync(patientId);
    }
}