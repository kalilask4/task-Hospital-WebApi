using Bogus;
using FluentValidation;
using Hospital.Abstraction.Interfaces;
using Hospital.BL.Patient;
using Hospital.Common.Models;
using Hospital.Common.Models.Collection;
using Hospital.Common.Models.Patient;
using Moq;
using Xunit;

namespace Hospital.UnitTests;

public class PatientServiceTests
{
   [Fact]
    public async Task GetAsync_ShouldReturn_PatientModelCollection()
    {
        //arrange
        var createPatientValidatorMock = new Mock<IValidator<CreatePatientModel>>();
        var updatePatientValidatorMock = new Mock<IValidator<UpdatePatientModel>>();
        var patientFilterValidatorMock = new Mock<IValidator<GetListModel<PatientFilterModel>>>();
        var patientRepositoryMock = new Mock<IPatientRepository>();

        var fakePatient = new Faker<ListPatientModel>()
            .RuleFor(x => x.Name, f => f.Name.FirstName())
            .RuleFor(x => x.FamilyName, f => f.Name.LastName())
            .RuleFor(x => x.Surname, f => f.Name.Suffix())
            .RuleFor(x => x.Address, f => f.Address.FullAddress())
            .RuleFor(x => x.Birthdate, f => f.Date.Past())
            .RuleFor(x => x.PatientGender, f => f.PickRandom(1,2))
            .RuleFor(x => x.Area, f => f.Address.ZipCode())
            .Generate();

        patientRepositoryMock.Setup(x => x.GetAsync(It.IsAny<GetListModel<PatientFilterModel>>()))
            .ReturnsAsync(new BaseCollectionModel<ListPatientModel>
            {
                Items = new [] { fakePatient },
                TotalCount = 1
            });

        var patientService = new PatientService(
            createPatientValidatorMock.Object,
            updatePatientValidatorMock.Object,
            patientFilterValidatorMock.Object,
            patientRepositoryMock.Object
        );

        //act
        var result = await patientService.GetAsync(new GetListModel<PatientFilterModel>()
        {
            Filter = new PatientFilterModel
            {
                Name = fakePatient.Name,
                FamilyName = fakePatient.FamilyName
            }
        });

        //assert
        Assert.NotNull(result);
        Assert.Equal(1, result.TotalCount);
        Assert.Equal(result.TotalCount, result.Items.Count);

        var first = result.Items.First();
        Assert.Equal(fakePatient.Name, first.Name);
        Assert.Equal(fakePatient.FamilyName, first.FamilyName);
    }
}