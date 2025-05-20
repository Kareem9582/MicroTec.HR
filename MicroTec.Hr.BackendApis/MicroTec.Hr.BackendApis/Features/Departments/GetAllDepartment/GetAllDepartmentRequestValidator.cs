using FluentValidation;
using MicroTec.Hr.BackendApi.Features.Employees.GetAllEmployees;

namespace MicroTec.Hr.BackendApi.Features.Departments.GetAllDepartment
{
    public class GetAllDepartmentRequestValidator : AbstractValidator<GetAllDepartmentRequest>
    {
        public GetAllDepartmentRequestValidator()
        {
            RuleFor(x => x.PageNumber)
           .GreaterThan(0).WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0).WithMessage("Page size must be greater than 0.");
        }
    }
}
