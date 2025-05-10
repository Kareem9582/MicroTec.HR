using MicroTec.Hr.Domain.Contract;

namespace MicroTec.Hr.Domain.Features.Employees
{
    public class EmployeeCreatedEvent(Guid employeeId) : IDomainEvent
    {
        public Guid EmployeeId { get; } = employeeId;
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
    }
}
