using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Services.Departments.CreateDep
{
    public record CreateDepCommand : IRequest<Guid>
    {
        public int Code { get; set; }
        public string Name { get; init; } = default!;
        public Guid UserId { get; init; }
    }

}
