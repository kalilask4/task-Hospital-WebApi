using Hospital.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hospital.DAL;

public class DbInitializer
{
    public static void Seed(ApplicationDbContext context, ILogger logger)
    {
        try
        {
            if (!context.Patients.Any())
            {
                var patient = new PatientEntity
                {
                    Name = "First Patient",
                    Area = new AreaEntity()
                };
                context.Add(patient);
                var patient2 = new PatientEntity
                {
                    FamilyName = "Kotova",
                    Name = "Mary",
                    Surname = "St",
                    FullName = "Kotova Mary St",
                    Address = "ul Novaja",
                    Birthdate = DateTime.Today,
                    Area = new AreaEntity
                    {
                        Number = "123e"
                    },
                    PatientGender = PatientEntity.Gender.Woman
                };
                context.Add(patient2);
                context.SaveChanges();
            }

            if (!context.Doctors.Any())
            {
                var doctor = new DoctorEntity
                {
                    FullName = "First Doctor",
                    Office = new OfficeEntity(),
                    Specializations = new List<SpecializationEntity>(),
                    Area = new AreaEntity()
                };
                context.Add(doctor);
                var doctor2 = new DoctorEntity
                {
                    FullName = "Second Doctor",
                    Office = new OfficeEntity(),
                    Specializations = new List<SpecializationEntity>(),
                    AreaId = 1
                };
                doctor2.Specializations.Add(new SpecializationEntity());
                doctor2.Specializations.Add(new SpecializationEntity());
                context.Add(doctor2);
                context.SaveChanges();
            }
        }
        catch (DbUpdateException e)
        {
            logger.LogError(e, "Невозможно выполнить первоначальную инициализацию данных");
            throw;
        }
    }
}
