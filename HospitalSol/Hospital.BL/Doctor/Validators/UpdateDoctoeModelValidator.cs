using FluentValidation;
using Hospital.Abstraction.Interfaces;
using Hospital.Common.Models.Doctor;

namespace Hospital.BL.Doctor.Validators;

public class UpdateDoctorModelValidator : AbstractValidator<UpdateDoctorModel>
{
    public UpdateDoctorModelValidator(IDoctorRepository doctorRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.FamilyName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.Surname)
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.AreaId)
            .GreaterThan(0)
            .WithMessage("Идентификатор станции должен быть больше 0 или null");

        RuleFor(x => x.OfficeId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Идентификатор кабинета должен быть больше 0");
    }
}