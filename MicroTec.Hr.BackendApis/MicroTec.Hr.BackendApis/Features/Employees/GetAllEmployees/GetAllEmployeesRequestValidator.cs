using FluentValidation;

namespace MicroTec.Hr.BackendApi.Features.Employees.GetAllEmployees
{
    public class GetAllEmployeesRequestValidator : AbstractValidator<GetAllEmployeesRequest>
    {
        public GetAllEmployeesRequestValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0).WithMessage("Page size must be greater than 0.");
        }
    }
}
