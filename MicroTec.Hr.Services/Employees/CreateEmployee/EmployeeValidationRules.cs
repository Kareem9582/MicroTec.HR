using FluentValidation;
using MicroTec.Hr.Domain.Enums;
using MicroTec.Hr.Domain.Features.Employees;
using MicroTec.Hr.Infrastructure.Shared;

namespace MicroTec.Hr.Services.Employees.CreateEmployee
{
    public static class EmployeeValidationRules
    {
        public static IRuleBuilderOptions<T, string> EmployeeCodeRules<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                    .NotEmpty().WithMessage("Employee code is required.")
                    .Length(9).WithMessage("Employee code must be 9 digits.");
        }

        public static IRuleBuilderOptions<T, string> FullNameRules<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                    .NotEmpty().WithMessage("Full name is required.")
                    .MaximumLength(200).WithMessage("Employee code must not exceed 200 digits.");
        }

        public static IRuleBuilderOptions<T, DateTimeOffset> BirthDateRules<T>(this IRuleBuilder<T, DateTimeOffset> rule)
        {
            return rule
                .LessThan(DateTime.Today).WithMessage("Birth date must be in the past.")
                .Must(BeWithinAllowedAge).WithMessage($"Employee must be between {EmployeeConstants.MIN_AGE} and {EmployeeConstants.MAX_AGE} years old.");
        }

        public static IRuleBuilderOptions<T, Guid> IdRules<T>(this IRuleBuilder<T, Guid> rule)
        {
            return rule.RequiredRule("EmployeeId");
        }

        public static IRuleBuilderOptions<T, Gender> GenderRules<T>(this IRuleBuilder<T, Gender> rule)
        {
            return rule.IsInEnum().WithMessage("Invalid gender value.");
        }

        public static IRuleBuilderOptions<T, Guid> NationalityRules<T>(this IRuleBuilder<T, Guid> rule)
        {
            return rule.RequiredRule("Nationality");
        }

        private static bool BeWithinAllowedAge(DateTimeOffset birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age >= EmployeeConstants.MIN_AGE && age <= EmployeeConstants.MAX_AGE;
        }
    }

}
