using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Services.Departments.CreateDep
{
    public static class DepartmentValidationRules
    {
        public static IRuleBuilderOptions<T, string> NameRules<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                    .NotEmpty().WithMessage("Department name is required.")
                    .MaximumLength(200).WithMessage("Department name must not exceed 500 digits.");
        }

    }
}
