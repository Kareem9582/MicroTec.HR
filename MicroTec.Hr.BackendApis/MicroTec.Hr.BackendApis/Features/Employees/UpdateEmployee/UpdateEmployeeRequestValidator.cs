using FluentValidation;
using MicroTec.Hr.Services.Employees.CreateEmployee;

namespace MicroTec.Hr.BackendApi.Features.Employees.UpdateEmployee
{
    public class UpdateEmployeeRequestValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeRequestValidator()
        {
            RuleFor(x => x.FullName).FullNameRules();
            RuleFor(x => x.BirthDate).BirthDateRules();
            RuleFor(x => x.Gender).GenderRules();
            RuleFor(x => x.Nationality).NationalityRules();
        }
    }
}
