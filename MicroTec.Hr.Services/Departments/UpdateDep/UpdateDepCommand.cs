using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Services.Departments.UpdateDep
{
    public record class UpdateDepCommand: IRequest
    {
        public Guid Id { get; init; }
        public int Code { get; private set; }
        public string Name { get; set; } = string.Empty;
        public Guid UserId { get; init; }
    }
}
