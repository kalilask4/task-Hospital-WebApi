using Hospital.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.DAL.Configuration;

public class DoctorEntityConfiguration : IEntityTypeConfiguration<DoctorEntity>
{
    public void Configure(EntityTypeBuilder<DoctorEntity> builder)
    {
        builder.ToTable("Doctors");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FamilyName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Id).IsRequired();
    }
}