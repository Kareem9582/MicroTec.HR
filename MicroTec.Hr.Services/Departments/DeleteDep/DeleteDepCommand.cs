using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Services.Departments.DeleteDep
{
    public record DeleteDepCommand : IRequest<int>
    {
        public Guid DepartmentId { get; init; }
        public Guid UserId { get; init; }
    }
}
