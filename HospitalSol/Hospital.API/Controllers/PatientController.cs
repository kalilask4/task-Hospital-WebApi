using Hospital.Abstraction.Interfaces;
using Hospital.API.Abstraction;
using Hospital.API.Contracts.Requests;
using Hospital.API.Contracts.Responses;
using Hospital.Common.Models;
using Hospital.Common.Models.Patient;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper;

namespace Hospital.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase, IPatientApi
{
    private readonly IMapper _mapper;
    private readonly IPatientService _patientService;
    private readonly ILogger<PatientController> _logger;

    public PatientController(
        IPatientService patientService, 
        IMapper mapper, 
        ILogger<PatientController> logger)
    {
        _patientService = patientService;
        _mapper = mapper;
        _logger = logger;
    }
    
    /// <summary>
    /// Создание нового пациента
    /// </summary>
    /// <param name="createPatientRequest"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<BaseCreateResponse> Create(CreatePatientRequest createPatientRequest)
    {
        var createPatientModel = _mapper.Map<CreatePatientModel>(createPatientRequest);
        //createPatientModel.AreaId = AreaId;
        //var patientId = await _patientService.CreateAsync(createPatientModel);
        return new BaseCreateResponse
        {
            Id = await _patientService.CreateAsync(createPatientModel),

        };
        
        //createPatientModel.AreaId = AreaId;
        //
        // return new BaseCreateResponse
        // {
        //     Id = await _patientService.CreateAsync(createPatientModel),
        // };
    }
    
    /// <summary>
    /// Получить пациента по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
   // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientModel))]
    public async Task<PatientModel> Get([FromRoute] long id)
    {
        return await _patientService.GetAsync(id);
    }
}