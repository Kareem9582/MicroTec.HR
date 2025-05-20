using MicroTec.Hr.Domain.Contract;

namespace MicroTec.Hr.Domain.Features.Employees
{
    public class EmployeeUpdatedEvent(Guid employeeId) : IDomainEvent
    {
     
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
        public Guid Id => employeeId;
    }
}
