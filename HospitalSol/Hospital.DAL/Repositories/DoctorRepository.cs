using Hospital.Abstraction.Entities;
using Hospital.Abstraction.Interfaces;
using Hospital.Common.Models.Doctor;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL.Repositories;


public class DoctorRepository: IDoctorRepository
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
        doctorForUpdate.FullName = doctorForUpdate.FamilyName + " " + doctorForUpdate.Name + " " + doctorForUpdate.Surname;

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
}