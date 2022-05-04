using Hospital.Abstraction.Entities;
using Hospital.Common.Models;
using Hospital.Common.Models.Patient;
using Mapster;

namespace Hospital.DAL.Mappings;

public class PatientEntityMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreatePatientModel, PatientEntity>()
            .IgnoreNullValues(true);

        config
            .ForType<ListPatientModel, PatientModel>()
            .IgnoreNullValues(true)
            .Map(x => x.Area.Number, s => s.Area)
            .Map(x => x.PatientGender, s => s.PatientGender)
            .MaxDepth(3);
    }
}