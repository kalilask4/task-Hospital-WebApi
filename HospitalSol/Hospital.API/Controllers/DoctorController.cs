using Hospital.Abstraction.Interfaces;
using Hospital.API.Abstraction;
using Hospital.API.Contracts.Requests;
using Hospital.API.Contracts.Responses;
using Hospital.Common.Models.Collection;
using Hospital.Common.Models.Doctor;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers;

/// <summary>
/// Врач
/// </summary>
[ApiController]
[Route("[controller]")]
public class DoctorController : ControllerBase, IDoctorApi
{
    private readonly IMapper _mapper;
    private readonly IDoctorService _doctorService;
    private readonly ILogger<DoctorController> _logger;

    public DoctorController(
        IMapper mapper,
        IDoctorService doctorService,
        ILogger<DoctorController> logger)
    {
        _mapper = mapper;
        _doctorService = doctorService;
        _logger = logger;
    }

    /// <summary>
    /// Создание нового врача
    /// </summary>
    /// <param name="createDoctorRequest"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<BaseCreateResponse> Create(CreateDoctorRequest createDoctorRequest)
    {
        var createDoctorModel = _mapper.Map<CreateDoctorModel>(createDoctorRequest);
        return new BaseCreateResponse
        {
            Id = await _doctorService.CreateAsync(createDoctorModel)
        };
    }

    /// <summary>
    /// Обновление врача
    /// </summary>
    [HttpPut]
    public async Task Update(UpdateDoctorRequest doctorRequest)
    {
        var updateDoctorModel = _mapper.Map<UpdateDoctorModel>(doctorRequest);
        await _doctorService.UpdateAsync(updateDoctorModel);
    }
    
    /// <summary>
    /// Удаление врача
    /// </summary>
    /// <param name="doctorId"></param>
    [HttpDelete("{doctorId:long}")]
    public async Task Delete([FromRoute] long doctorId)
    {
        await _doctorService.DeleteAsync(doctorId);
    }

    /// <summary>
    /// Получить врача по идентификатору
    /// </summary>
    /// <param name="doctorId"></param>
    /// <returns></returns>
    [HttpGet("{doctorId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DoctorModel))]
    public async Task<DoctorModel> Get([FromRoute] long doctorId)
    {
        return await _doctorService.GetAsync(doctorId);
    }

    /// <summary>
    /// Получить всех врачей
    /// </summary>
    /// <returns></returns>
    [HttpPost("list")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseCollectionResponse<ListDoctorModel>))]
    public async Task<IActionResult> GetList([FromBody] GetListRequest<DoctorFilterModel> listRequest)
    {
        var getFilterModel = _mapper.Map<GetListModel<DoctorFilterModel>>(listRequest);
        var collectionModel = await _doctorService.GetAsync(getFilterModel);
        return Ok(_mapper.Map<BaseCollectionResponse<ListDoctorModel>>(collectionModel));
    }
}