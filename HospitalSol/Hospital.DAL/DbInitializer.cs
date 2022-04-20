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
        }
        catch (DbUpdateException e)
        {
            //logger.LogError(e, "Невозможно выполнить первоначальную инициализацию данных");
            throw;
        }
    }
}
