using Hospital.Common.Models;

namespace Hospital.BL.Patient.Validators;
using FluentValidation;


public class CreatePatientModelValidator: AbstractValidator<CreatePatientModel>
{
     public CreatePatientModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(x => x.AreaId)
                .GreaterThan(0)
                .WithMessage("Идентификатор станции должен быть больше 0");
            
        }
}