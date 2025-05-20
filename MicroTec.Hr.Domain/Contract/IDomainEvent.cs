using MediatR;

namespace MicroTec.Hr.Domain.Contract
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }
        DateTimeOffset OccurredOn { get; }
    }
}
