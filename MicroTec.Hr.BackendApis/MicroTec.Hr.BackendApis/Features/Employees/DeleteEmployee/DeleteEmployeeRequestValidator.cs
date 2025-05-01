using FluentValidation;
using MicroTec.Hr.Services.Employees.CreateEmployee;

namespace MicroTec.Hr.BackendApi.Features.Employees.DeleteEmployee
{
    public class DeleteEmployeeRequestValidator : AbstractValidator<DeleteEmployeeRequest>
    {
        public DeleteEmployeeRequestValidator()
        {
            RuleFor(x => x.Id).IdRules();    
        }
    }
}
