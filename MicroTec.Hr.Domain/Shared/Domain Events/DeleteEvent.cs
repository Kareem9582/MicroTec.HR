using MicroTec.Hr.Domain.Contract;

namespace MicroTec.Hr.Domain.Shared.DomainEvents
{
    public class DeleteEvent(Guid id) : IDomainEvent
    {
        public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
        public Guid Id => id;
    }
}
