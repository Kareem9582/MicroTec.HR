using MediatR;
using MicroTec.Hr.Services.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Services.Departments.GetDepById
{
    public record GetDepByIdQuery : IRequest<Department>
    {
        public Guid DepID { get; init; }
        public Guid UserId { get; init; }
    }
}
