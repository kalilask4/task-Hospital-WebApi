using Hospital.Abstraction.Entities;
using Hospital.Common.Models.Doctor;
using Mapster;

namespace Hospital.DAL.Mappings;

public class DoctorEntityMapping: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<DoctorEntity, DoctorModel>()
            .IgnoreNullValues(true)
            .Map(x=>x.Specializations, s=>new List<SpecializationModel>())
            .MaxDepth(3);
        
        config
            .ForType<CreateDoctorModel, DoctorEntity>()
            .IgnoreNullValues(true)
            .Map(x => x.Name, s => s.Name)
            .Map(x=>x.Specializations, s=>new List<SpecializationModel>())
            .MaxDepth(3);

    }
}