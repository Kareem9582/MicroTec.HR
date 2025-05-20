using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MicroTec.Hr.Services.Employees.CreateEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Services.Departments.CreateDep
{
    public class CreateDepCommandValidator : AbstractValidator<CreateDepCommand>
    {
        public CreateDepCommandValidator()
        {
            RuleFor(x => x.Name).NameRules();

        }
    }
}
