// using FluentValidation;
// using Hospital.Abstraction.Interfaces;
// using Hospital.Common.Models.Doctor;
//
// namespace Hospital.BL.Doctor.Validators;
//
// public class DoctorModelValidator: AbstractValidator<CreateDoctorModel>
//     {
//         public DoctorModelValidator(IDoctorRepository doctorRepository)
//         {
//             RuleFor(x => x.Name)
//                 .NotEmpty()
//                 .MinimumLength(2)
//                 .MaximumLength(100);
//         
//             RuleFor(x => x.FamilyName)
//                 .NotEmpty()
//                 .MinimumLength(2)
//                 .MaximumLength(100);
//
//             RuleFor(x => x.AreaId)
//                 .GreaterThan(0)
//                 .WithMessage("Идентификатор станции должен быть больше 0");
//         
//             RuleFor(x => x.OfficeId)
//                 .NotEmpty()
//                 .GreaterThan(0)
//                 .WithMessage("Идентификатор кабинета должен быть больше 0");
//             
//         }
//
// }