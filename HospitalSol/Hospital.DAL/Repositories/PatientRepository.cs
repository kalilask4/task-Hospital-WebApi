using System.Linq.Expressions;
using Hospital.Abstraction.Entities;
using Hospital.Abstraction.Interfaces;
using Hospital.Common.Models;
using Hospital.Common.Models.Collection;
using Hospital.Common.Models.Patient;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public PatientRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    /// <inheritdoc cref="IPatientRepository.CreateAsync(CreatePatientModel)"/>
    public async Task<long> CreateAsync(CreatePatientModel createPatientModel)
    {
        var patientEntity = _mapper.Map<PatientEntity>(createPatientModel);
        await _context.AddAsync(patientEntity);
        await _context.SaveChangesAsync();

        return patientEntity.Id;
    }

    /// <inheritdoc cref="IPatientRepository.UpdateAsync(UpdatePatientModel)"/>
    public async Task UpdateAsync(UpdatePatientModel updatePatientModel)
    {
        var PatientForUpdate = _mapper.Map<PatientEntity>(updatePatientModel);
        _context.Patients.Update(PatientForUpdate);
        await _context.SaveChangesAsync();
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

    /// <inheritdoc cref="IPatientRepository.GetAsync(GetListModel{T})"/>
    public async Task<BaseCollectionModel<ListPatientModel>> GetAsync(GetListModel<PatientFilterModel> getListModel)
    {
        var query = _context.Patients
            .AsNoTracking()
            .Include(x => x.Area)
            .AsQueryable();
        if (getListModel.Filter != null)
        {
            if (getListModel.Filter.Ids != null)
                query = query.Where(x => getListModel.Filter.Ids.Contains(x.Id));

            if (!string.IsNullOrWhiteSpace(getListModel.Filter.Name))
                query = query.Where(x => x.Name.ToLower().Contains(getListModel.Filter.Name));
            if (!string.IsNullOrWhiteSpace(getListModel.Filter.FamilyName))
                query = query.Where(x => x.FamilyName.ToLower().Contains(getListModel.Filter.FamilyName));
        }

        var totalCount = await query.LongCountAsync();

        if (!string.IsNullOrWhiteSpace(getListModel.SortBy))
        {
            query = getListModel.SortBy switch
            {
                nameof(PatientEntity.Name) => getListModel.SortOrder == SortOrder.Asc
                    ? query.OrderBy(x => x.Name)
                    : query.OrderByDescending(x => x.Name),

                nameof(PatientEntity.FamilyName) => getListModel.SortOrder == SortOrder.Asc
                    ? query.OrderBy(x => x.FamilyName)
                    : query.OrderByDescending(x => x.FamilyName),

                nameof(PatientEntity.Area) => getListModel.SortOrder == SortOrder.Asc
                    ? query.OrderBy(x => x.Area)
                    : query.OrderByDescending(x => x.Area),

                _ => getListModel.SortOrder == SortOrder.Asc
                    ? query.OrderBy(x => x.Id)
                    : query.OrderByDescending(x => x.Id)
            };
        }

        var patientModels = await query
            .Skip((getListModel.Page - 1) * getListModel.PageSize)
            .Take(getListModel.PageSize)
            .ProjectToType<ListPatientModel>(_mapper.Config)
            .ToListAsync();

        return new BaseCollectionModel<ListPatientModel>
        {
            Items = patientModels,
            TotalCount = totalCount
        };
    }

    /// <inheritdoc cref="IPatientRepository.DeleteAsync(long)"/>
    public async Task DeleteAsync(long patientId)
    {
        var patientEntity = await _context.Patients
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == patientId);

        _context.Remove(patientEntity);
        await _context.SaveChangesAsync();
    }
}