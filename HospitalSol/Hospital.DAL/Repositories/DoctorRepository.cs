using System.Linq.Expressions;
using Hospital.Abstraction.Entities;
using Hospital.Abstraction.Interfaces;
using Hospital.Common.Models;
using Hospital.Common.Models.Collection;
using Hospital.Common.Models.Doctor;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL.Repositories;



public class DoctorRepository : IDoctorRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public DoctorRepository(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<long> CreateAsync(CreateDoctorModel createDoctorModel)
    {
        var doctorEntity = _mapper.Map<DoctorEntity>(createDoctorModel);
        doctorEntity.FullName = doctorEntity.FamilyName + " " + doctorEntity.Name + " " + doctorEntity.Surname;
        await _context.AddAsync(doctorEntity);
        await _context.SaveChangesAsync();

        return doctorEntity.Id;
    }

    public async Task UpdateAsync(UpdateDoctorModel updateDoctorModel)
    {
        var doctorForUpdate = _mapper.Map<DoctorEntity>(updateDoctorModel);
        doctorForUpdate.FullName =
            doctorForUpdate.FamilyName + " " + doctorForUpdate.Name + " " + doctorForUpdate.Surname;

        _context.Doctors.Update(doctorForUpdate);
        await _context.SaveChangesAsync();
    }

    public async Task<DoctorModel> GetAsync(long doctorId)
    {
        var doctorEntity = await _context.Doctors
            .AsNoTracking()
            .Include(x => x.Office)
            .Include(x => x.Area)
            .Include(x => x.Specializations)
            .SingleOrDefaultAsync((x => x.Id == doctorId));
        if (doctorEntity == null)
        {
            throw new Exception("Врач с данным идентификатором не найден");
        }

        return _mapper.Map<DoctorModel>(doctorEntity);

    }

    public async Task DeleteAsync(long doctorId)
    {
        var doctorEntity = await _context.Doctors
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == doctorId);

        _context.Remove(doctorEntity);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc cref="IDoctorRepository.GetAsync(GetListModel{T})"/>
    public async Task<BaseCollectionModel<ListDoctorModel>> GetAsync(GetListModel<DoctorFilterModel> getListModel)
    {
        var query = _context.Doctors
            .AsNoTracking()
            .Include(x => x.Specializations)
            .Include(x => x.Office)
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
                    nameof(DoctorEntity.Name) => getListModel.SortOrder == SortOrder.Asc
                        ? query.OrderBy(x => x.Name)
                        : query.OrderByDescending(x => x.Name),

                    nameof(DoctorEntity.FamilyName) => getListModel.SortOrder == SortOrder.Asc
                        ? query.OrderBy(x => x.FamilyName)
                        : query.OrderByDescending(x => x.FamilyName),

                    nameof(DoctorEntity.Office) => getListModel.SortOrder == SortOrder.Asc
                        ? query.OrderBy(x => x.Office)
                        : query.OrderByDescending(x => x.Office),

                    nameof(DoctorEntity.Area) => getListModel.SortOrder == SortOrder.Asc
                        ? query.OrderBy(x => x.Area)
                        : query.OrderByDescending(x => x.Area),

                    _ => getListModel.SortOrder == SortOrder.Asc
                        ? query.OrderBy(x => x.Id)
                        : query.OrderByDescending(x => x.Id)
                };
            }
        
        var doctorModels = await query
                .Skip((getListModel.Page - 1) * getListModel.PageSize)
                .Take(getListModel.PageSize)
                .ProjectToType<ListDoctorModel>(_mapper.Config)
                .ToListAsync();
        //var listDoctorModels = _mapper.Map<DoctorModel>(doctorModels);

        return new BaseCollectionModel<ListDoctorModel>
            {
                Items = doctorModels,
                TotalCount = totalCount
            };
        }
    }


//
//     public Task<DoctorModel[]> GetByExpression(Expression<Func<DoctorEntity, bool>> expression)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }
