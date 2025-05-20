using FluentValidation;
using MicroTec.Hr.BackendApi.Features.Employees.UpdateEmployee;
using MicroTec.Hr.Services.Departments.CreateDep;

namespace MicroTec.Hr.BackendApi.Features.Departments.UpdateDepartment
{
    public class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequest>
    {
        public UpdateDepartmentRequestValidator()
        {
            RuleFor(x => x.Name).NameRules();
        }
    }
}
