using Hospital.Common.Models;

namespace Hospital.BL.Patient.Validators;

using FluentValidation;

public class CreatePatientModelValidator : AbstractValidator<CreatePatientModel>
{
    public CreatePatientModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.FamilyName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.AreaId)
            .GreaterThan(0)
            .WithMessage("Идентификатор станции должен быть больше 0");
    }
}