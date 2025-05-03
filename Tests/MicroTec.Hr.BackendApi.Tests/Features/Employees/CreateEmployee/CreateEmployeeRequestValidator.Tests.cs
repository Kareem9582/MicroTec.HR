using FluentValidation.TestHelper;
using MicroTec.Hr.BackendApi.Features.Employees.CreateEmployee;
using MicroTec.Hr.BackendApi.Tests.Features.Employees.Factories;
using MicroTec.Hr.Domain.Employees;

namespace MicroTec.Hr.BackendApi.Tests.Features.Employees.CreateEmployee
{
    public class CreateEmployeeRequestValidatorTests
    {
        private readonly CreateEmployeeRequestValidator _validator = new();

        // --- Valid Case ---
        [Fact]
        public void ValidRequest_ShouldPassValidation()
        {
            var request = EmployeeFactory.ValidRequest();
            var result = _validator.TestValidate(request);
            result.ShouldNotHaveAnyValidationErrors();
        }

        // --- Employee Code Tests ---
        [Fact]
        public void InvalidEmployeeCode_ShouldFailValidation()
        {
            var request = EmployeeFactory.InvalidEmployeeCode();
            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.EmployeeCode)
                  .WithErrorMessage("Employee code must be 9 digits.");
        }

        // --- Full Name Tests ---
        [Fact]
        public void EmptyFullName_ShouldFailValidation()
        {
            var request = EmployeeFactory.InvalidFullName();
            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.FullName)
                  .WithErrorMessage("Full name is required.");
        }

        // --- Birth Date Tests ---
        [Fact]
        public void FutureBirthDate_ShouldFailValidation()
        {
            var request = EmployeeFactory.InvalidBirthDateFuture();
            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.BirthDate)
                  .WithErrorMessage("Birth date must be in the past.");
        }

        [Fact]
        public void AgeBelowMinimum_ShouldFailValidation()
        {
            var request = EmployeeFactory.InvalidBirthDateTooYoung();
            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.BirthDate)
                  .WithErrorMessage($"Employee must be between {EmployeeConstants.MIN_AGE} and {EmployeeConstants.MAX_AGE} years old.");
        }

        // --- GENDER ID Validation Tests ---
        [Fact]
        public void MissingGenderId_ShouldFailValidation()
        {
            var request = EmployeeFactory.MissingGenderId();
            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.GenderId)
                  .WithErrorMessage("Gender is required.");
        }

        [Fact]
        public void MissingNationalityId_ShouldFailValidation()
        {
            var request = EmployeeFactory.MissingNationalityId();
            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.GenderId)
                  .WithErrorMessage("Nationality is required.");
        }
    }
}