using Hospital.Abstraction.Interfaces;
using Hospital.Common.Models;

namespace Hospital.BL.Patient.Validators;

using FluentValidation;

public class CreatePatientModelValidator : AbstractValidator<CreatePatientModel>
{
    public CreatePatientModelValidator(IPatientRepository patientRepository)
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
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.Surname));

        RuleFor(x => x.AreaId)
            .GreaterThan(0)
            .WithMessage("Идентификатор станции должен быть больше 0");
        
        RuleFor(x => x.FamilyName + " " + x.Name + " " + x.Surname)
            .NotEmpty()
            .CustomAsync(async (fullName, context, _) =>
            {
                var isSameFullNameExist = await patientRepository.ExistAsync(fullName);
        
                if (isSameFullNameExist)
                    context.AddFailure("Пациент с такими ФИО уже существует");
            });
    }
    
}