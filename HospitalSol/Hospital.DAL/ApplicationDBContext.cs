using Hospital.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<AreaEntity> Areas { get; set; }
    public DbSet<PatientEntity> Patients { get; set; }
    public DbSet<DoctorEntity> Doctors { get; set; }
    public DbSet<OfficeEntity> Offices { get; set; }
    public DbSet<SpecializationEntity> Specializations { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}