using FluentValidation;
using Hospital.Abstraction.Interfaces;
using Hospital.Common.Models.Patient;

namespace Hospital.BL.Patient.Validators;

public class UpdatePatientModelValidator : AbstractValidator<UpdatePatientModel>
{
    public UpdatePatientModelValidator(IPatientRepository patientRepository)
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
    }
}