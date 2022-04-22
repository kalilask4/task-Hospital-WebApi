using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hospital.Abstraction.Entities;

namespace Hospital.DAL.Configuration;

public class PatientEntityConfiguration: IEntityTypeConfiguration<PatientEntity>
{
    public void Configure(EntityTypeBuilder<PatientEntity> builder)
    {
        builder.ToTable("Patients");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.FamilyName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Id).IsRequired();
    }
}