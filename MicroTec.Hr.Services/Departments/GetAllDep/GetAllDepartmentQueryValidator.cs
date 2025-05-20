using FluentValidation;
using MicroTec.Hr.Services.Employees.GetAllEmployees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Services.Departments.GetAllDep
{
    public class GetAllDepartmentQueryValidator : AbstractValidator<GetAllDepartmentQuery>
    {
        public GetAllDepartmentQueryValidator()
        {
            RuleFor(x => x.PageNumber)
           .GreaterThan(0).WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0).WithMessage("Page size must be greater than 0.");
        }
    }
}
