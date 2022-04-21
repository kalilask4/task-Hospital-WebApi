using Hospital.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hospital.DAL;

public class DbInitializer
{
    public static void Seed(ApplicationDbContext context)//, ILogger logger)
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
                context.SaveChanges();
            }
            
            if (!context.Doctors.Any())
            {
                var doctor = new DoctorEntity
                {
                    FullName = "First Doctor",
                    Office = new OfficeEntity(),
                    Specialization = new SpecializationEntity(),
                    Area = new AreaEntity()
                };
                context.Add(doctor);
                var doctor2 = new DoctorEntity
                {
                    FullName = "Second Doctor",
                    Office = new OfficeEntity(),
                    SpecializationId = 1,
                    AreaId = 1
                };
                context.Add(doctor2);
                context.SaveChanges();
            }
        }
        catch (DbUpdateException e)
        {
            //logger.LogError(e, "Невозможно выполнить первоначальную инициализацию данных");
            throw;
        }
    }
}
