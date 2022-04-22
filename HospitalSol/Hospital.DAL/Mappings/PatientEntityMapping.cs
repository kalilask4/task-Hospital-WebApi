using Hospital.Abstraction.Entities;
using Hospital.Common.Models;
using Hospital.Common.Models.Patient;
using Mapster;

namespace Hospital.DAL.Mappings;

public class PatientEntityMapping: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreatePatientModel, PatientEntity>()
            .IgnoreNullValues(true);
            // .Map(x => x.Start, s => s.Start.ToUniversalTime());
        //     
        // config.ForType<UpdateEventModel, EventEntity>()
        //     .IgnoreNullValues(true)
        //     .Map(x => x.Start, s => s.Start.ToUniversalTime());

        // config.ForType<PatientEntity, PatientModel>()
        //     .IgnoreNullValues(true);
        
        config.ForType<PatientEntity, PatientModel>()
            .IgnoreNullValues(true)
            .Map(x => x.Area, s => s.Area)
            .MaxDepth(3);
        
    }
}