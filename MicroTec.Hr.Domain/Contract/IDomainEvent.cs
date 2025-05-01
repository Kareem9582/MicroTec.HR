using MediatR;

namespace MicroTec.Hr.Domain.Contract
{
    public interface IDomainEvent : INotification
    {
        DateTimeOffset OccurredOn { get; }
    }
}
