using FluentValidation;
using MicroTec.Hr.Services.Employees.CreateEmployee;

namespace MicroTec.Hr.BackendApi.Features.Employees.CreateEmployee
{
    public class CreateEmployeeRequestValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeRequestValidator()
        {
            RuleFor(x => x.FullName).FullNameRules();
            RuleFor(x => x.BirthDate).BirthDateRules();
            RuleFor(x => x.Gender).GenderRules();
            RuleFor(x => x.Nationality).NationalityRules();
        }
    }
}
