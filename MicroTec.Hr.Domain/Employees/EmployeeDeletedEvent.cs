using MicroTec.Hr.Domain.Contract;

namespace MicroTec.Hr.Domain.Employees
{
    public class EmployeeDeletedEvent(Guid employeeId) : IDomainEvent
    {
        public Guid EmployeeId { get; } = employeeId;
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
    }
}
