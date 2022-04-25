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
                    FamilyName = "Kot",
                    Name = "First Patient",
                    Surname = "Pt",
                    Address = "ul Novaja 2",
                    Birthdate = DateTime.Today,
                    Area = new AreaEntity
                    {
                        Number = "1e"
                    },
                    PatientGender = PatientEntity.Gender.Woman
                };
                context.Add(patient);
                var patient2 = new PatientEntity
                {
                    FamilyName = "Kotova",
                    Name = "Mary",
                    Surname = "St",
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
                var specializations = new List<SpecializationEntity>();
                specializations.Add(new SpecializationEntity() { Title = "Кардиолог" });
                specializations.Add(new SpecializationEntity() { Title = "Хирург" });
                var doctor = new DoctorEntity
                {
                    FamilyName = "Goten",
                    Name = "Moon",
                    Surname = "St",
                    Office = new OfficeEntity()
                    {
                        Number = "12a"
                    },
                    Specializations = specializations,
                    Area = new AreaEntity()
                    {
                        Number = "1124-t1"
                    }
                };
                context.Add(doctor);
                var doctor2 = new DoctorEntity
                {
                    FamilyName = "Kotova",
                    Name = "Mary",
                    Surname = "St",
                    Office = new OfficeEntity()
                    {
                        Number = "12d"
                    },
                    Specializations = new List<SpecializationEntity>(),
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