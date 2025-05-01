using MediatR;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Infrastructure.Shared
{

    public class DomainEventDispatcher(IMediator mediator) : IDomainEventDispatcher
    {
        private readonly IMediator _mediator = mediator;

        public async Task DispatchEventsAsync(IEnumerable<BaseEntity> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                var events = entity.DomainEvents.ToList();

                foreach (var domainEvent in events)
                {
                    // Use MediatR Publish
                    await _mediator.Publish(domainEvent, cancellationToken);

                }

                entity.ClearDomainEvents(); // After successful publish
            }
        }
    }

}
