using Hospital.Abstraction.Interfaces;
using Hospital.API.Abstraction;
using Hospital.API.Contracts.Requests;
using Hospital.API.Contracts.Responses;
using Hospital.Common.Models;
using Hospital.Common.Models.Collection;
using Hospital.Common.Models.Patient;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper;

namespace Hospital.API.Controllers;

/// <summary>
/// Пациент
/// </summary>
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
        return new BaseCreateResponse
        {
            Id = await _patientService.CreateAsync(createPatientModel),
        };
    }

    /// <summary>
    /// Обновление пациента
    /// </summary>
    [HttpPut]
    public async Task Update(UpdatePatientRequest patientRequest)
    {
        var updatePatientModel = _mapper.Map<UpdatePatientModel>(patientRequest);
        await _patientService.UpdateAsync(updatePatientModel);
    }

    /// <summary>
    /// Получить пациента по идентификатору
    /// </summary>
    /// <param name="patientId"></param>
    /// <returns></returns>
    [HttpGet("{patientId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientModel))]
    public async Task<PatientModel> Get([FromRoute] long patientId)
    {
        return await _patientService.GetAsync(patientId);
    }

    /// <summary>
    /// Удаление пациента
    /// </summary>
    /// <param name="patientId"></param>
    [HttpDelete("{patientId:long}")]
    public async Task Delete([FromRoute] long patientId)
    {
        await _patientService.DeleteAsync(patientId);
    }

    /// <summary>
    /// Получить всех пациентов
    /// </summary>
    /// <returns></returns>
    [HttpPost("list")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseCollectionResponse<ListPatientModel>))]
    public async Task<IActionResult> GetList([FromBody] GetListRequest<PatientFilterModel> listRequest)
    {
        var getFilterModel = _mapper.Map<GetListModel<PatientFilterModel>>(listRequest);
        var collectionModel = await _patientService.GetAsync(getFilterModel);
        return Ok(_mapper.Map<BaseCollectionResponse<ListPatientModel>>(collectionModel));
    }
}