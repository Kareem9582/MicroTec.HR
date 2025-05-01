using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Domain.Contract
{
    public interface IDomainEventDispatcher
    {
        Task DispatchEventsAsync(IEnumerable<BaseEntity> entities, CancellationToken cancellationToken = default);
    }
}
