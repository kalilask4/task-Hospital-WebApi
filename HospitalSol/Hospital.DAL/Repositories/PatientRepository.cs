using System.Linq.Expressions;
using Hospital.Abstraction.Entities;
using Hospital.Abstraction.Interfaces;
using Hospital.Common.Models;
using Hospital.Common.Models.Patient;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL.Repositories;

public class PatientRepository:IPatientRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public PatientRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;

    }
    public Task<long> CreateAsync(CreatePatientModel createPatientModel)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IPatientRepository.GetAsync(long)"/>
    public async Task<PatientModel> GetAsync(long patientId)
    {
        var patientEntity = await _context.Patients
            .AsNoTracking()
            .Include(x => x.Area)
            .SingleOrDefaultAsync(x => x.Id == patientId);

        return _mapper.Map<PatientModel>(patientEntity);
    }

    public Task<PatientModel[]> GetByExpression(Expression<Func<PatientEntity, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long patientId)
    {
        throw new NotImplementedException();
    }
}