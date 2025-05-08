using FluentValidation;

namespace MicroTec.Hr.Services.Employees.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.FullName).FullNameRules();
            RuleFor(x => x.BirthDate).BirthDateRules();
            RuleFor(x => x.Gender).GenderRules();
            RuleFor(x => x.NationalityId).NationalityRules();
        }
    }
}
