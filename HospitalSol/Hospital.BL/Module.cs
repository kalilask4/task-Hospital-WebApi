using FluentValidation;
using Hospital.BL.Doctor.Validators;
using Hospital.Common.Models.Doctor;
using Autofac;
using Hospital.Common.Models.Collection;
using Hospital.Common.Validators;

namespace Hospital.BL;

public class Module: Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CreateDoctorModelValidator>().As<IValidator<CreateDoctorModel>>().InstancePerLifetimeScope();
        builder.RegisterType<UpdateDoctorModelValidator>().As<IValidator<UpdateDoctorModel>>().InstancePerLifetimeScope();
        builder.RegisterType<GetFilterModelValidator<DoctorFilterModel>>().As<IValidator<GetListModel<DoctorFilterModel>>>().InstancePerLifetimeScope();

        
        builder.RegisterAssemblyTypes(typeof(Module).Assembly)
            .Where(x=> !x.IsAbstract && x.Name.EndsWith("Service"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}