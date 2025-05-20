using MicroTec.Hr.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTec.Hr.Domain.Features.Departments
{
    public class DepartmentUpdatedEvent(Guid departmentId) : IDomainEvent
    {
       
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;

        public Guid Id => departmentId;
    }
}
