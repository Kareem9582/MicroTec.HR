using FluentValidation;
using MicroTec.Hr.BackendApi.Features.Employees.CreateEmployee;
using MicroTec.Hr.Services.Departments.CreateDep;

namespace MicroTec.Hr.BackendApi.Features.Departments.CreateDepartment
{
    public class CreateDepartmentRequestValidator : AbstractValidator<CreateDepartmentRequest>
    {
        public CreateDepartmentRequestValidator()
        {
            RuleFor(x => x.Name).NameRules();
        }
    }
}
